using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TastyEats.Controllers;

namespace TastyEats.Views
{
    public partial class LoginForm : Form
    {
        private Form _returnToForm;
        public LoginForm(Form returnToForm = null)
        {
            InitializeComponent();
            _returnToForm = returnToForm;
        }
        public LoginForm() : this(null) { }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text.Trim();
            string password = passwordBox.Text;

            if (AuthController.Login(email, password))
            {
                string userName = AuthController.CurrentUser?.Name ?? "";
                MessageBox.Show($"Welcome, {userName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var user = AuthController.CurrentUser;
                this.Hide();

                // If an admin logs in, always go to AdminForm
                if (user is TastyEats.Models.Admin)
                {
                    var adminForm = new AdminForm();
                    adminForm.Show();
                }
                // If a customer logs in
                else if (user is TastyEats.Models.Customer)
                {
                    // If we have a return-to form, show it
                    if (_returnToForm is BaseForm baseForm)
                    {
                        baseForm.SetLoginStatus(true);
                        baseForm.Show();
                    }
                    else
                    {
                        var homeForm = new HomeForm();
                        homeForm.Show();
                    }
                }

                // Always close the login form, otherwise it might hang around
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordBox.Clear();
                passwordBox.Focus();
            }
        }



        private void signUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // Hide the login form
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Show(); // Show the login form again after registration
        }
    }
}
