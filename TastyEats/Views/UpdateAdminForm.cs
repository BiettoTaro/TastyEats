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
    public partial class UpdateAdminForm : Form
    {
        private Admin currentAdmin;
        public UpdateAdminForm(Admin admin)
        {
            InitializeComponent();
            currentAdmin = admin;

            //prefill the fields with existing data
            nameBox.Text = admin.Name;
            emailBox.Text = admin.Email;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            string newName = nameBox.Text.Trim();
            string newEmail = emailBox.Text.Trim();
            string oldPassword = oldPassBox.Text;
            string newPassword = newPassBox.Text;
            string confirmPassword = confPassBox.Text;

            // Use validator helper
            if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newEmail))
            {
                MessageBox.Show("Name and email are required.", "Error");
                return;
            }
            if (!ValidationHelper.IsValidEmail(newEmail))
            {
                MessageBox.Show("Invalid email format.", "Error");
                return;
            }

            //  Validate Passwords
            bool changingPassword = !string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confirmPassword) || !string.IsNullOrEmpty(oldPassword);
            if (changingPassword)
            {
                // Old password must match
                if (!AuthController.VerifyPassword(oldPassword, currentAdmin.PasswordHash))
                {
                    MessageBox.Show("Old password is incorrect.", "Error");
                    oldPassBox.Clear();
                    oldPassBox.Focus();
                    return;
                }

                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("New passwords do not match.", "Error");
                    confPassBox.Clear();
                    confPassBox.Focus();
                    return;
                }
                if (!ValidationHelper.IsValidPassword(newPassword))
                {
                    MessageBox.Show("Password must be at least 8 chars and have a special character.", "Error");
                    newPassBox.Clear();
                    confPassBox.Clear();
                    newPassBox.Focus();
                    return;
                }
            }

            // Update fields 
            currentAdmin.Name = newName;
            currentAdmin.Email = newEmail;
            if (changingPassword)
                currentAdmin.PasswordHash = AuthController.HashPassword(newPassword);

            //  Persist to DB 
            if (AuthController.UpdateAdmin(currentAdmin))
            {
                MessageBox.Show("Admin updated!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Update failed.");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
