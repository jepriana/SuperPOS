using Microsoft.Extensions.DependencyInjection;
using SuperPOS.Core.Helpers;
using SuperPOS.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperPOS.Views.Commons
{
    public partial class LoginForm : Form
    {
        private bool isPasswordVisible = false;
        private readonly IUserRepository _userRepository;

        public LoginForm()
        {
            InitializeComponent();
            _userRepository = Program.ServiceProvider.GetService<IUserRepository>();
        }

        private void iconButtonShowHidePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            if (isPasswordVisible) {
                textBoxPassword.PasswordChar = '\0';
                iconButtonShowHidePassword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
                iconButtonShowHidePassword.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUsername.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter username and password", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var user = await _userRepository.GetByUsernameAsync(textBoxUsername.Text);
                if (user != null)
                {
                    if (PasswordHelper.VerifyPassword(textBoxPassword.Text, user.Password))
                    {
                        textBoxUsername.Clear();
                        textBoxPassword.Clear();
                        Program.CurrentUser = user;
                        MainForm mainForm = new MainForm(this);
                        mainForm.Show();
                        textBoxUsername.Focus();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid password", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Failed to login", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
