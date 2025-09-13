namespace TastyEats.Views
{
    partial class HomeForm
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
            welcomeLbl = new Label();
            label2 = new Label();
            homeBtn = new Button();
            SuspendLayout();
            // 
            // navbarControl1
            // 
            navbarControl1.Size = new Size(603, 40);
            // 
            // welcomeLbl
            // 
            welcomeLbl.AutoSize = true;
            welcomeLbl.BackColor = Color.Transparent;
            welcomeLbl.Font = new Font("Segoe Script", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            welcomeLbl.ForeColor = Color.White;
            welcomeLbl.Location = new Point(167, 118);
            welcomeLbl.Name = "welcomeLbl";
            welcomeLbl.Size = new Size(98, 30);
            welcomeLbl.TabIndex = 1;
            welcomeLbl.Text = "Welcome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe Script", 14.2F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(131, 148);
            label2.Name = "label2";
            label2.Size = new Size(315, 30);
            label2.TabIndex = 2;
            label2.Text = " to your favourite Restaurant";
            // 
            // homeBtn
            // 
            homeBtn.BackColor = Color.Transparent;
            homeBtn.FlatStyle = FlatStyle.Popup;
            homeBtn.Font = new Font("Segoe Script", 12F);
            homeBtn.ForeColor = Color.IndianRed;
            homeBtn.Location = new Point(329, 200);
            homeBtn.Name = "homeBtn";
            homeBtn.Size = new Size(126, 32);
            homeBtn.TabIndex = 3;
            homeBtn.Text = "Order Now";
            homeBtn.UseVisualStyleBackColor = false;
            homeBtn.Click += homeBtn_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.tasty_background;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(603, 337);
            Controls.Add(homeBtn);
            Controls.Add(label2);
            Controls.Add(welcomeLbl);
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            Controls.SetChildIndex(navbarControl1, 0);
            Controls.SetChildIndex(welcomeLbl, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(homeBtn, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label welcomeLbl;
        private Label label2;
        private Button homeBtn;
    }
}