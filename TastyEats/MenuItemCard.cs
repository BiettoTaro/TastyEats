using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TastyEats
{
    public partial class MenuItemCard : UserControl
    {

        public int ItemId { get; private set; }
        public string ItemName { get; private set; }
        public decimal ItemPrice { get; private set; }
        //public int Quantity => (int)numericQuantity.Value;
        public string ItemDescription { get; private set; }
        public MenuItemCard()
        {
            InitializeComponent();
        }

        public void setupCard(int id, string name, string description, decimal price, string imagePath)
        {
            ItemId = id;
            ItemName = name;
            ItemPrice = price;

            nameLabel.Text = name;
            descriptionLabel.Text = description;
            priceLabel.Text = $"£{price:F2}";

            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagePath);
            if (File.Exists(fullPath))
            {
                pictureBoxItem.Image = Image.FromFile(fullPath);
            }
            else
            {
                pictureBoxItem.Image = null; // or set a default image
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var popup = new Views.AddPopup(ItemName, pictureBoxItem.Image, ItemPrice,ItemId))
            {
                if (popup.ShowDialog() == DialogResult.OK && popup.CreatedItem != null)
                {
                    Controllers.CartController.AddToCart(popup.CreatedItem);
                    MessageBox.Show($"{popup.CreatedItem.Name} x{popup.CreatedItem.Quantity} added to your cart!",
                                    "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
