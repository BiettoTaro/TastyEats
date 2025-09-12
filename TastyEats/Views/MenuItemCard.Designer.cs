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
            label2 = new Label();
            addButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxItem).BeginInit();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.Font = new Font("Verdana", 11.1F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(199, 9);
            nameLabel.Margin = new Padding(4, 0, 4, 0);
            nameLabel.MaximumSize = new Size(214, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(214, 84);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Name";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            descriptionLabel.Location = new Point(200, 93);
            descriptionLabel.Margin = new Padding(4, 0, 4, 0);
            descriptionLabel.MaximumSize = new Size(177, 0);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(111, 22);
            descriptionLabel.TabIndex = 1;
            descriptionLabel.Text = "Description";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            priceLabel.Location = new Point(301, 222);
            priceLabel.Margin = new Padding(4, 0, 4, 0);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(61, 22);
            priceLabel.TabIndex = 2;
            priceLabel.Text = "Price";
            // 
            // pictureBoxItem
            // 
            pictureBoxItem.Location = new Point(0, 0);
            pictureBoxItem.Margin = new Padding(4, 5, 4, 5);
            pictureBoxItem.Name = "pictureBoxItem";
            pictureBoxItem.Size = new Size(191, 200);
            pictureBoxItem.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxItem.TabIndex = 3;
            pictureBoxItem.TabStop = false;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Location = new Point(4, 215);
            addButton.Margin = new Padding(4, 5, 4, 5);
            addButton.Name = "addButton";
            addButton.Size = new Size(107, 38);
            addButton.TabIndex = 5;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // MenuItemCard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(addButton);
            Controls.Add(pictureBoxItem);
            Controls.Add(priceLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(nameLabel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MenuItemCard";
            Size = new Size(420, 262);
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
        private Label label2;
        private Button addButton;
    }
}
