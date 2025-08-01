using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TastyEats.Data;

namespace TastyEats
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            LoadMenuItems();
        }

        private void LoadMenuItems()
        {
            try
            {
                string query = "SELECT item_id, name, description, price, category_id, image_path FROM menu_items WHERE is_available = true"; // Adjust the query as needed
                DataTable menuItems = DatabaseHandler.ExecuteQuery(query);
                menuFlowPanel.Controls.Clear(); // Clear existing controls

                foreach (DataRow row in menuItems.Rows)
                {
                    var card = new MenuItemCard();
                    card.setupCard(
                        Convert.ToInt32(row["item_id"]),
                        row["name"].ToString(),
                        row["description"].ToString(),
                        Convert.ToDecimal(row["price"]),
                        row["image_path"].ToString()
                    );
                    menuFlowPanel.Controls.Add(card);
                }
            } catch (Exception ex)
                {
                    MessageBox.Show($"Error loading menu items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        //private void btnAddToCart_Click(object sender, EventArgs e)
        //{
        //    if (menuGridView.SelectedRows.Count > 0)
        //    {
        //        var selectedRow = menuGridView.SelectedRows[0];
        //        int itemId = Convert.ToInt32(selectedRow.Cells["item_id"].Value);
        //        string name = selectedRow.Cells["name"].Value.ToString();
        //        decimal price = Convert.ToDecimal(selectedRow.Cells["price"].Value);
        //        int quantity = (int)numericUpDownQuantity.Value;
        //        Models.CartItem cartItem = new Models.CartItem
        //        {
        //            ItemId = itemId,
        //            Name = name,
        //            Price = price,
        //            Quantity = quantity
        //        };
        //        Controllers.CartController.AddToCart(cartItem);
        //        MessageBox.Show($"{name} has been added to your cart.", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select an item to add to the cart.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

    }
}
