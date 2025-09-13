namespace TastyEats.Views
{
    partial class AddPopup
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
            dishImage = new PictureBox();
            nameLabel = new Label();
            quantitySelector = new NumericUpDown();
            totalLabel = new Label();
            modifications = new RichTextBox();
            cancelBtn = new Button();
            addBtn = new Button();
            modificationsLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dishImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quantitySelector).BeginInit();
            SuspendLayout();
            // 
            // dishImage
            // 
            dishImage.Location = new Point(29, 25);
            dishImage.Margin = new Padding(7, 8, 7, 8);
            dishImage.Name = "dishImage";
            dishImage.Size = new Size(420, 432);
            dishImage.SizeMode = PictureBoxSizeMode.StretchImage;
            dishImage.TabIndex = 0;
            dishImage.TabStop = false;
            // 
            // nameLabel
            // 
            nameLabel.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(466, 25);
            nameLabel.Margin = new Padding(7, 0, 7, 0);
            nameLabel.MaximumSize = new Size(364, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(364, 264);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "name";
            // 
            // quantitySelector
            // 
            quantitySelector.Location = new Point(466, 369);
            quantitySelector.Margin = new Padding(7, 8, 7, 8);
            quantitySelector.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            quantitySelector.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            quantitySelector.Name = "quantitySelector";
            quantitySelector.Size = new Size(73, 47);
            quantitySelector.TabIndex = 2;
            quantitySelector.Value = new decimal(new int[] { 1, 0, 0, 0 });
            quantitySelector.ValueChanged += quantitySelector_ValueChanged;
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalLabel.Location = new Point(554, 388);
            totalLabel.Margin = new Padding(7, 0, 7, 0);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(195, 40);
            totalLabel.TabIndex = 3;
            totalLabel.Text = "totalPrice";
            // 
            // modifications
            // 
            modifications.Location = new Point(29, 566);
            modifications.Margin = new Padding(7, 8, 7, 8);
            modifications.Name = "modifications";
            modifications.Size = new Size(784, 138);
            modifications.TabIndex = 3;
            modifications.Text = "";
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(29, 727);
            cancelBtn.Margin = new Padding(7, 8, 7, 8);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(182, 63);
            cancelBtn.TabIndex = 4;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(636, 727);
            addBtn.Margin = new Padding(7, 8, 7, 8);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(182, 63);
            addBtn.TabIndex = 5;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // modificationsLabel
            // 
            modificationsLabel.AutoSize = true;
            modificationsLabel.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modificationsLabel.Location = new Point(29, 517);
            modificationsLabel.Margin = new Padding(7, 0, 7, 0);
            modificationsLabel.Name = "modificationsLabel";
            modificationsLabel.Size = new Size(323, 36);
            modificationsLabel.TabIndex = 6;
            modificationsLabel.Text = "Notes for the Chef";
            // 
            // AddPopup
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 820);
            Controls.Add(modificationsLabel);
            Controls.Add(addBtn);
            Controls.Add(cancelBtn);
            Controls.Add(modifications);
            Controls.Add(quantitySelector);
            Controls.Add(nameLabel);
            Controls.Add(dishImage);
            Controls.Add(totalLabel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(7, 8, 7, 8);
            Name = "AddPopup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddPopup";
            ((System.ComponentModel.ISupportInitialize)dishImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)quantitySelector).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox dishImage;
        private Label nameLabel;
        private NumericUpDown quantitySelector;
        private Label totalLabel;
        private RichTextBox modifications;
        private Button cancelBtn;
        private Button addBtn;
        private Label modificationsLabel;
    }
}