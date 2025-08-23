using System;
using System.Windows.Forms;
using TastyEats.Helpers;
using TastyEats.Models;
using TastyEats.Controllers;

namespace TastyEats.Views
{
    public partial class ManageAccountForm : BaseForm
    {
        private Customer currentCustomer;

        public ManageAccountForm()
        {
            InitializeComponent();
        }

        private void ManageAccountForm_Load(object sender, EventArgs e)
        {
            currentCustomer = AuthController.CurrentUser as Customer;
            if (currentCustomer != null)
            {
                FormFiller.FillCustomerFields(currentCustomer, nameBox, emailBox, phoneBox, addressBox);
            }
            else
            {
                MessageBox.Show("No customer is currently logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (currentCustomer == null) return;

            // Get updated values from fields
            string newName = nameBox.Text.Trim();
            string newEmail = emailBox.Text.Trim();
            string newPhone = phoneBox.Text.Trim();
            string newAddress = addressBox.Text.Trim();

            // 1. Validate new values (email, etc) if changed
            if (currentCustomer.Email != newEmail && !ValidationHelper.IsValidEmail(newEmail))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Track if any value has changed
            bool changed = false;
            if (currentCustomer.Name != newName) { currentCustomer.Name = newName; changed = true; }
            if (currentCustomer.Email != newEmail) { currentCustomer.Email = newEmail; changed = true; }
            if (currentCustomer.PhoneNumber != newPhone) { currentCustomer.PhoneNumber = newPhone; changed = true; }
            if (currentCustomer.Address != newAddress) { currentCustomer.Address = newAddress; changed = true; }

            // 2. Password change logic
            string oldPass = oldPassBox.Text;
            string newPass = newPassBox.Text;
            string confPass = confPassBox.Text;

            bool passwordFieldsFilled = !string.IsNullOrWhiteSpace(oldPass) || !string.IsNullOrWhiteSpace(newPass) || !string.IsNullOrWhiteSpace(confPass);

            if (passwordFieldsFilled)
            {
                string pwdError = ValidationHelper.ValidatePasswordChange(oldPass, newPass, confPass);
                if (pwdError != null)
                {
                    MessageBox.Show(pwdError, "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check old password matches
                if (!AuthController.VerifyPassword(oldPass, currentCustomer.PasswordHash))
                {
                    MessageBox.Show("Old password is incorrect.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Set new password hash
                currentCustomer.PasswordHash = AuthController.HashPassword(newPass);
                changed = true;
            }

            if (!changed)
            {
                MessageBox.Show("Nothing to update.", "No Change");
                return;
            }

            // 3. Save changes to database
            if (AuthController.UpdateCustomer(currentCustomer))
            {
                MessageBox.Show("Profile updated successfully!");
            }
            else
            {
                MessageBox.Show("Failed to update profile.");
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (currentCustomer == null) return;

            // Confirm with user
            var result = MessageBox.Show("Are you sure you want to delete your account? This action cannot be undone.",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool deleted = AuthController.DeleteCustomer(currentCustomer.Id);
                if (deleted)
                {
                    MessageBox.Show("Account deleted successfully.", "Account Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Logout and redirect to home
                    AuthController.Logout();
                    var homeForm = new HomeForm();
                    homeForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to delete account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
