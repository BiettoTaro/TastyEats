using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TastyEats.Controllers;
using TastyEats.Models;
using TastyEats.Helpers;

namespace TastyEats.Views
{
    public partial class CheckoutForm : Form
    {
        User user = AuthController.CurrentUser;


        public CheckoutForm()
        {
            InitializeComponent();
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            var customer = user as Customer;
            FormFiller.FillCustomerFields(customer, nameBox, emailBox, phoneBox, addressBox);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            var cartForm = new CartForm();
            cartForm.Show();
            this.Close();

        }

        private void cardNumberBox_Validating(object sender, CancelEventArgs e)
        {
            // Regex for 16 digit number, allowing spaces or dashes
            string pattern = @"^(?:\d{4}[- ]?){3}\d{4}$";
            if (!Regex.IsMatch(cardNumberBox.Text, pattern))
            {
                errorProvider1.SetError(cardNumberBox, "Enter a valid 16 digit number.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cardNumberBox, "");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bool isCash = radioButton1.Checked;
            cardNameBox.Enabled = !isCash;
            cardNumberBox.Enabled = !isCash;
            expDtp.Enabled = !isCash;
            cvvBox.Enabled = !isCash;
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            // Validate common billing fields
            if (string.IsNullOrWhiteSpace(nameBox.Text) ||
                string.IsNullOrWhiteSpace(emailBox.Text) ||
                string.IsNullOrWhiteSpace(addressBox.Text))
            {
                MessageBox.Show("Please fill in all required billing fields.",
                                "Incomplete Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            bool isCardPayment = !radioButton1.Checked; // radioButton1 = cash

            if (isCardPayment)
            {
                string? cardError = ValidationHelper.ValidateCardDetails(
                    cardNameBox.Text, cardNumberBox.Text, cvvBox.Text, expDtp.Value);

                if (cardError != null)
                {
                    MessageBox.Show(cardError, "Invalid Card Info",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                string paymentMethod = isCardPayment ? "Card" : "Cash";

                // Use PaymentController instead of building order
                var order = PaymentController.ProcessOrder(AuthController.CurrentUser!, paymentMethod);

                MessageBox.Show(
                    $"Order placed!\n\nOrder Number: {order.OrderId}\nDate: {order.OrderDate}\nTotal: £{order.TotalAmount:F2}",
                    "Order Confirmation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error placing order: {ex.Message}",
                                "Order Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void backBtn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var cartForm = new CartForm();
            cartForm.ShowDialog();
            this.Close();
        }
    }
}
