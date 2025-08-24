namespace TastyEats.Views
{
    partial class UpdateAdminForm
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
            oldPassLbl = new Label();
            oldPassBox = new TextBox();
            confPassLbl = new Label();
            confPassBox = new TextBox();
            newPassLbl = new Label();
            updateBtn = new Button();
            newPassBox = new TextBox();
            emailBox = new TextBox();
            emailLbl = new Label();
            nameBox = new TextBox();
            fullNameLbl = new Label();
            backBtn = new Button();
            SuspendLayout();
            // 
            // oldPassLbl
            // 
            oldPassLbl.AutoSize = true;
            oldPassLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            oldPassLbl.Location = new Point(30, 248);
            oldPassLbl.Name = "oldPassLbl";
            oldPassLbl.Size = new Size(105, 16);
            oldPassLbl.TabIndex = 58;
            oldPassLbl.Text = "Old Password";
            // 
            // oldPassBox
            // 
            oldPassBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            oldPassBox.Location = new Point(191, 245);
            oldPassBox.Name = "oldPassBox";
            oldPassBox.Size = new Size(187, 23);
            oldPassBox.TabIndex = 57;
            oldPassBox.UseSystemPasswordChar = true;
            // 
            // confPassLbl
            // 
            confPassLbl.AutoSize = true;
            confPassLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            confPassLbl.Location = new Point(30, 200);
            confPassLbl.Name = "confPassLbl";
            confPassLbl.Size = new Size(138, 16);
            confPassLbl.TabIndex = 56;
            confPassLbl.Text = "Confirm Password";
            // 
            // confPassBox
            // 
            confPassBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confPassBox.Location = new Point(191, 197);
            confPassBox.Name = "confPassBox";
            confPassBox.Size = new Size(187, 23);
            confPassBox.TabIndex = 55;
            confPassBox.UseSystemPasswordChar = true;
            // 
            // newPassLbl
            // 
            newPassLbl.AutoSize = true;
            newPassLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            newPassLbl.Location = new Point(30, 151);
            newPassLbl.Name = "newPassLbl";
            newPassLbl.Size = new Size(112, 16);
            newPassLbl.TabIndex = 54;
            newPassLbl.Text = "New Password";
            // 
            // updateBtn
            // 
            updateBtn.BackColor = Color.FromArgb(0, 192, 0);
            updateBtn.FlatStyle = FlatStyle.Popup;
            updateBtn.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            updateBtn.Location = new Point(257, 328);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(121, 34);
            updateBtn.TabIndex = 50;
            updateBtn.Text = "UPDATE";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtn_Click;
            // 
            // newPassBox
            // 
            newPassBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newPassBox.Location = new Point(191, 148);
            newPassBox.Name = "newPassBox";
            newPassBox.Size = new Size(187, 23);
            newPassBox.TabIndex = 49;
            newPassBox.UseSystemPasswordChar = true;
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailBox.Location = new Point(191, 97);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(187, 23);
            emailBox.TabIndex = 47;
            // 
            // emailLbl
            // 
            emailLbl.AutoSize = true;
            emailLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            emailLbl.Location = new Point(30, 104);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(47, 16);
            emailLbl.TabIndex = 46;
            emailLbl.Text = "Email";
            // 
            // nameBox
            // 
            nameBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameBox.Location = new Point(191, 48);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(187, 23);
            nameBox.TabIndex = 44;
            // 
            // fullNameLbl
            // 
            fullNameLbl.AutoSize = true;
            fullNameLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            fullNameLbl.Location = new Point(30, 51);
            fullNameLbl.Name = "fullNameLbl";
            fullNameLbl.Size = new Size(78, 16);
            fullNameLbl.TabIndex = 43;
            fullNameLbl.Text = "Full Name";
            // 
            // backBtn
            // 
            backBtn.BackColor = Color.FromArgb(0, 192, 192);
            backBtn.FlatStyle = FlatStyle.Popup;
            backBtn.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backBtn.Location = new Point(30, 328);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(47, 34);
            backBtn.TabIndex = 59;
            backBtn.Text = "⬅";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += backBtn_Click;
            // 
            // UpdateAdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 399);
            Controls.Add(backBtn);
            Controls.Add(oldPassLbl);
            Controls.Add(oldPassBox);
            Controls.Add(confPassLbl);
            Controls.Add(confPassBox);
            Controls.Add(newPassLbl);
            Controls.Add(updateBtn);
            Controls.Add(newPassBox);
            Controls.Add(emailBox);
            Controls.Add(emailLbl);
            Controls.Add(nameBox);
            Controls.Add(fullNameLbl);
            Name = "UpdateAdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdateAdminForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label oldPassLbl;
        private TextBox oldPassBox;
        private Label confPassLbl;
        private TextBox confPassBox;
        private Label newPassLbl;
        private Button updateBtn;
        private TextBox newPassBox;
        private TextBox emailBox;
        private Label emailLbl;
        private TextBox nameBox;
        private Label fullNameLbl;
        private Button backBtn;
    }
}