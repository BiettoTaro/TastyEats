namespace TastyEats.Views
{
    partial class CartForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up resources
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            cartPanel = new FlowLayoutPanel();
            totalLabel = new Label();
            btnCheckout = new Button();
            btnClearCart = new Button();
            SuspendLayout();
            // 
            // cartPanel
            // 
            cartPanel.AutoScroll = true;
            cartPanel.Location = new Point(12, 12);
            cartPanel.Name = "cartPanel";
            cartPanel.Size = new Size(460, 300);
            cartPanel.TabIndex = 0;
            // 
            // totalLabel
            // 
            totalLabel.Font = new Font("Verdana", 10F, FontStyle.Bold);
            totalLabel.Location = new Point(12, 320);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(200, 23);
            totalLabel.TabIndex = 1;
            totalLabel.Text = "Total: £0.00";
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(372, 320);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(100, 30);
            btnCheckout.TabIndex = 2;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnClearCart
            // 
            btnClearCart.Location = new Point(266, 320);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(100, 30);
            btnClearCart.TabIndex = 3;
            btnClearCart.Text = "Clear Cart";
            btnClearCart.UseVisualStyleBackColor = true;
            btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);
            // 
            // CartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(btnClearCart);
            Controls.Add(btnCheckout);
            Controls.Add(totalLabel);
            Controls.Add(cartPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "CartForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Your Cart";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel cartPanel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnClearCart;
    }
}
