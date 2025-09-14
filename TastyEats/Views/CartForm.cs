using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TastyEats.Models;

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

        private void AddCartRow(CartItem item)
        {
            var row = new TableLayoutPanel
            {
                ColumnCount = 4,
                AutoSize = true,
                Dock = DockStyle.Top,
                Padding = new Padding(5),
            };

            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));  // Name
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 95)); // Qty box
            row.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));     // Remove btn
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));  // Line total

            // Name
            var nameLabel = new Label
            {
                Text = item.Name,
                AutoSize = true,
                Width = 200,
                Height = 40,
                MaximumSize = new Size(200, 0), 
                Font = new Font("Verdana", 10, FontStyle.Bold),
                Anchor = AnchorStyles.Left,
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Quantity box (wider so arrows are visible)
            var numQty = new NumericUpDown
            {
                Minimum = 1,
                Value = item.Quantity,
                Width = 85,
                Anchor = AnchorStyles.Left,
                Location = new Point(150, 5)
            };
            numQty.ValueChanged += (s, e) =>
            {
                Controllers.CartController.UpdateLine(item.LineId, (int)numQty.Value, item.Notes);
                LoadCartItems();
            };

            // Remove button
            var btnRemove = new Button
            {
                Text = (item.Quantity > 1) ? "Remove One" : "Remove",
                AutoSize = true,
                Anchor = AnchorStyles.Left
            };
            btnRemove.Click += (s, e) =>
            {
                if (item.Quantity > 1)
                    Controllers.CartController.RemoveOne(item.LineId);
                else
                    Controllers.CartController.RemoveLine(item.LineId);

                LoadCartItems();
            };

            // Line total
            var lineTotal = new Label
            {
                Text = $"Line: £{item.TotalPrice:F2}",
                AutoSize = true,
                Font = new Font("Verdana", 10, FontStyle.Bold),
                Anchor = AnchorStyles.Left
            };

            // Add to row
            row.Controls.Add(nameLabel, 0, 0);
            row.Controls.Add(numQty, 1, 0);
            row.Controls.Add(btnRemove, 2, 0);
            row.Controls.Add(lineTotal, 3, 0);

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
