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
            emailLbl = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // registerBtn
            // 
            registerBtn.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            registerBtn.Location = new Point(114, 323);
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
            passwordBox.Location = new Point(192, 241);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "Create a Password";
            passwordBox.Size = new Size(151, 22);
            passwordBox.TabIndex = 4;
            passwordBox.UseSystemPasswordChar = true;
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailBox.Location = new Point(192, 71);
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "Enter your email";
            emailBox.Size = new Size(151, 22);
            emailBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Script", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(114, 9);
            label1.Name = "label1";
            label1.Size = new Size(147, 40);
            label1.TabIndex = 7;
            label1.Text = "Tasty Eats";
            // 
            // confirmPasswordBox
            // 
            confirmPasswordBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmPasswordBox.Location = new Point(192, 279);
            confirmPasswordBox.Name = "confirmPasswordBox";
            confirmPasswordBox.PlaceholderText = "Confirm Password";
            confirmPasswordBox.Size = new Size(151, 22);
            confirmPasswordBox.TabIndex = 5;
            confirmPasswordBox.UseSystemPasswordChar = true;
            // 
            // nameBox
            // 
            nameBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameBox.Location = new Point(192, 112);
            nameBox.Name = "nameBox";
            nameBox.PlaceholderText = "Enter your name";
            nameBox.Size = new Size(151, 22);
            nameBox.TabIndex = 1;
            // 
            // phoneBox
            // 
            phoneBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            phoneBox.Location = new Point(192, 155);
            phoneBox.Name = "phoneBox";
            phoneBox.PlaceholderText = "phone number";
            phoneBox.Size = new Size(151, 22);
            phoneBox.TabIndex = 2;
            // 
            // addressBox
            // 
            addressBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addressBox.Location = new Point(192, 198);
            addressBox.Name = "addressBox";
            addressBox.PlaceholderText = "Enter your address";
            addressBox.Size = new Size(151, 22);
            addressBox.TabIndex = 3;
            // 
            // emailLbl
            // 
            emailLbl.AutoSize = true;
            emailLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            emailLbl.Location = new Point(48, 73);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(47, 16);
            emailLbl.TabIndex = 23;
            emailLbl.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(48, 118);
            label2.Name = "label2";
            label2.Size = new Size(78, 16);
            label2.TabIndex = 24;
            label2.Text = "Full Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(48, 157);
            label3.Name = "label3";
            label3.Size = new Size(75, 16);
            label3.TabIndex = 25;
            label3.Text = "Phone No";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(48, 204);
            label4.Name = "label4";
            label4.Size = new Size(65, 16);
            label4.TabIndex = 26;
            label4.Text = "Address";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(48, 247);
            label5.Name = "label5";
            label5.Size = new Size(77, 16);
            label5.TabIndex = 27;
            label5.Text = "Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(48, 285);
            label6.Name = "label6";
            label6.Size = new Size(138, 16);
            label6.TabIndex = 28;
            label6.Text = "Confirm Password";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 358);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(emailLbl);
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
            Text = "Register";
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
        private Label emailLbl;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}