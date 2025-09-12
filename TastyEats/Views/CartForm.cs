using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TastyEats.Views
{
    public partial class CartForm : BaseForm
    {
        public CartForm()
        {
            InitializeComponent();

            // Subscribe to cart change events using lambda
            Controllers.CartController.OnCartChanged += (item, action) =>
            {
                totalLabel.Text = $"Total: £{Controllers.CartController.GetTotalPrice():F2}";
                // Reload cart only if structure changes (Added/Removed/Cleared)
                if (action == "Added" || action == "Removed" || action == "Cleared")
                    LoadCartItems();
                else
                    UpdateCartDisplay(item, action);
            };

            LoadCartItems();
        }

        private void LoadCartItems()
        {
            cartPanel.SuspendLayout();
            cartPanel.Controls.Clear();

            var items = Controllers.CartController.GetItems();

            if (items == null || items.Count == 0)
            {
                ShowEmptyCartMessage();
                cartPanel.ResumeLayout();
                return;
            }

            foreach (var item in items)
            {
                AddCartRow(item);
            }

            totalLabel.Text = $"Total: £{Controllers.CartController.GetTotalPrice():F2}";
            cartPanel.ResumeLayout();
        }

        private void ShowEmptyCartMessage()
        {
            var lblEmpty = new Label
            {
                Text = "Your cart is empty",
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Gray,
                Font = new Font("Verdana", 12F, FontStyle.Italic),
                Margin = new Padding((cartPanel.ClientSize.Width - 150) / 2, 20, 0, 0)
            };
            cartPanel.Controls.Add(lblEmpty);
            totalLabel.Text = "Total: £0.00";
        }

        private void AddCartRow(Models.CartItem item)
        {
            var row = new Panel
            {
                Width = cartPanel.ClientSize.Width - 30,
                Height = 90,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5)
            };

            var lblName = new Label
            {
                Text = item.Name,
                Location = new Point(10, 10),
                AutoSize = true,
                MaximumSize = new Size(220, 0)
            };

            var lblUnit = new Label
            {
                Text = $"£{item.Price:F2} each",
                Location = new Point(10, 35),
                AutoSize = true
            };

            var numQty = new NumericUpDown
            {
                Minimum = 1,
                Maximum = 99,
                Value = item.Quantity,
                Location = new Point(250, 10),
                Width = 50
            };

            var lblLineTotal = new Label
            {
                Text = $"Line: £{(item.Price * item.Quantity):F2}",
                Location = new Point(250, 40),
                AutoSize = true
            };

            var txtNotes = new TextBox
            {
                Text = item.Notes ?? string.Empty,
                Location = new Point(10, 60),
                Width = 300,
                Height = 20
            };
            txtNotes.TextChanged += (s, e) =>
                Controllers.CartController.UpdateLine(item.LineId, (int)numQty.Value, txtNotes.Text);

            var btnRemove = new Button
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Text = (item.Quantity > 1) ? "Remove One" : "Remove",
                Location = new Point(320, 8),
                
            };
            btnRemove.Click += (s, e) =>
            {
                if (numQty.Value > 1)
                    Controllers.CartController.RemoveOne(item.LineId);
                else
                    Controllers.CartController.RemoveLine(item.LineId);
            };

            numQty.ValueChanged += (s, e) =>
            {
                lblLineTotal.Text = $"Line: £{(item.Price * (int)numQty.Value):F2}";
                btnRemove.Text = (numQty.Value > 1) ? "Remove One" : "Remove";

                Controllers.CartController.UpdateLine(item.LineId, (int)numQty.Value, txtNotes.Text);
            };

            row.Controls.Add(lblName);
            row.Controls.Add(lblUnit);
            row.Controls.Add(numQty);
            row.Controls.Add(lblLineTotal);
            row.Controls.Add(btnRemove);
            row.Controls.Add(txtNotes);

            cartPanel.Controls.Add(row);
        }

        //   selective update 
        private void UpdateCartDisplay(Models.CartItem item, string action)
        {
            // Refresh totals 
            totalLabel.Text = $"Total: £{Controllers.CartController.GetTotalPrice():F2}";
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (!Controllers.AuthController.IsLoggedIn)
            {
                var loginForm = new LoginForm(this);
                this.Hide();
                var result = loginForm.ShowDialog();
                if (!Controllers.AuthController.IsLoggedIn)
                {
                    MessageBox.Show("You must be logged in to checkout.",
                        "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Show();
                    return;
                }
                this.Show();
            }

            this.Hide();
            var checkoutForm = new Views.CheckoutForm();
            checkoutForm.ShowDialog();
            this.Show();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            Controllers.CartController.ClearCart();
        }
    }


}
