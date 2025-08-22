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
            // Get the currently logged-in user as Customer
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

            // Track if any value has changed
            bool changed = false;
            if (currentCustomer.Name != newName) { currentCustomer.Name = newName; changed = true; }
            if (currentCustomer.Email != newEmail) { currentCustomer.Email = newEmail; changed = true; }
            if (currentCustomer.PhoneNumber != newPhone) { currentCustomer.PhoneNumber = newPhone; changed = true; }
            if (currentCustomer.Address != newAddress) { currentCustomer.Address = newAddress; changed = true; }

            // Password change logic goes here (not shown in this snippet)

            if (!changed && AllPasswordFieldsEmpty())
            {
                MessageBox.Show("Nothing to update.", "No Change");
                return;
            }

            // Save changes if something changed
            if (changed)
            {
                if (AuthController.CurrentUser is Customer sessionCustomer)
                {
                    sessionCustomer.Name = currentCustomer.Name;
                    sessionCustomer.Email = currentCustomer.Email;
                }
                else
                {
                    MessageBox.Show("Failed to update profile.");
                }
            }
        }

        // Example stub for password check, implement as needed
        private bool AllPasswordFieldsEmpty()
        {
            // Replace with your password TextBox names!
            return string.IsNullOrWhiteSpace(oldPassBox.Text)
                && string.IsNullOrWhiteSpace(newPassBox.Text)
                && string.IsNullOrWhiteSpace(confPassBox.Text);
        }
    }
}
