namespace TastyEats.Views
{
    partial class RegisterAdminForm
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
            label6 = new Label();
            label5 = new Label();
            label2 = new Label();
            emailLbl = new Label();
            nameBox = new TextBox();
            confirmPasswordBox = new TextBox();
            registerBtn = new Button();
            passwordBox = new TextBox();
            emailBox = new TextBox();
            label1 = new Label();
            backBtn = new Button();
            label3 = new Label();
            roleComboBox = new ComboBox();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.Location = new Point(57, 272);
            label6.Name = "label6";
            label6.Size = new Size(138, 16);
            label6.TabIndex = 42;
            label6.Text = "Confirm Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(57, 234);
            label5.Name = "label5";
            label5.Size = new Size(77, 16);
            label5.TabIndex = 41;
            label5.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(57, 136);
            label2.Name = "label2";
            label2.Size = new Size(78, 16);
            label2.TabIndex = 38;
            label2.Text = "Full Name";
            // 
            // emailLbl
            // 
            emailLbl.AutoSize = true;
            emailLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            emailLbl.Location = new Point(57, 91);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(47, 16);
            emailLbl.TabIndex = 37;
            emailLbl.Text = "Email";
            // 
            // nameBox
            // 
            nameBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameBox.Location = new Point(201, 130);
            nameBox.Name = "nameBox";
            nameBox.PlaceholderText = "Enter your name";
            nameBox.Size = new Size(151, 22);
            nameBox.TabIndex = 30;
            // 
            // confirmPasswordBox
            // 
            confirmPasswordBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmPasswordBox.Location = new Point(201, 266);
            confirmPasswordBox.Name = "confirmPasswordBox";
            confirmPasswordBox.PlaceholderText = "Confirm Password";
            confirmPasswordBox.Size = new Size(151, 22);
            confirmPasswordBox.TabIndex = 34;
            confirmPasswordBox.UseSystemPasswordChar = true;
            // 
            // registerBtn
            // 
            registerBtn.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            registerBtn.Location = new Point(201, 307);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(151, 23);
            registerBtn.TabIndex = 35;
            registerBtn.Text = "Register";
            registerBtn.UseVisualStyleBackColor = true;
            registerBtn.Click += registerBtn_Click;
            // 
            // passwordBox
            // 
            passwordBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordBox.Location = new Point(201, 228);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "Create a Password";
            passwordBox.Size = new Size(151, 22);
            passwordBox.TabIndex = 33;
            passwordBox.UseSystemPasswordChar = true;
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailBox.Location = new Point(201, 89);
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "Enter your email";
            emailBox.Size = new Size(151, 22);
            emailBox.TabIndex = 29;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Script", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(123, 27);
            label1.Name = "label1";
            label1.Size = new Size(147, 40);
            label1.TabIndex = 36;
            label1.Text = "Tasty Eats";
            // 
            // backBtn
            // 
            backBtn.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backBtn.Location = new Point(57, 307);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(35, 23);
            backBtn.TabIndex = 43;
            backBtn.Text = "⬅";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(57, 180);
            label3.Name = "label3";
            label3.Size = new Size(39, 16);
            label3.TabIndex = 44;
            label3.Text = "Role";
            // 
            // roleComboBox
            // 
            roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Location = new Point(201, 178);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(151, 23);
            roleComboBox.TabIndex = 45;
            // 
            // RegisterAdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 372);
            Controls.Add(roleComboBox);
            Controls.Add(label3);
            Controls.Add(backBtn);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(emailLbl);
            Controls.Add(nameBox);
            Controls.Add(confirmPasswordBox);
            Controls.Add(registerBtn);
            Controls.Add(passwordBox);
            Controls.Add(emailBox);
            Controls.Add(label1);
            Name = "RegisterAdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterAdminForm";
            Load += RegisterAdminForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label5;
        private Label label2;
        private Label emailLbl;
        private TextBox nameBox;
        private TextBox confirmPasswordBox;
        private Button registerBtn;
        private TextBox passwordBox;
        private TextBox emailBox;
        private Label label1;
        private Button backBtn;
        private Label label3;
        private ComboBox roleComboBox;
    }
}