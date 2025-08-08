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
    public partial class CartForm : Form
    {
        public CartForm()
        {
            InitializeComponent();
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            cartPanel.Controls.Clear();

            foreach (var item in Models.Cart.Items)
            {
                var panel = new Panel { Width = 400, Height = 60 };

                var nameLabel = new Label
                {
                    Text = item.Name,
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                var quantityLabel = new Label
                {
                    Text = $"Qty: {item.Quantity}",
                    Location = new Point(150, 10),
                    AutoSize = true
                };

                var priceLabel = new Label
                {
                    Text = $"£{item.TotalPrice:F2}",
                    Location = new Point(230, 10),
                    AutoSize = true
                };

                var removeBtn = new Button
                {
                    Text = "Remove",
                    Location = new Point(310, 5),
                    Size = new Size(70, 25)
                };
                removeBtn.Click += (s, e) =>
                {
                    Controllers.CartController.RemoveFromCart(item.ItemId);
                    LoadCartItems();
                };

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(quantityLabel);
                panel.Controls.Add(priceLabel);
                panel.Controls.Add(removeBtn);

                cartPanel.Controls.Add(panel);
            }

            totalLabel.Text = $"Total: £{Controllers.CartController.GetTotalPrice():F2}";
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            // Placeholder: call PlaceOrder()
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            Controllers.CartController.ClearCart();
            LoadCartItems();
        }
    }

}
