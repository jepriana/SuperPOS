using SuperPOS.Core.Helpers;
using SuperPOS.Models;
using System;
using System.Windows.Forms;

namespace SuperPOS.Views.Users
{
    public partial class UserEntryForm : Form
    {
        public User NewUser { get; private set; }
        public User UpdateUser { get; set; }

        public UserEntryForm()
        {
            InitializeComponent();
        }

        private void iconButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateUser != null)
                {
                    UpdateUser.Username =
                    UpdateUser.Username = textBoxUsername.Text;
                    UpdateUser.Email = textBoxEmail.Text;
                    UpdateUser.Phone = textBoxPhone.Text;
                    UpdateUser.Firstname = textBoxFirstname.Text;
                    UpdateUser.Lastname = textBoxLastname.Text;
                    UpdateUser.IsAdmin = checkBoxIsAdmin.Checked;
                    if (string.IsNullOrEmpty(textBoxPassword.Text) && string.IsNullOrEmpty(textBoxRepeatPassword.Text) && textBoxPassword.Text.Equals(textBoxRepeatPassword.Text))
                    {
                        UpdateUser.Password = PasswordHelper.HashPassword(textBoxPassword.Text);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(textBoxPassword.Text) || !string.IsNullOrEmpty(textBoxRepeatPassword.Text) || !textBoxPassword.Text.Equals(textBoxRepeatPassword.Text))
                    {
                        throw new Exception("Please enter valid password");
                    }
                    NewUser = new User
                    {
                        Username = textBoxUsername.Text,
                        Email = textBoxEmail.Text,
                        Phone = textBoxPhone.Text,
                        Firstname = textBoxFirstname.Text,
                        Lastname = textBoxLastname.Text,
                        Password = PasswordHelper.HashPassword(textBoxPassword.Text),
                        IsAdmin = checkBoxIsAdmin.Checked,
                    };
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to save data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserEntryForm_Load(object sender, EventArgs e)
        {
            if (UpdateUser != null)
            {
                textBoxUsername.Text = UpdateUser.Username;
                textBoxEmail.Text = UpdateUser.Email;
                textBoxPhone.Text = UpdateUser.Phone;
                textBoxFirstname.Text = UpdateUser.Firstname;
                textBoxLastname.Text = UpdateUser.Lastname;
                checkBoxIsAdmin.Checked = UpdateUser.IsAdmin;
            }
        }
    }
}
