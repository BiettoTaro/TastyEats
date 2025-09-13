using System;
using System.Windows.Forms;
using TastyEats.Controllers;
using TastyEats.Views;

namespace TastyEats
{
    public class BaseForm : Form
    {
        protected NavbarControl navbarControl1;
        protected bool userIsActive = false; 


        public BaseForm()
        {
            // Initialize and add navbar
            navbarControl1 = new NavbarControl();
            navbarControl1.Dock = DockStyle.Top;
            this.Controls.Add(navbarControl1);

            
            navbarControl1.HomeClicked += (s, e) => NavigateTo(typeof(HomeForm));
            navbarControl1.MenuClicked += (s, e) => NavigateTo(typeof(MenuForm));
            navbarControl1.CartClicked += (s, e) => NavigateTo(typeof(CartForm));
            navbarControl1.LoginClicked += NavbarControl_LoginClicked;
        }

        public void SetLoginStatus(bool isLoggedIn)
        {
            userIsActive = isLoggedIn;
            navbarControl1.IsLoggedIn = isLoggedIn;
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            userIsActive = AuthController.IsLoggedIn; // Check if user is logged in
            navbarControl1.IsLoggedIn = userIsActive; // Update navbar state
           
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            navbarControl1.SetAccountLink(AuthController.IsLoggedIn && AuthController.CurrentUser != null
                ? AuthController.CurrentUser.Name
                : null
                );
        }

        // Method to navigate to a different form
        protected virtual void NavigateTo(Type formType)
        {

            if (this.GetType() == formType)
                return; // Don't reopen the current form

            // Create the new form dynamically
            Form form = (Form)Activator.CreateInstance(formType);
            form.FormClosed += (s, e) => this.Close();
            form.Show();
            this.Hide(); // or this.Close(), depending on desired behavior
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // BaseForm
            // 
            ClientSize = new Size(1984, 473);
            Name = "BaseForm";
            ResumeLayout(false);

        }

        protected virtual void NavbarControl_LoginClicked(object sender, EventArgs e)
        {
            if (!userIsActive)
            {
                var loginForm = new LoginForm(this);
                loginForm.Show();
                this.Hide(); // Hide the current form while login is open
            }
            else
            {
                var result = MessageBox.Show(
                    "Are you sure you want to log out?",
                    "Confirm Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    AuthController.Logout(); // Call the logout method from AuthController
                    userIsActive = false;
                    navbarControl1.IsLoggedIn = false;

                    // Restart the application to reset state
                    Application.Restart();

                }
            }
        }
    }
}
