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
using TastyEats.Helpers;
using TastyEats.Models;

namespace TastyEats.Views
{
    public partial class RegisterAdminForm : Form
    {
        public RegisterAdminForm()
        {
            InitializeComponent();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text.Trim();
            string name = nameBox.Text.Trim();
            string password = passwordBox.Text;
            string confirmPassword = confirmPasswordBox.Text;

            // Validate email format
            if (!ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailBox.Focus();
                return;
            }

            // Validate password match and strength
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordBox.Clear();
                confirmPasswordBox.Clear();
                passwordBox.Focus();
                return;
            }
            if (!ValidationHelper.IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters and contain a special character.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordBox.Clear();
                confirmPasswordBox.Clear();
                passwordBox.Focus();
                return;
            }

            // Check if admin with this email already exists
            if (AuthController.GetAdminByEmail(email) != null)
            {
                MessageBox.Show("An admin with this email already exists.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailBox.Focus();
                return;
            }

            // Create new admin
            var newAdmin = new Admin
            {
                Email = email,
                Name = name,
                PasswordHash = password,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                Role = roleComboBox.SelectedItem.ToString()
            };

            bool created = AuthController.CreateAdmin(newAdmin, password);
            if (created)
            {
                MessageBox.Show("Admin registered successfully!");
                this.Close(); // or navigate back to admin management form
            }
            else
            {
                MessageBox.Show("Failed to register admin. Please try again.");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterAdminForm_Load(object sender, EventArgs e)
        {
            roleComboBox.Items.AddRange(new[] { "Staff", "Manager", "Chef" });
            roleComboBox.SelectedIndex = 0;
        }
    }
}
