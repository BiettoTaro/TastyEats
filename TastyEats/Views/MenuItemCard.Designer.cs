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
      
            addButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxItem).BeginInit();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.Font = new Font("Verdana", 11.1F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(139, 5);
            nameLabel.MaximumSize = new Size(150, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(150, 51);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Name";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            descriptionLabel.Location = new Point(140, 56);
            descriptionLabel.MaximumSize = new Size(124, 0);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(77, 14);
            descriptionLabel.TabIndex = 1;
            descriptionLabel.Text = "Description";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            priceLabel.Location = new Point(211, 133);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(41, 14);
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
            // addButton
            // 
            addButton.Location = new Point(3, 129);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 5;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // MenuItemCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(addButton);
            Controls.Add(pictureBoxItem);
            Controls.Add(priceLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(nameLabel);
            Name = "MenuItemCard";
            Size = new Size(294, 157);
            ((System.ComponentModel.ISupportInitialize)pictureBoxItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private Label descriptionLabel;
        private Label priceLabel;
        private PictureBox pictureBoxItem;
        private Button addButton;
    }
}
