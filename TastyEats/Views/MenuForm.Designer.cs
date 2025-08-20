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
            tableLayoutPanel1 = new TableLayoutPanel();
            SuspendLayout();
            // 
            // navbarControl1
            // 
            navbarControl1.Size = new Size(624, 40);
            // 
            // menuFlowPanel
            // 
            menuFlowPanel.AutoScroll = true;
            menuFlowPanel.Dock = DockStyle.Fill;
            //menuFlowPanel.Location = new Point(0, 0);
            //menuFlowPanel.Name = "menuFlowPanel";
            //menuFlowPanel.Padding = new Padding(0, 40, 0, 0);
            //menuFlowPanel.Size = new Size(624, 605);
            //menuFlowPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 40);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(624, 565);
            tableLayoutPanel1.TabIndex = 1;
            tableLayoutPanel1.Controls.Add(menuFlowPanel, 0, 1);
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 605);
            Controls.Add(tableLayoutPanel1);
            
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuForm";
            
         
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel menuFlowPanel;
        private TableLayoutPanel tableLayoutPanel1;
    }
}