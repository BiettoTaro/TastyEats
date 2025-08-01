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
            SuspendLayout();
            // 
            // menuFlowPanel
            // 
            menuFlowPanel.AutoScroll = true;
            menuFlowPanel.Dock = DockStyle.Fill;
            menuFlowPanel.Location = new Point(0, 0);
            menuFlowPanel.Name = "menuFlowPanel";
            menuFlowPanel.Size = new Size(800, 450);
            menuFlowPanel.TabIndex = 0;
            //menuFlowPanel.Paint += this.menuFlowPanel_Paint;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuFlowPanel);
            Name = "MenuForm";
            Text = "MenuForm";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel menuFlowPanel;
    }
}