namespace TastyEats
{
    partial class MenuForm
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
            menuFlowPanel = new FlowLayoutPanel();
            topBarPanel = new Panel();
            btnCart = new Button();
            topBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuFlowPanel
            // 
            menuFlowPanel.AutoScroll = true;
            menuFlowPanel.Dock = DockStyle.Fill;
            menuFlowPanel.Location = new Point(0, 40);
            menuFlowPanel.Name = "menuFlowPanel";
            menuFlowPanel.Size = new Size(800, 410);
            menuFlowPanel.TabIndex = 0;
            // 
            // topBarPanel
            // 
            topBarPanel.BackColor = Color.White;
            topBarPanel.Controls.Add(btnCart);
            topBarPanel.Dock = DockStyle.Top;
            topBarPanel.Location = new Point(0, 0);
            topBarPanel.Name = "topBarPanel";
            topBarPanel.Size = new Size(800, 40);
            topBarPanel.TabIndex = 1;
            // 
            // btnCart
            // 
            btnCart.Dock = DockStyle.Right;
            btnCart.Location = new Point(720, 0);
            btnCart.Margin = new Padding(0, 5, 10, 5);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(80, 40);
            btnCart.TabIndex = 0;
            btnCart.Text = "\U0001f6d2 Cart";
            btnCart.Click += new EventHandler(this.btnCart_Click);
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuFlowPanel);
            Controls.Add(topBarPanel);
            Name = "MenuForm";
            Text = "MenuForm";
            topBarPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel menuFlowPanel;
        private Panel topBarPanel;
        private Button btnCart;
    }
}