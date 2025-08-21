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


namespace TastyEats.Views
{
    public partial class CheckoutForm : Form
    {
        User user = AuthController.CurrentUser;
        private OrderController OrderController = new OrderController();

        public CheckoutForm()
        {
            InitializeComponent();
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            nameBox.Text = user?.Name ?? string.Empty;
            emailBox.Text = user?.Email ?? string.Empty;
            addressBox.Text = user is Customer customer ? customer.Address : string.Empty;
            cardNameBox.Text = user?.Name ?? string.Empty;
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
                MessageBox.Show("Please fill in all required billing fields.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isCardPayment = !radioButton1.Checked; // radioButton1 = cash

            if (isCardPayment)
            {
                // Validate card fields
                if (string.IsNullOrWhiteSpace(cardNameBox.Text) ||
                    string.IsNullOrWhiteSpace(cardNumberBox.Text) ||
                    string.IsNullOrWhiteSpace(cvvBox.Text) ||
                    expDtp.Value < DateTime.Now)
                {
                    MessageBox.Show("Please fill in all card details.", "Incomplete Payment Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate card number format
                var cardPattern = @"^(?:\d{4}[- ]?){3}\d{4}$";
                if (!Regex.IsMatch(cardNumberBox.Text, cardPattern))
                {
                    MessageBox.Show("Card number format is invalid.", "Invalid Card Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate CVV (3 or 4 digits)
                if (!Regex.IsMatch(cvvBox.Text, @"^\d{3,4}$"))
                {
                    MessageBox.Show("CVV must be 3 or 4 digits.", "Invalid CVV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Build order
            string paymentMethod = isCardPayment ? "Card" : "Cash";
            var order = new Order
            {
                CustomerId = user.Id,
                OrderDate = DateTime.Now,
                Status = "Pending",
                TotalAmount = Controllers.CartController.GetTotalPrice(),
                Items = new List<OrderItem>()
            };

            foreach (var cartItem in CartController.GetItems())
            {
                order.Items.Add(new OrderItem
                {
                    ItemId = cartItem.ItemId,
                    Quantity = cartItem.Quantity,
                    PriceAtOrder = cartItem.Price
                });
            }

            try
            {
                OrderController.AddOrder(order);
                MessageBox.Show(
                    $"Order placed!\n\nOrder Number: {order.OrderId}\nDate: {order.OrderDate}\nTotal: £{order.TotalAmount:F2}",
                    "Order Confirmation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Controllers.CartController.ClearCart(); // Clear cart after success only
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error placing order: {ex.Message}", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Cart is NOT cleared if order fails
            }
        }

    }
}
