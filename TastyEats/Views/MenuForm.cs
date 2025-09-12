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
                menuFlowPanel.Controls.Clear();

                var menuItems = Controllers.MenuItemController.GetAllMenuItems();

                var cards = menuItems.Select(item =>
                {
                    var card = new MenuItemCard();
                    card.setupCard(
                        item.Id,
                        item.Name,
                        item.Description,
                        item.Price,
                        item.Image
                    );
                    return card;
                });

                foreach (var card in cards)
                    menuFlowPanel.Controls.Add(card);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading menu items: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
