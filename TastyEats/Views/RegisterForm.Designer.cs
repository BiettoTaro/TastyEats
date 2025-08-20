namespace TastyEats.Views
{
    partial class RegisterForm
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
            registerBtn = new Button();
            passwordBox = new TextBox();
            emailBox = new TextBox();
            label1 = new Label();
            confirmPasswordBox = new TextBox();
            nameBox = new TextBox();
            phoneBox = new TextBox();
            addressBox = new TextBox();
            SuspendLayout();
            // 
            // registerBtn
            // 
            registerBtn.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            registerBtn.Location = new Point(83, 323);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(151, 23);
            registerBtn.TabIndex = 6;
            registerBtn.Text = "Register";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
            // 
            // passwordBox
            // 
            passwordBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordBox.Location = new Point(83, 241);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "Create a Password";
            passwordBox.Size = new Size(151, 22);
            passwordBox.TabIndex = 4;
            passwordBox.UseSystemPasswordChar = true;
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailBox.Location = new Point(83, 71);
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "Enter your email";
            emailBox.Size = new Size(151, 22);
            emailBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(83, 9);
            label1.Name = "label1";
            label1.Size = new Size(151, 29);
            label1.TabIndex = 7;
            label1.Text = "Tasty Eats";
            // 
            // confirmPasswordBox
            // 
            confirmPasswordBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmPasswordBox.Location = new Point(83, 279);
            confirmPasswordBox.Name = "confirmPasswordBox";
            confirmPasswordBox.PlaceholderText = "Confirm Password";
            confirmPasswordBox.Size = new Size(151, 22);
            confirmPasswordBox.TabIndex = 5;
            confirmPasswordBox.UseSystemPasswordChar = true;
            // 
            // nameBox
            // 
            nameBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameBox.Location = new Point(83, 112);
            nameBox.Name = "nameBox";
            nameBox.PlaceholderText = "Enter your name";
            nameBox.Size = new Size(151, 22);
            nameBox.TabIndex = 1;
            // 
            // phoneBox
            // 
            phoneBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            phoneBox.Location = new Point(83, 155);
            phoneBox.Name = "phoneBox";
            phoneBox.PlaceholderText = "phone number";
            phoneBox.Size = new Size(151, 22);
            phoneBox.TabIndex = 2;
            // 
            // addressBox
            // 
            addressBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addressBox.Location = new Point(83, 198);
            addressBox.Name = "addressBox";
            addressBox.PlaceholderText = "Enter your address";
            addressBox.Size = new Size(151, 22);
            addressBox.TabIndex = 3;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 358);
            Controls.Add(addressBox);
            Controls.Add(phoneBox);
            Controls.Add(nameBox);
            Controls.Add(confirmPasswordBox);
            Controls.Add(registerBtn);
            Controls.Add(passwordBox);
            Controls.Add(emailBox);
            Controls.Add(label1);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button registerBtn;
        private TextBox passwordBox;
        private TextBox emailBox;
        private Label label1;
        private TextBox confirmPasswordBox;
        private TextBox nameBox;
        private TextBox phoneBox;
        private TextBox addressBox;
    }
}