using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TastyEats.Views
{
    public partial class NavbarControl : UserControl
    {
        public event EventHandler HomeClicked;
        public event EventHandler MenuClicked;
        public event EventHandler CartClicked;
        public event EventHandler LoginClicked;
        public NavbarControl()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.SystemColors.Info;
        }

        private void homeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HomeClicked?.Invoke(this, EventArgs.Empty);
        }

        private void menuLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MenuClicked?.Invoke(this, EventArgs.Empty);
        }

        private void cartLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CartClicked?.Invoke(this, EventArgs.Empty);
        }

        private void logLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginClicked?.Invoke(this, EventArgs.Empty);
        }

        public void SetAccountLink(string? username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                accountLink.Text = $"🧑 {username}";
                accountLink.Visible = true;
            }
            else
            {
                accountLink.Visible = false;
            }
        }
        private void accountLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new ManageAccountForm();
            form.ShowDialog();
        }

        public bool IsLoggedIn
        {
            get => logLink.Text == "Logout";
            set
            {
                logLink.Text = value ? "Logout" : "Login";
            }

        }
    }
}
