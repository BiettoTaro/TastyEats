namespace TastyEats.Views
{
    partial class ManageAccountForm
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
            deleteBtn = new Button();
            updateBtn = new Button();
            newPassBox = new TextBox();
            addressBox = new RichTextBox();
            emailBox = new TextBox();
            emailLbl = new Label();
            addressLbl = new Label();
            nameBox = new TextBox();
            fullNameLbl = new Label();
            phoneBox = new TextBox();
            phoneLbl = new Label();
            newPassLbl = new Label();
            confPassLbl = new Label();
            confPassBox = new TextBox();
            oldPassLbl = new Label();
            oldPassBox = new TextBox();
            SuspendLayout();
            // 
            // navbarControl1
            // 
            navbarControl1.Size = new Size(800, 40);
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = Color.Red;
            deleteBtn.FlatStyle = FlatStyle.Popup;
            deleteBtn.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteBtn.Location = new Point(114, 391);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(187, 34);
            deleteBtn.TabIndex = 35;
            deleteBtn.Text = "DELETE ACCOUNT";
            deleteBtn.UseVisualStyleBackColor = false;
            // 
            // updateBtn
            // 
            updateBtn.BackColor = Color.FromArgb(0, 192, 0);
            updateBtn.FlatStyle = FlatStyle.Popup;
            updateBtn.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            updateBtn.Location = new Point(534, 391);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(187, 34);
            updateBtn.TabIndex = 34;
            updateBtn.Text = "UPDATE";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtn_Click;
            // 
            // newPassBox
            // 
            newPassBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newPassBox.Location = new Point(534, 101);
            newPassBox.Name = "newPassBox";
            newPassBox.Size = new Size(187, 23);
            newPassBox.TabIndex = 28;
            // 
            // addressBox
            // 
            addressBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addressBox.Location = new Point(114, 239);
            addressBox.Name = "addressBox";
            addressBox.Size = new Size(187, 96);
            addressBox.TabIndex = 24;
            addressBox.Text = "";
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailBox.Location = new Point(114, 150);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(187, 23);
            emailBox.TabIndex = 23;
            // 
            // emailLbl
            // 
            emailLbl.AutoSize = true;
            emailLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            emailLbl.Location = new Point(12, 157);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(47, 16);
            emailLbl.TabIndex = 22;
            emailLbl.Text = "Email";
            // 
            // addressLbl
            // 
            addressLbl.AutoSize = true;
            addressLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            addressLbl.Location = new Point(12, 239);
            addressLbl.Name = "addressLbl";
            addressLbl.Size = new Size(65, 16);
            addressLbl.TabIndex = 21;
            addressLbl.Text = "Address";
            // 
            // nameBox
            // 
            nameBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameBox.Location = new Point(114, 101);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(187, 23);
            nameBox.TabIndex = 20;
            // 
            // fullNameLbl
            // 
            fullNameLbl.AutoSize = true;
            fullNameLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            fullNameLbl.Location = new Point(12, 104);
            fullNameLbl.Name = "fullNameLbl";
            fullNameLbl.Size = new Size(78, 16);
            fullNameLbl.TabIndex = 19;
            fullNameLbl.Text = "Full Name";
            // 
            // phoneBox
            // 
            phoneBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            phoneBox.Location = new Point(114, 191);
            phoneBox.Name = "phoneBox";
            phoneBox.Size = new Size(187, 23);
            phoneBox.TabIndex = 37;
            // 
            // phoneLbl
            // 
            phoneLbl.AutoSize = true;
            phoneLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            phoneLbl.Location = new Point(12, 198);
            phoneLbl.Name = "phoneLbl";
            phoneLbl.Size = new Size(75, 16);
            phoneLbl.TabIndex = 36;
            phoneLbl.Text = "Phone No";
            // 
            // newPassLbl
            // 
            newPassLbl.AutoSize = true;
            newPassLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            newPassLbl.Location = new Point(373, 104);
            newPassLbl.Name = "newPassLbl";
            newPassLbl.Size = new Size(112, 16);
            newPassLbl.TabIndex = 38;
            newPassLbl.Text = "New Password";
            // 
            // confPassLbl
            // 
            confPassLbl.AutoSize = true;
            confPassLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            confPassLbl.Location = new Point(373, 153);
            confPassLbl.Name = "confPassLbl";
            confPassLbl.Size = new Size(138, 16);
            confPassLbl.TabIndex = 40;
            confPassLbl.Text = "Confirm Password";
            // 
            // confPassBox
            // 
            confPassBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confPassBox.Location = new Point(534, 150);
            confPassBox.Name = "confPassBox";
            confPassBox.Size = new Size(187, 23);
            confPassBox.TabIndex = 39;
            // 
            // oldPassLbl
            // 
            oldPassLbl.AutoSize = true;
            oldPassLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            oldPassLbl.Location = new Point(373, 201);
            oldPassLbl.Name = "oldPassLbl";
            oldPassLbl.Size = new Size(105, 16);
            oldPassLbl.TabIndex = 42;
            oldPassLbl.Text = "Old Password";
            // 
            // oldPassBox
            // 
            oldPassBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            oldPassBox.Location = new Point(534, 198);
            oldPassBox.Name = "oldPassBox";
            oldPassBox.Size = new Size(187, 23);
            oldPassBox.TabIndex = 41;
            // 
            // ManageAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(oldPassLbl);
            Controls.Add(oldPassBox);
            Controls.Add(confPassLbl);
            Controls.Add(confPassBox);
            Controls.Add(newPassLbl);
            Controls.Add(phoneBox);
            Controls.Add(phoneLbl);
            Controls.Add(deleteBtn);
            Controls.Add(updateBtn);
            Controls.Add(newPassBox);
            Controls.Add(addressBox);
            Controls.Add(emailBox);
            Controls.Add(emailLbl);
            Controls.Add(addressLbl);
            Controls.Add(nameBox);
            Controls.Add(fullNameLbl);
            Name = "ManageAccountForm";
            Text = "ManageAccountForm";
            Load += ManageAccountForm_Load;
            Controls.SetChildIndex(navbarControl1, 0);
            Controls.SetChildIndex(fullNameLbl, 0);
            Controls.SetChildIndex(nameBox, 0);
            Controls.SetChildIndex(addressLbl, 0);
            Controls.SetChildIndex(emailLbl, 0);
            Controls.SetChildIndex(emailBox, 0);
            Controls.SetChildIndex(addressBox, 0);
            Controls.SetChildIndex(newPassBox, 0);
            Controls.SetChildIndex(updateBtn, 0);
            Controls.SetChildIndex(deleteBtn, 0);
            Controls.SetChildIndex(phoneLbl, 0);
            Controls.SetChildIndex(phoneBox, 0);
            Controls.SetChildIndex(newPassLbl, 0);
            Controls.SetChildIndex(confPassBox, 0);
            Controls.SetChildIndex(confPassLbl, 0);
            Controls.SetChildIndex(oldPassBox, 0);
            Controls.SetChildIndex(oldPassLbl, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button deleteBtn;
        private Button updateBtn;
        private TextBox newPassBox;
        private RichTextBox addressBox;
        private TextBox emailBox;
        private Label emailLbl;
        private Label addressLbl;
        private TextBox nameBox;
        private Label fullNameLbl;
        private TextBox phoneBox;
        private Label phoneLbl;
        private Label newPassLbl;
        private Label confPassLbl;
        private TextBox confPassBox;
        private Label oldPassLbl;
        private TextBox oldPassBox;
    }
}