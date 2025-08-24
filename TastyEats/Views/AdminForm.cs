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
        private Dictionary<int, string> idToName;
        private Dictionary<int, (string Name, string Address)> customerLookup;


        public AdminForm()
        {
            InitializeComponent();

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            idToName = MenuItemController.GetAllMenuItems().ToDictionary(item => item.Id, item => item.Name);
            customerLookup = AuthController.GetAllCustomers().ToDictionary(c => c.Id, c => (c.Name, c.Address));


            if (adminTab.SelectedTab == menuTab)
                loadMenuItems();
            else if (adminTab.SelectedTab == ordersTab)
                loadOrders();
            else if (adminTab.SelectedTab == customersTab)
                LoadCustomers();
            else if (adminTab.SelectedTab == adminsTab)
                LoadAdmins();
        }
        private void adminTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adminTab.SelectedTab == menuTab)
                loadMenuItems();
            else if (adminTab.SelectedTab == ordersTab)
                loadOrders();
            else if (adminTab.SelectedTab == customersTab)
                LoadCustomers();
            else if (adminTab.SelectedTab == adminsTab)
                LoadAdmins();
        }

        // Menu Tab Section
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

        // Orders Tab Section

        private void loadOrders()
        {
            SetupOrdersGrid();
            var orders = OrderController.GetAllOrders();

            foreach (var order in orders)
            {
                if (customerLookup.TryGetValue(order.CustomerId, out var info))
                {
                    order.CustomerName = info.Name;
                    order.CustomerAddress = info.Address;
                }
                else
                {
                    order.CustomerName = "(Unknown)";
                    order.CustomerAddress = "(Unknown)";
                }
            }
            ordersGridView.DataSource = new BindingList<Order>(orders);

            ordersGridView.DataSource = orders;
        }

        private void ordersGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (ordersGridView.Columns[e.ColumnIndex].Name == "Status")
            {
                var row = ordersGridView.Rows[e.RowIndex];
                var order = row.DataBoundItem as Order;
                if (order != null)
                {
                    OrderController.UpdateOrderStatus(order.OrderId, order.Status);
                    // Optional: MessageBox.Show("Order status updated!");
                }
            }
        }

        private void SetupOrdersGrid()
        {
            ordersGridView.AutoGenerateColumns = false;
            ordersGridView.AllowUserToAddRows = false;
            ordersGridView.AllowUserToDeleteRows = false; // Orders can't be deleted by default

            // Columns (add only if not already present)
            if (ordersGridView.Columns.Count == 0)
            {
                ordersGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CustomerName",
                    Name = "CustomerName",
                    HeaderText = "Customer Name",
                    ReadOnly = true,
                    Visible = true
                });
                ordersGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "CustomerAddress",
                    Name = "CustomerAddress",
                    HeaderText = "Customer Address",
                    ReadOnly = true  // or visible=false if you don't want to show it
                });
                ordersGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "OrderDate",
                    Name = "OrderDate",
                    HeaderText = "Date",
                    ReadOnly = true
                });
                ordersGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TotalAmount",
                    Name = "TotalAmount",
                    HeaderText = "Total (£)",
                    ReadOnly = true
                });

                // ComboBox for Status
                var statusCol = new DataGridViewComboBoxColumn
                {
                    Name = "Status",
                    DataPropertyName = "Status",
                    HeaderText = "Status",
                    DataSource = new[] { "Pending", "Completed", "Cancelled" }
                };
                ordersGridView.Columns.Add(statusCol);
            }
        }

        private void ordersGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ordersGridView.CurrentRow?.DataBoundItem is Order selectedOrder)
            {
                // Fetch order items as before
                var items = OrderItemController.GetOrderItems(selectedOrder.OrderId);

                // Assign names using dictionary
                foreach (var item in items)
                {
                    if (idToName.TryGetValue(item.ItemId, out var name))
                        item.MenuItemName = name;
                    else
                        item.MenuItemName = "(Unknown)";
                }

                SetupOrderItemsGrid();
                orderItemsGridView.DataSource = new BindingList<OrderItem>(items);
            }
        }

        private void SetupOrderItemsGrid()
        {
            orderItemsGridView.AutoGenerateColumns = false;
            orderItemsGridView.AllowUserToAddRows = false;
            orderItemsGridView.ReadOnly = true;
            orderItemsGridView.Columns.Clear();

            // Name (MenuItemName)
            orderItemsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MenuItemName",
                Name = "MenuItemName",
                HeaderText = "Item Name",
                ReadOnly = true
            });
            // Price
            orderItemsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PriceAtOrder",
                Name = "PriceAtOrder",
                HeaderText = "Price",
                ReadOnly = true
            });
            // Quantity
            orderItemsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                Name = "Quantity",
                HeaderText = "Quantity",
                ReadOnly = true
            });
        }

        // Customer Tab Section
        private void LoadCustomers()
        {
            customersGridView.AutoGenerateColumns = false;
            customersGridView.Columns.Clear();

            customersGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name"
            });
            customersGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email"
            });
            customersGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhoneNumber",
                HeaderText = "Phone"
            });
            customersGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Address"
            });


            var customers = AuthController.GetAllCustomers();
            customersGridView.DataSource = new BindingList<Customer>(customers);
        }

        private void deleteCBtn_Click(object sender, EventArgs e)
        {
            if (customersGridView.SelectedRows.Count > 0)
            {
                var customer = customersGridView.SelectedRows[0].DataBoundItem as Customer;
                if (customer != null && customer.Id > 0)
                {
                    // Prevent deleting customers with orders
                    var orders = OrderController.GetOrdersForCustomer(customer.Id);
                    if (orders != null && orders.Any())
                    {
                        MessageBox.Show("Cannot delete a customer with existing orders.");
                        return;
                    }

                    var result = MessageBox.Show($"Delete '{customer.Name}'?", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (!AuthController.DeleteCustomer(customer.Id))
                            MessageBox.Show("Delete failed.");
                        else
                            LoadCustomers();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a customer to delete.");
            }
        }

        private void LoadAdmins()
        {
            adminsGridView.AutoGenerateColumns = false;
            adminsGridView.Columns.Clear();

            adminsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name"
            });
            adminsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email"
            });
            adminsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CreatedAt",
                HeaderText = "Registered"
            });
            adminsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Role",
                HeaderText = "Role"
            });

            var admins = AuthController.GetAllAdmins();
            adminsGridView.DataSource = new BindingList<Admin>(admins);
        }

        private void editABtn_Click(object sender, EventArgs e)
        {
            if (adminsGridView.SelectedRows.Count > 0)
            {
                var admin = adminsGridView.SelectedRows[0].DataBoundItem as Admin;
                if (admin != null)
                {
                    var updateAdminForm = new UpdateAdminForm(admin);
                    if (updateAdminForm.ShowDialog() == DialogResult.OK)
                        LoadAdmins();
                }
            }
            else
            {
                MessageBox.Show("Select an admin to edit.");
            }
        }

        private void addABtn_Click(object sender, EventArgs e)
        {
            var registerAdminForm = new RegisterAdminForm(); // Your form for admin registration
            if (registerAdminForm.ShowDialog() == DialogResult.OK)
                LoadAdmins();
        }

        private void deleteABtn_Click(object sender, EventArgs e)
        {
            var admins = adminsGridView.DataSource as BindingList<Admin>;
            if (adminsGridView.SelectedRows.Count > 0)
            {
                var admin = adminsGridView.SelectedRows[0].DataBoundItem as Admin;
                if (admin != null)
                {
                    if (admins.Count <= 1)
                    {
                        MessageBox.Show("At least one admin must remain.");
                        return;
                    }

                    var result = MessageBox.Show($"Delete admin '{admin.Name}'?", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (!AuthController.DeleteAdmin(admin.Id))
                            MessageBox.Show("Delete failed.");
                        else
                            LoadAdmins();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select an admin to delete.");
            }
        }

        private void logoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AuthController.Logout();

            MessageBox.Show("Logged out successfully.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.Restart();
        }
    }
}
