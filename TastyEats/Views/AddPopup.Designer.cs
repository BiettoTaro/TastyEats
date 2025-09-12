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
            dishImage.Location = new Point(12, 9);
            dishImage.Name = "dishImage";
            dishImage.Size = new Size(173, 158);
            dishImage.SizeMode = PictureBoxSizeMode.StretchImage;
            dishImage.TabIndex = 0;
            dishImage.TabStop = false;
            // 
            // nameLabel
            // 
            nameLabel.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(192, 9);
            nameLabel.MaximumSize = new Size(150, 0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(150, 109);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "name";
            // 
            // quantitySelector
            // 
            quantitySelector.Location = new Point(192, 135);
            quantitySelector.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            quantitySelector.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            quantitySelector.Name = "quantitySelector";
            quantitySelector.Size = new Size(30, 23);
            quantitySelector.TabIndex = 2;
            quantitySelector.Value = new decimal(new int[] { 1, 0, 0, 0 });
            quantitySelector.ValueChanged += quantitySelector_ValueChanged;
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalLabel.Location = new Point(228, 142);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(77, 16);
            totalLabel.TabIndex = 3;
            totalLabel.Text = "totalPrice";
            // 
            // modifications
            // 
            modifications.Location = new Point(12, 207);
            modifications.Name = "modifications";
            modifications.Size = new Size(325, 53);
            modifications.TabIndex = 3;
            modifications.Text = "";
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(12, 266);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 4;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(262, 266);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(75, 23);
            addBtn.TabIndex = 5;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // modificationsLabel
            // 
            modificationsLabel.AutoSize = true;
            modificationsLabel.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modificationsLabel.Location = new Point(12, 189);
            modificationsLabel.Name = "modificationsLabel";
            modificationsLabel.Size = new Size(127, 14);
            modificationsLabel.TabIndex = 6;
            modificationsLabel.Text = "Notes for the Chef";
            // 
            // AddPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 300);
            Controls.Add(modificationsLabel);
            Controls.Add(addBtn);
            Controls.Add(cancelBtn);
            Controls.Add(modifications);
            Controls.Add(quantitySelector);
            Controls.Add(nameLabel);
            Controls.Add(dishImage);
            Controls.Add(totalLabel);
            FormBorderStyle = FormBorderStyle.None;
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