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

            // Subscribe to menu change events
            Controllers.MenuItemController.OnMenuChanged += (item, action) =>
            {
                // Reload menu items when something changes
                LoadMenuItems();

               
                MessageBox.Show($"Menu item {item.Name} {action}.",
                                "Menu Updated",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            };

            LoadMenuItems();
        }


        private void LoadMenuItems()
        {
            try
            {
                string query = "SELECT item_id, name, description, price, category_id, image_path FROM menu_items WHERE is_available = true";
                DataTable menuItems = DatabaseHandler.ExecuteQuery(query);

                menuFlowPanel.Controls.Clear();

                var cards = menuItems.AsEnumerable().Select(row =>
                {
                    var card = new MenuItemCard();
                    card.setupCard(
                        row.Field<int>("item_id"),
                        row.Field<string>("name") ?? string.Empty,
                        row.Field<string>("description") ?? string.Empty,
                        row.Field<decimal>("price"),
                        row.Field<string>("image_path") ?? string.Empty
                    );
                    return card;
                });

                foreach (var card in cards)
                    menuFlowPanel.Controls.Add(card);
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
