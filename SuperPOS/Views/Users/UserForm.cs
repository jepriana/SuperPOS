using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using SuperPOS.Core.Helpers;
using SuperPOS.Models;
using SuperPOS.Repositories.UserRepository;
using SuperPOS.Views.Commons;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SuperPOS.Views.Users
{
    public partial class UserForm : Form
    {
        private readonly IUserRepository _userRepository;
        private List<User> _dataUsers = new List<User>();
        private User _selectedUser;
        public UserForm()
        {
            InitializeComponent();
            _userRepository = Program.ServiceProvider.GetService<IUserRepository>();
        }

        private async void UserForm_Load(object sender, System.EventArgs e)
        {
            await LoadUserData();
        }

        private async Task LoadUserData()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                if (users != null)
                {
                    _dataUsers.Clear();
                    _dataUsers.AddRange(users);
                    dataGridViewMain.Rows.Clear();
                    if (_dataUsers.Count > 0)
                    {
                        dataGridViewMain.Rows.Add(_dataUsers.Count);
                        for (int i = 0; i < _dataUsers.Count; i++)
                        {
                            dataGridViewMain.Rows[i].Height = 48;
                            var user = _dataUsers[i];
                            dataGridViewMain.Rows[i].Cells[0].Value = i + 1;
                            dataGridViewMain.Rows[i].Cells[1].Value = user.Username;
                            dataGridViewMain.Rows[i].Cells[2].Value = user.Firstname;
                            dataGridViewMain.Rows[i].Cells[3].Value = user.Lastname;
                            dataGridViewMain.Rows[i].Cells[4].Value = user.Email;
                            dataGridViewMain.Rows[i].Cells[5].Value = user.Phone;
                            dataGridViewMain.Rows[i].Cells[6].Value = user.IsAdmin;
                        }

                        DataGridViewHelper.GenerateColumnButton(dataGridViewMain, 7, SuperPosHelper.ACTION_EDIT);
                        DataGridViewHelper.GenerateColumnButton(dataGridViewMain, 8, SuperPosHelper.ACTION_DELETE);
                        DataGridViewHelper.UpdateDataGridBackground(dataGridViewMain);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed to load data");
            }
        }

        private void dataGridViewMain_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _dataUsers.Count)
                return;

            DataGridViewHelper.AddColumnUpdateButton(e, 7);
            DataGridViewHelper.AddColumnDeleteButton(e, 8);
        }

        private async void dataGridViewMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewMain.Rows.Count > 0 && e.RowIndex >= 0)
            {
                _selectedUser = _dataUsers[e.RowIndex];
                if (e.ColumnIndex == dataGridViewMain.Columns[SuperPosHelper.ACTION_EDIT].Index)
                {
                    DialogResult result = MessageBox.Show("Apakah anda yakin ingin memperbaharui data?", "Pembaharuan Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        using (var userEntry = new UserEntryForm())
                        {
                            userEntry.UpdateUser = _selectedUser;
                            if (userEntry.ShowDialog() == DialogResult.OK)
                            {
                                await _userRepository.UpdateAsync(userEntry.UpdateUser);
                                await LoadUserData();
                            }
                        }
                    }
                }
                if (e.ColumnIndex == dataGridViewMain.Columns[SuperPosHelper.ACTION_DELETE].Index)
                {
                    DialogResult result = MessageBox.Show("Apakah anda yakin ingin menghapus data?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                            await _userRepository.DeleteAsync(_selectedUser.Id);
                            MessageBox.Show("Sukses menghapus data.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadUserData();
                    }
                    _selectedUser = null;
                }
            }
        }

        private async void iconButtonAdd_Click(object sender, System.EventArgs e)
        {
            using (var userEntry = new UserEntryForm())
            {
                if (userEntry.ShowDialog() == DialogResult.OK)
                {
                    await _userRepository.CreateAsync(userEntry.NewUser);
                    await LoadUserData();
                }
            }
        }

        private void iconButtonDownload_Click(object sender, System.EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Excel Workbook|*.xlsx",
                DefaultExt = ".xlsx",
                Title = "Save Data"
            })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (ExcelPackage ep = new ExcelPackage())
                    {
                        ExcelWorksheet ws = ep.Workbook.Worksheets.Add("Users");
                        // Add the headers
                        for (int i = 0; i < dataGridViewMain.Columns.Count - 2; i++)
                        {
                            ws.Cells[1, i + 1].Value = dataGridViewMain.Columns[i].HeaderText;
                        }

                        // Add the data
                        for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridViewMain.Columns.Count - 2; j++)
                            {
                                ws.Cells[i + 2, j + 1].Value = dataGridViewMain.Rows[i].Cells[j].Value;
                            }
                        }

                        // Save the file
                        FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                        ep.SaveAs(fileInfo);
                        MessageBox.Show($"Data berhasil disimpan pada lokasi {saveFileDialog.FileName}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void iconButtonPrint_Click(object sender, System.EventArgs e)
        {
            int rowNumber = 1;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(string));
            dt.Columns.Add("Username", typeof(string));
            dt.Columns.Add("Firstname", typeof(string));
            dt.Columns.Add("Lastname", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("IsAdmin", typeof(bool));

            foreach (var user in _dataUsers)
            {
                dt.Rows.Add(rowNumber, user.Username, user.Firstname, user.Lastname, user.Email, user.Phone, user.IsAdmin);
                rowNumber++;
            }

            ds.Tables.Add(dt);
            ds.WriteXmlSchema("User.xml");
            PrintForm printForm = new PrintForm();
            UserCrystalReport userCrystalReport = new UserCrystalReport();
            userCrystalReport.SetDataSource(ds);
            printForm.crystalReportViewerMain.ReportSource = userCrystalReport;
            printForm.crystalReportViewerMain.Refresh();
            printForm.ShowDialog();
        }
    }
}
