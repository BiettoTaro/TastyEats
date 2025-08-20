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
using System.Text.RegularExpressions;

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

            // Validate email format
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailBox.Focus();
                return;
            }

            // Validate password strength (8 char min 1 symbol)
            var passwordRegex = new Regex(@"^(?=.*\W).{8,}$");
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                confirmPasswordBox.Clear();
                confirmPasswordBox.Focus();
                return;
            }
            else if (!passwordRegex.IsMatch(password))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain at least one special character.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordBox.Clear();
                confirmPasswordBox.Clear();
                passwordBox.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Please fill in all fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // In your registerBtn_Click handler, before CreateCustomer:
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
                PasswordHash = password,
                IsActive = false, // New users are inactive until verified
                CreatedAt = DateTime.UtcNow
            };

            bool created = AuthController.CreateCustomer(newCustomer, password);
            MessageBox.Show("Account Registered!");
            this.Close();

        }
    }
}
