namespace TastyEats
{
    partial class MenuItemCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nameLabel = new Label();
            descriptionLabel = new Label();
            priceLabel = new Label();
            pictureBoxItem = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxItem).BeginInit();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(140, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(39, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(140, 43);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(67, 15);
            descriptionLabel.TabIndex = 1;
            descriptionLabel.Text = "Description";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(140, 93);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(33, 15);
            priceLabel.TabIndex = 2;
            priceLabel.Text = "Price";
            // 
            // pictureBoxItem
            // 
            pictureBoxItem.Location = new Point(0, 0);
            pictureBoxItem.Name = "pictureBoxItem";
            pictureBoxItem.Size = new Size(134, 120);
            pictureBoxItem.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxItem.TabIndex = 3;
            pictureBoxItem.TabStop = false;
            // 
            // MenuItemCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBoxItem);
            Controls.Add(priceLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(nameLabel);
            Name = "MenuItemCard";
            Size = new Size(300, 120);
            ((System.ComponentModel.ISupportInitialize)pictureBoxItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private Label descriptionLabel;
        private Label priceLabel;
        private PictureBox pictureBoxItem;
        private Label label1;
    }
}
