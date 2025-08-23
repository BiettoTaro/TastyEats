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
using TastyEats.Models;
using TastyEats.Helpers;

namespace TastyEats.Views
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text.Trim();
            string name = nameBox.Text.Trim();
            string phone = phoneBox.Text.Trim();
            string address = addressBox.Text.Trim();
            string password = passwordBox.Text;
            string confirmPassword = confirmPasswordBox.Text;

            // Use the helper to validate all input at once
            string? error = ValidationHelper.ValidateRegistration(email, name, phone, address, password, confirmPassword);
            if (error != null)
            {
                MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for duplicate email
            if (AuthController.GetCustomerByEmail(email) != null)
            {
                MessageBox.Show("That email is already registered. Please use a different one.",
                                "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                emailBox.Focus();
                return;
            }

            // Create a new customer object
            var newCustomer = new Customer
            {
                Email = email,
                Name = name,
                PhoneNumber = phone,
                Address = address,
                PasswordHash = password, // Will be hashed in AuthController
                IsActive = false, // New users are inactive until verified
                CreatedAt = DateTime.UtcNow
            };

            bool created = AuthController.CreateCustomer(newCustomer, password);
            if (created)
            {
                MessageBox.Show("Account Registered!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
