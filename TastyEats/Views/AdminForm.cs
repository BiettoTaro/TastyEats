using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using TastyEats.Controllers;
using TastyEats.Models;

namespace TastyEats.Views
{
    public partial class AdminForm : Form
    {
        // Simulate logged-in admin. Replace with actual admin ID in a real app.
        private int CurrentAdminId => 1;

        public AdminForm()
        {
            InitializeComponent();

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            loadMenuItems();
        }

        private void SetupCategoryColumn()
        {
            // Remove if already present
            if (menuItemsGridView.Columns.Contains("Category"))
                menuItemsGridView.Columns.Remove("Category");

            var categoryCol = new DataGridViewComboBoxColumn
            {
                Name = "Category",
                DataPropertyName = "CategoryId",
                HeaderText = "Category",
                DataSource = new[]
                {
                    new { Id = 1, Name = "Starters" },
                    new { Id = 2, Name = "Mains" },
                    new { Id = 3, Name = "Desserts" },
                    new { Id = 4, Name = "Drinks" }
                },
                ValueMember = "Id",
                DisplayMember = "Name"
            };
            menuItemsGridView.Columns.Insert(3, categoryCol); // Place at appropriate index
        }

        private void loadMenuItems()
        {
            // Setup columns (do only once for speed)
            if (menuItemsGridView.Columns.Count == 0)
            {
                menuItemsGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Name",
                    Name = "Name",
                    HeaderText = "Name"
                });
                menuItemsGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Description",
                    Name = "Description",
                    HeaderText = "Description"
                });
                menuItemsGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Price",
                    Name = "Price",
                    HeaderText = "Price"
                });
                SetupCategoryColumn();
                menuItemsGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Image",
                    Name = "Image",
                    HeaderText = "Image Path"
                });
                menuItemsGridView.Columns.Add(new DataGridViewCheckBoxColumn
                {
                    DataPropertyName = "IsAvailable",
                    Name = "IsAvailable",
                    HeaderText = "Available"
                });
                menuItemsGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "AdminId",
                    Name = "AdminId",
                    HeaderText = "Admin Id",
                    Visible = false // Hide from UI
                });
            }
            // Bind data
            var items = new BindingList<MenuItem>(MenuItemController.GetAllMenuItems());
            menuItemsGridView.DataSource = items;
            if (menuItemsGridView.Columns.Contains("Id"))
                menuItemsGridView.Columns["Id"].Visible = false;
        }


        private void menuItemsGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var item = e.Row.DataBoundItem as MenuItem;
            if (item != null && item.Id > 0)
            {
                var result = MessageBox.Show($"Delete '{item.Name}'?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (!MenuItemController.DeleteMenuItem(item.Id))
                    {
                        MessageBox.Show("Delete failed.");
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        // Optional: Manual refresh button event
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            loadMenuItems();
        }

        private void addMenuBtn_Click(object sender, EventArgs e)
        {
            var bindingList = menuItemsGridView.DataSource as BindingList<MenuItem>;
            if (bindingList != null)
            {
                // Create a new menu item with sensible defaults
                var newItem = new MenuItem
                {
                    Name = "",
                    Description = "",
                    Price = 0,
                    CategoryId = 1,
                    Image = "",
                    AdminId = CurrentAdminId,
                    IsAvailable = true
                };
                bindingList.Add(newItem);

                // Scroll to new row and select the first cell for editing
                int rowIndex = bindingList.Count - 1;
                //menuItemsGridView.CurrentCell = menuItemsGridView.Rows[rowIndex].Cells[0];
                menuItemsGridView.BeginEdit(true);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (menuItemsGridView.SelectedRows.Count > 0)
            {
                var item = menuItemsGridView.SelectedRows[0].DataBoundItem as MenuItem;
                if (item != null && item.Id > 0)
                {
                    var result = MessageBox.Show($"Delete '{item.Name}'?", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (!MenuItemController.DeleteMenuItem(item.Id))
                            MessageBox.Show("Delete failed.");
                        else
                            loadMenuItems();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a row to delete.");
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            menuItemsGridView.EndEdit(); // Commit any cell edits

            if (menuItemsGridView.CurrentRow != null)
            {
                var item = menuItemsGridView.CurrentRow.DataBoundItem as MenuItem;

                if (item != null)
                {
                    // Validate
                    if (string.IsNullOrWhiteSpace(item.Name) || item.Price <= 0 || item.CategoryId <= 0)
                    {
                        MessageBox.Show("Name, price, and category are required.");
                        return;
                    }

                    // Insert or update
                    if (item.Id == 0)
                    {
                        // New item
                        if (item.AdminId == 0) item.AdminId = CurrentAdminId;
                        item.IsAvailable = true;
                        if (string.IsNullOrWhiteSpace(item.Image)) item.Image = "";

                        if (MenuItemController.AddMenuItem(item))
                        {
                            MessageBox.Show("Menu item added!");
                            loadMenuItems(); // To update the grid and get the real Id
                        }
                        else
                        {
                            MessageBox.Show("Failed to add menu item.");
                        }
                    }
                    else
                    {
                        // Existing item
                        if (MenuItemController.UpdateMenuItem(item))
                        {
                            MessageBox.Show("Menu item updated!");
                            loadMenuItems();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update menu item.");
                        }
                    }
                }
            }
        }

    }
}
