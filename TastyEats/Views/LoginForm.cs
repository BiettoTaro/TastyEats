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
        public LoginForm()
        {
            InitializeComponent();
        }

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

                if (user is TastyEats.Models.Customer)
                {
                    // Open the cart or customer main area
                    var checkoutForm = new CheckoutForm();  // Replace with your actual form
                    checkoutForm.ShowDialog();
                }
                else if (user is TastyEats.Models.Admin)
                {
                    // Open the admin dashboard
                    var adminForm = new AdminForm(); // Replace with your actual admin form
                    adminForm.ShowDialog();
                }

                this.Close(); // After user closes CartForm/AdminForm, close LoginForm
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
