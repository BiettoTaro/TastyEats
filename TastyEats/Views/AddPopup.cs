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
    public partial class AddPopup : Form
    {
        private int itemId;
        public int Quantity => (int)quantitySelector.Value;
        public string Notes => modifications.Text;
        private decimal unitPrice;
        public Models.CartItem CreatedItem { get; private set; }
        public AddPopup(string itemName, Image itemImage, decimal price, int itemId)
        {
            InitializeComponent();

            this.unitPrice = price;
            this.itemId = itemId;

            nameLabel.Text = itemName;
            dishImage.Image = itemImage;

            updateTotal();
            quantitySelector.ValueChanged += (s, e) => updateTotal();
        }

        private void updateTotal()
        {
            decimal total = unitPrice * Quantity;
            totalLabel.Text = $"Total: £{total:F2}";
        }

        private void quantitySelector_ValueChanged(object sender, EventArgs e)
        {
            updateTotal();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen borderPen = new Pen(Color.Gray, 2))
            {
                Rectangle rect = this.ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(borderPen, rect);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            CreatedItem = new Models.CartItem
            {
                ItemId = itemId,
                Name = nameLabel.Text,
                Price = unitPrice,
                Quantity = Quantity,
                Notes = Notes
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
