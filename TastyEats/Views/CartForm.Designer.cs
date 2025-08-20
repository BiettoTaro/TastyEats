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
            // navbarControl1
            // 
            navbarControl1.Size = new Size(667, 37);
            // 
            // cartPanel
            // 
            cartPanel.AutoScroll = true;
            cartPanel.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cartPanel.Location = new Point(14, 34);
            cartPanel.Name = "cartPanel";
            cartPanel.Size = new Size(640, 258);
            cartPanel.TabIndex = 0;
            // 
            // totalLabel
            // 
            totalLabel.Font = new Font("Verdana", 10F, FontStyle.Bold);
            totalLabel.Location = new Point(14, 299);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(229, 21);
            totalLabel.TabIndex = 1;
            totalLabel.Text = "Total: £0.00";
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(539, 299);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(114, 28);
            btnCheckout.TabIndex = 2;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnClearCart
            // 
            btnClearCart.Location = new Point(418, 299);
            btnClearCart.Name = "btnClearCart";
            btnClearCart.Size = new Size(114, 28);
            btnClearCart.TabIndex = 3;
            btnClearCart.Text = "Clear Cart";
            btnClearCart.UseVisualStyleBackColor = true;
            btnClearCart.Click += btnClearCart_Click;
            // 
            // CartForm
            // 
            AutoScaleDimensions = new SizeF(8F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 337);
            Controls.Add(btnClearCart);
            Controls.Add(btnCheckout);
            Controls.Add(totalLabel);
            Controls.Add(cartPanel);
            Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "CartForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Your Cart";
            Load += CartForm_Load;
            Controls.SetChildIndex(cartPanel, 0);
            Controls.SetChildIndex(totalLabel, 0);
            Controls.SetChildIndex(btnCheckout, 0);
            Controls.SetChildIndex(btnClearCart, 0);
            Controls.SetChildIndex(navbarControl1, 0);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel cartPanel;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnClearCart;
    }
}
