using FontAwesome.Sharp;
using SuperPOS.Views.Users;
using System;
using System.Windows.Forms;

namespace SuperPOS.Views.Commons
{
    public partial class MainForm : Form
    {
        private Panel activeSubMenuPanel;
        private Form loginForm;
        private Form activeChildForm;
        //private readonly UserModel activeUser;
        public MainForm(Form loginForm)
        {
            this.loginForm = loginForm;
            InitializeComponent();
        }

        private void ShowSubMenu(Panel subMenuPanel)
        {
            if (activeSubMenuPanel != null && activeSubMenuPanel != subMenuPanel)
            {
                activeSubMenuPanel.Visible = false;
                activeSubMenuPanel = null;
            }
            if (subMenuPanel != null)
            {
                activeSubMenuPanel = subMenuPanel;
                activeSubMenuPanel.Visible = true;
            }
        }

        private void OpenChildForm(Form childForm, string title, IconChar icon)
        {
            if (activeChildForm != null)
            {
                activeChildForm.Close();
                activeChildForm = null;
            }
            activeChildForm = childForm;
            activeChildForm.TopLevel = false;
            activeChildForm.FormBorderStyle = FormBorderStyle.None;
            activeChildForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(activeChildForm);
            panelMain.Tag = childForm;
            activeChildForm.BringToFront();
            activeChildForm.Show();
            iconButtonTitle.Text = title;
            iconButtonTitle.IconChar = icon;
        }

        private void Reset()
        {
            if (activeChildForm != null)
            {
                activeChildForm.Close();
                activeChildForm = null;
            }
            iconButtonTitle.Text = "Home";
            iconButtonTitle.IconChar = IconChar.Home;
            if (activeSubMenuPanel != null)
            {
                activeSubMenuPanel.Visible = false;
                activeSubMenuPanel = null;
            }
        }

        private void iconButtonHome_Click(object sender, EventArgs e)
        {
            Reset();
            ShowSubMenu(null);
        }

        private void iconButtonTransaction_Click(object sender, EventArgs e)
        {
            Reset();
            ShowSubMenu(panelTransaction);
        }

        private void iconButtonMasterData_Click(object sender, EventArgs e)
        {
            Reset();
            ShowSubMenu(panelMasterData);
        }

        private void iconButtonUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserForm(), iconButtonUsers.Text, iconButtonUsers.IconChar);
        }

        private void iconButtonLogout_Click(object sender, EventArgs e)
        {
            Program.CurrentUser = null;
            loginForm.Show();
            Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
