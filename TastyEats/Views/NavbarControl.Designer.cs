namespace TastyEats.Views
{
    partial class NavbarControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            menuLink = new LinkLabel();
            homeLink = new LinkLabel();
            cartLink = new LinkLabel();
            logLink = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Script", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(93, 27);
            label1.TabIndex = 0;
            label1.Text = "TastyEats";
            // 
            // menuLink
            // 
            menuLink.AutoSize = true;
            menuLink.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuLink.Location = new Point(381, 13);
            menuLink.Name = "menuLink";
            menuLink.Size = new Size(41, 14);
            menuLink.TabIndex = 1;
            menuLink.TabStop = true;
            menuLink.Text = "Menu";
            menuLink.LinkClicked += menuLink_LinkClicked;
            // 
            // homeLink
            // 
            homeLink.AutoSize = true;
            homeLink.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeLink.Location = new Point(307, 13);
            homeLink.Name = "homeLink";
            homeLink.Size = new Size(43, 14);
            homeLink.TabIndex = 2;
            homeLink.TabStop = true;
            homeLink.Text = "Home";
            homeLink.LinkClicked += homeLink_LinkClicked;
            // 
            // cartLink
            // 
            cartLink.AutoSize = true;
            cartLink.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cartLink.Location = new Point(443, 13);
            cartLink.Name = "cartLink";
            cartLink.Size = new Size(52, 14);
            cartLink.TabIndex = 3;
            cartLink.TabStop = true;
            cartLink.Text = "\U0001f6d2 Cart";
            cartLink.LinkClicked += cartLink_LinkClicked;
            // 
            // logLink
            // 
            logLink.AutoSize = true;
            logLink.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logLink.Location = new Point(527, 13);
            logLink.Name = "logLink";
            logLink.Size = new Size(67, 14);
            logLink.TabIndex = 4;
            logLink.TabStop = true;
            logLink.Text = "Login/out";
            logLink.LinkClicked += logLink_LinkClicked;
            // 
            // NavbarControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(logLink);
            Controls.Add(cartLink);
            Controls.Add(homeLink);
            Controls.Add(menuLink);
            Controls.Add(label1);
            Name = "NavbarControl";
            Size = new Size(599, 40);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private Label label1;
        private LinkLabel menuLink;
        private LinkLabel homeLink;
        private LinkLabel cartLink;
        private LinkLabel logLink;
    }
}
