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
    public partial class MenuForm : BaseForm
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading menu items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the menu form
            var cartForm = new Views.CartForm();

            cartForm.ShowDialog();

            this.Show(); // Show the menu form again after cart is closed
        }

        
    }
}
