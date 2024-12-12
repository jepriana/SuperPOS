using Microsoft.Extensions.DependencyInjection;
using SuperPOS.Core.Helpers;
using SuperPOS.Models;
using SuperPOS.Repositories.UserRepository;
using System.Collections.Generic;
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
    }
}
