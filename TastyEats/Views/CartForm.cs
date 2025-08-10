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
            cartPanel.SuspendLayout();
            cartPanel.Controls.Clear();

            foreach (var item in Controllers.CartController.GetItems())
            {
                var row = new Panel
                {
                    Width = cartPanel.ClientSize.Width - 30,
                    Height = 90, // increased to make space for notes field
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

                // Notes TextBox
                var txtNotes = new TextBox
                {
                    Text = item.Notes ?? string.Empty,
                    Location = new Point(10, 60),
                    Width = 300,
                    Height = 20
                };
                txtNotes.TextChanged += (s, e) =>
                {
                    Controllers.CartController.UpdateLine(item.LineId, (int)numQty.Value, txtNotes.Text);
                };

                // Remove Button
                var btnRemove = new Button
                {
                    Text = (item.Quantity > 1) ? "Remove One" : "Remove",
                    Location = new Point(320, 8),
                    Size = new Size(90, 28)
                };
                btnRemove.Click += (s, e) =>
                {
                    if (numQty.Value > 1)
                        Controllers.CartController.RemoveOne(item.LineId);
                    else
                        Controllers.CartController.RemoveLine(item.LineId);

                    LoadCartItems();
                };

                // Live update on quantity change
                numQty.ValueChanged += (s, e) =>
                {
                    lblLineTotal.Text = $"Line: £{(item.Price * (int)numQty.Value):F2}";
                    btnRemove.Text = (numQty.Value > 1) ? "Remove One" : "Remove";

                    Controllers.CartController.UpdateLine(item.LineId, (int)numQty.Value, txtNotes.Text);
                    totalLabel.Text = $"Total: £{Controllers.CartController.GetTotalPrice():F2}";
                };

                row.Controls.Add(lblName);
                row.Controls.Add(lblUnit);
                row.Controls.Add(numQty);
                row.Controls.Add(lblLineTotal);
                row.Controls.Add(btnRemove);
                row.Controls.Add(txtNotes);

                cartPanel.Controls.Add(row);
            }

            totalLabel.Text = $"Total: £{Controllers.CartController.GetTotalPrice():F2}";


            totalLabel.Text = $"Total: £{Controllers.CartController.GetTotalPrice():F2}";


            totalLabel.Text = $"Total: £{Controllers.CartController.GetTotalPrice():F2}";
            cartPanel.ResumeLayout();
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
