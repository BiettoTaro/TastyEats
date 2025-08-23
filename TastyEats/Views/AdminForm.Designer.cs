namespace TastyEats.Views
{
    partial class AdminForm
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
            adminTab = new TabControl();
            ordersTab = new TabPage();
            usersTab = new TabPage();
            adminsTab = new TabPage();
            menuTab = new TabPage();
            deleteBtn = new Button();
            addMenuBtn = new Button();
            menuItemsGridView = new DataGridView();
            confirmBtn = new Button();
            adminTab.SuspendLayout();
            menuTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)menuItemsGridView).BeginInit();
            SuspendLayout();
            // 
            // adminTab
            // 
            adminTab.Controls.Add(ordersTab);
            adminTab.Controls.Add(usersTab);
            adminTab.Controls.Add(adminsTab);
            adminTab.Controls.Add(menuTab);
            adminTab.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            adminTab.Location = new Point(0, 0);
            adminTab.Name = "adminTab";
            adminTab.SelectedIndex = 0;
            adminTab.Size = new Size(799, 413);
            adminTab.TabIndex = 0;
            // 
            // ordersTab
            // 
            ordersTab.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ordersTab.Location = new Point(4, 23);
            ordersTab.Name = "ordersTab";
            ordersTab.Size = new Size(791, 386);
            ordersTab.TabIndex = 0;
            ordersTab.Text = "Orders";
            ordersTab.UseVisualStyleBackColor = true;
            // 
            // usersTab
            // 
            usersTab.Location = new Point(4, 23);
            usersTab.Name = "usersTab";
            usersTab.Padding = new Padding(3);
            usersTab.Size = new Size(791, 386);
            usersTab.TabIndex = 1;
            usersTab.Text = "Users";
            usersTab.UseVisualStyleBackColor = true;
            // 
            // adminsTab
            // 
            adminsTab.Location = new Point(4, 23);
            adminsTab.Name = "adminsTab";
            adminsTab.Padding = new Padding(3);
            adminsTab.Size = new Size(791, 386);
            adminsTab.TabIndex = 2;
            adminsTab.Text = "Admins";
            adminsTab.UseVisualStyleBackColor = true;
            // 
            // menuTab
            // 
            menuTab.Controls.Add(confirmBtn);
            menuTab.Controls.Add(deleteBtn);
            menuTab.Controls.Add(addMenuBtn);
            menuTab.Controls.Add(menuItemsGridView);
            menuTab.Location = new Point(4, 23);
            menuTab.Name = "menuTab";
            menuTab.Padding = new Padding(3);
            menuTab.Size = new Size(791, 386);
            menuTab.TabIndex = 3;
            menuTab.Text = "Menu";
            menuTab.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = Color.Red;
            deleteBtn.BackgroundImageLayout = ImageLayout.None;
            deleteBtn.FlatStyle = FlatStyle.Popup;
            deleteBtn.ForeColor = SystemColors.Control;
            deleteBtn.Location = new Point(724, 357);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(27, 23);
            deleteBtn.TabIndex = 2;
            deleteBtn.Text = "🗑️";
            deleteBtn.UseVisualStyleBackColor = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // addMenuBtn
            // 
            addMenuBtn.Location = new Point(767, 357);
            addMenuBtn.Name = "addMenuBtn";
            addMenuBtn.Size = new Size(18, 23);
            addMenuBtn.TabIndex = 1;
            addMenuBtn.Text = "+";
            addMenuBtn.UseVisualStyleBackColor = true;
            addMenuBtn.Click += addMenuBtn_Click;
            // 
            // menuItemsGridView
            // 
            menuItemsGridView.AllowUserToAddRows = false;
            menuItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            menuItemsGridView.Location = new Point(0, 0);
            menuItemsGridView.Name = "menuItemsGridView";
            menuItemsGridView.Size = new Size(791, 355);
            menuItemsGridView.TabIndex = 0;
            menuItemsGridView.UserDeletingRow += menuItemsGridView_UserDeletingRow;
            // 
            // confirmBtn
            // 
            confirmBtn.BackColor = Color.FromArgb(0, 192, 0);
            confirmBtn.BackgroundImageLayout = ImageLayout.None;
            confirmBtn.FlatStyle = FlatStyle.Popup;
            confirmBtn.ForeColor = SystemColors.Control;
            confirmBtn.Location = new Point(691, 357);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(27, 23);
            confirmBtn.TabIndex = 3;
            confirmBtn.Text = "✔️";
            confirmBtn.UseVisualStyleBackColor = false;
            confirmBtn.Click += confirmBtn_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(adminTab);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm";
            Load += AdminForm_Load;
            adminTab.ResumeLayout(false);
            menuTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)menuItemsGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl adminTab;
        private TabPage ordersTab;
        private TabPage usersTab;
        private TabPage adminsTab;
        private TabPage menuTab;
        private DataGridView menuItemsGridView;
        private Button addMenuBtn;
        private Button deleteBtn;
        private Button confirmBtn;
    }
}