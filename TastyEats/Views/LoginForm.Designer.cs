namespace TastyEats.Views
{
    partial class LoginForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            emailBox = new TextBox();
            passwordBox = new TextBox();
            loginBtn = new Button();
            signUpLink = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(73, 38);
            label1.Name = "label1";
            label1.Size = new Size(151, 29);
            label1.TabIndex = 0;
            label1.Text = "Tasty Eats";
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailBox.Location = new Point(73, 149);
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "Enter your email";
            emailBox.Size = new Size(151, 22);
            emailBox.TabIndex = 1;
            // 
            // passwordBox
            // 
            passwordBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordBox.Location = new Point(73, 193);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "Enter your password";
            passwordBox.Size = new Size(151, 22);
            passwordBox.TabIndex = 2;
            passwordBox.UseSystemPasswordChar = true;
            passwordBox.TextChanged += passwordBox_TextChanged;
            // 
            // loginBtn
            // 
            loginBtn.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginBtn.Location = new Point(73, 253);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(151, 23);
            loginBtn.TabIndex = 3;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // signUpLink
            // 
            signUpLink.AutoSize = true;
            signUpLink.Location = new Point(122, 296);
            signUpLink.Name = "signUpLink";
            signUpLink.Size = new Size(48, 15);
            signUpLink.TabIndex = 4;
            signUpLink.TabStop = true;
            signUpLink.Text = "Sign Up";
            signUpLink.LinkClicked += signUpLink_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 355);
            Controls.Add(signUpLink);
            Controls.Add(loginBtn);
            Controls.Add(passwordBox);
            Controls.Add(emailBox);
            Controls.Add(label1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "]";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox emailBox;
        private TextBox passwordBox;
        private Button loginBtn;
        private LinkLabel signUpLink;
    }
}