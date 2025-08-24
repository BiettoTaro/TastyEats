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
            orderItemsGridView = new DataGridView();
            ordersGridView = new DataGridView();
            customersTab = new TabPage();
            deleteCBtn = new Button();
            customersGridView = new DataGridView();
            adminsTab = new TabPage();
            editABtn = new Button();
            deleteABtn = new Button();
            addABtn = new Button();
            adminsGridView = new DataGridView();
            menuTab = new TabPage();
            confirmBtn = new Button();
            deleteBtn = new Button();
            addMenuBtn = new Button();
            menuItemsGridView = new DataGridView();
            logoutLink = new LinkLabel();
            adminTab.SuspendLayout();
            ordersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderItemsGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ordersGridView).BeginInit();
            customersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customersGridView).BeginInit();
            adminsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)adminsGridView).BeginInit();
            menuTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)menuItemsGridView).BeginInit();
            SuspendLayout();
            // 
            // adminTab
            // 
            adminTab.Controls.Add(ordersTab);
            adminTab.Controls.Add(customersTab);
            adminTab.Controls.Add(adminsTab);
            adminTab.Controls.Add(menuTab);
            adminTab.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            adminTab.Location = new Point(0, 25);
            adminTab.Name = "adminTab";
            adminTab.SelectedIndex = 0;
            adminTab.Size = new Size(799, 424);
            adminTab.TabIndex = 0;
            adminTab.SelectedIndexChanged += adminTab_SelectedIndexChanged;
            // 
            // ordersTab
            // 
            ordersTab.Controls.Add(orderItemsGridView);
            ordersTab.Controls.Add(ordersGridView);
            ordersTab.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ordersTab.Location = new Point(4, 23);
            ordersTab.Name = "ordersTab";
            ordersTab.Size = new Size(791, 422);
            ordersTab.TabIndex = 0;
            ordersTab.Text = "Orders";
            ordersTab.UseVisualStyleBackColor = true;
            // 
            // orderItemsGridView
            // 
            orderItemsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderItemsGridView.Location = new Point(3, 259);
            orderItemsGridView.Name = "orderItemsGridView";
            orderItemsGridView.Size = new Size(788, 160);
            orderItemsGridView.TabIndex = 1;
            // 
            // ordersGridView
            // 
            ordersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ordersGridView.Location = new Point(3, 8);
            ordersGridView.Name = "ordersGridView";
            ordersGridView.Size = new Size(788, 245);
            ordersGridView.TabIndex = 0;
            ordersGridView.CellValueChanged += ordersGridView_CellValueChanged;
            ordersGridView.SelectionChanged += ordersGridView_SelectionChanged;
            // 
            // customersTab
            // 
            customersTab.Controls.Add(deleteCBtn);
            customersTab.Controls.Add(customersGridView);
            customersTab.Location = new Point(4, 23);
            customersTab.Name = "customersTab";
            customersTab.Padding = new Padding(3);
            customersTab.Size = new Size(791, 422);
            customersTab.TabIndex = 1;
            customersTab.Text = "Customers";
            customersTab.UseVisualStyleBackColor = true;
            // 
            // deleteCBtn
            // 
            deleteCBtn.BackColor = Color.Red;
            deleteCBtn.BackgroundImageLayout = ImageLayout.None;
            deleteCBtn.FlatStyle = FlatStyle.Popup;
            deleteCBtn.ForeColor = SystemColors.Control;
            deleteCBtn.Location = new Point(757, 361);
            deleteCBtn.Name = "deleteCBtn";
            deleteCBtn.Size = new Size(27, 23);
            deleteCBtn.TabIndex = 6;
            deleteCBtn.Text = "🗑️";
            deleteCBtn.UseVisualStyleBackColor = false;
            deleteCBtn.Click += deleteCBtn_Click;
            // 
            // customersGridView
            // 
            customersGridView.AllowUserToAddRows = false;
            customersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customersGridView.Location = new Point(0, 0);
            customersGridView.Name = "customersGridView";
            customersGridView.Size = new Size(791, 355);
            customersGridView.TabIndex = 4;
            // 
            // adminsTab
            // 
            adminsTab.Controls.Add(editABtn);
            adminsTab.Controls.Add(deleteABtn);
            adminsTab.Controls.Add(addABtn);
            adminsTab.Controls.Add(adminsGridView);
            adminsTab.Location = new Point(4, 23);
            adminsTab.Name = "adminsTab";
            adminsTab.Padding = new Padding(3);
            adminsTab.Size = new Size(791, 397);
            adminsTab.TabIndex = 2;
            adminsTab.Text = "Admins";
            adminsTab.UseVisualStyleBackColor = true;
            // 
            // editABtn
            // 
            editABtn.BackColor = Color.FromArgb(0, 192, 192);
            editABtn.BackgroundImageLayout = ImageLayout.None;
            editABtn.FlatStyle = FlatStyle.Popup;
            editABtn.ForeColor = SystemColors.Control;
            editABtn.Location = new Point(663, 357);
            editABtn.Name = "editABtn";
            editABtn.Size = new Size(55, 23);
            editABtn.TabIndex = 7;
            editABtn.Text = "Edit";
            editABtn.UseVisualStyleBackColor = false;
            editABtn.Click += editABtn_Click;
            // 
            // deleteABtn
            // 
            deleteABtn.BackColor = Color.Red;
            deleteABtn.BackgroundImageLayout = ImageLayout.None;
            deleteABtn.FlatStyle = FlatStyle.Popup;
            deleteABtn.ForeColor = SystemColors.Control;
            deleteABtn.Location = new Point(724, 357);
            deleteABtn.Name = "deleteABtn";
            deleteABtn.Size = new Size(27, 23);
            deleteABtn.TabIndex = 6;
            deleteABtn.Text = "🗑️";
            deleteABtn.UseVisualStyleBackColor = false;
            deleteABtn.Click += deleteABtn_Click;
            // 
            // addABtn
            // 
            addABtn.Location = new Point(767, 357);
            addABtn.Name = "addABtn";
            addABtn.Size = new Size(18, 23);
            addABtn.TabIndex = 5;
            addABtn.Text = "+";
            addABtn.UseVisualStyleBackColor = true;
            addABtn.Click += addABtn_Click;
            // 
            // adminsGridView
            // 
            adminsGridView.AllowUserToAddRows = false;
            adminsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            adminsGridView.Location = new Point(0, 0);
            adminsGridView.Name = "adminsGridView";
            adminsGridView.Size = new Size(791, 355);
            adminsGridView.TabIndex = 4;
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
            menuTab.Size = new Size(791, 422);
            menuTab.TabIndex = 3;
            menuTab.Text = "Menu";
            menuTab.UseVisualStyleBackColor = true;
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
            // logoutLink
            // 
            logoutLink.AutoSize = true;
            logoutLink.Location = new Point(744, 9);
            logoutLink.Name = "logoutLink";
            logoutLink.Size = new Size(45, 15);
            logoutLink.TabIndex = 8;
            logoutLink.TabStop = true;
            logoutLink.Text = "Logout";
            logoutLink.LinkClicked += logoutLink_LinkClicked;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(logoutLink);
            Controls.Add(adminTab);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm";
            Load += AdminForm_Load;
            adminTab.ResumeLayout(false);
            ordersTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)orderItemsGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ordersGridView).EndInit();
            customersTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)customersGridView).EndInit();
            adminsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)adminsGridView).EndInit();
            menuTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)menuItemsGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl adminTab;
        private TabPage ordersTab;
        private TabPage customersTab;
        private TabPage adminsTab;
        private TabPage menuTab;
        private DataGridView menuItemsGridView;
        private Button addMenuBtn;
        private Button deleteBtn;
        private Button confirmBtn;
        private DataGridView ordersGridView;
        private DataGridView orderItemsGridView;
        private Button deleteCBtn;
        private DataGridView customersGridView;
        private Button editABtn;
        private Button deleteABtn;
        private Button addABtn;
        private DataGridView adminsGridView;
        private LinkLabel logoutLink;
    }
}