using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TastyEats.Controllers;
using TastyEats.Models;


namespace TastyEats.Views
{
    public partial class CheckoutForm : Form
    {
        User user = AuthController.CurrentUser;

        public CheckoutForm()
        {
            InitializeComponent();
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            nameBox.Text = user?.Name ?? string.Empty;
            emailBox.Text = user?.Email ?? string.Empty;
            addressBox.Text = user is Customer customer ? customer.Address : string.Empty;
            cardNameBox.Text = user?.Name ?? string.Empty;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            var cartForm = new CartForm();
            cartForm.Show();
            this.Close();

        }

        private void cardNumberBox_Validating(object sender, CancelEventArgs e)
        {
            // Regex for 16 digit number, allowing spaces or dashes
            string pattern = @"^(?:\d{4}[- ]?){3}\d{4}$";
            if (!Regex.IsMatch(cardNumberBox.Text, pattern))
            {
                errorProvider1.SetError(cardNumberBox, "Enter a valid 16 digit number.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cardNumberBox, "");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bool isCash = radioButton1.Checked;
            cardNameBox.Enabled = !isCash;
            cardNumberBox.Enabled = !isCash;
            //expiryDateBox.Enabled = !isCash;
            //cvvBox.Enabled = !isCash;
        }

       
    }
}
