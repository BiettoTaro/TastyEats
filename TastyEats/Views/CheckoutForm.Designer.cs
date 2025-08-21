namespace TastyEats.Views
{
    partial class CheckoutForm
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
            components = new System.ComponentModel.Container();
            BillingLbl = new Label();
            fullNameLbl = new Label();
            nameBox = new TextBox();
            addressLbl = new Label();
            emailLbl = new Label();
            emailBox = new TextBox();
            addressBox = new RichTextBox();
            label1 = new Label();
            radioButton1 = new RadioButton();
            cardNameLbl = new Label();
            cardNameBox = new TextBox();
            cardNumberLbl = new Label();
            cardNumberBox = new TextBox();
            expLbl = new Label();
            expDtp = new DateTimePicker();
            cvvBox = new TextBox();
            orderBtn = new Button();
            backBtn = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // BillingLbl
            // 
            BillingLbl.AutoSize = true;
            BillingLbl.Location = new Point(15, 32);
            BillingLbl.Margin = new Padding(6, 0, 6, 0);
            BillingLbl.Name = "BillingLbl";
            BillingLbl.Size = new Size(187, 25);
            BillingLbl.TabIndex = 0;
            BillingLbl.Text = "Billing Address";
            // 
            // fullNameLbl
            // 
            fullNameLbl.AutoSize = true;
            fullNameLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            fullNameLbl.Location = new Point(15, 89);
            fullNameLbl.Name = "fullNameLbl";
            fullNameLbl.Size = new Size(78, 16);
            fullNameLbl.TabIndex = 1;
            fullNameLbl.Text = "Full Name";
            // 
            // nameBox
            // 
            nameBox.Location = new Point(15, 121);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(187, 33);
            nameBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameBox.TabIndex = 2;
            // 
            // addressLbl
            // 
            addressLbl.AutoSize = true;
            addressLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            addressLbl.Location = new Point(15, 285);
            addressLbl.Name = "addressLbl";
            addressLbl.Size = new Size(65, 16);
            addressLbl.TabIndex = 3;
            addressLbl.Text = "Address";
            // 
            // emailLbl
            // 
            emailLbl.AutoSize = true;
            emailLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            emailLbl.Location = new Point(15, 183);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(47, 16);
            emailLbl.TabIndex = 4;
            emailLbl.Text = "Email";
            // 
            // emailBox
            // 
            emailBox.Location = new Point(15, 218);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(187, 33);
            emailBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailBox.TabIndex = 5;
            // 
            // addressBox
            // 
            addressBox.Location = new Point(15, 316);
            addressBox.Name = "addressBox";
            addressBox.Size = new Size(187, 96);
            addressBox.TabIndex = 6;
            addressBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addressBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(346, 32);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(187, 25);
            label1.TabIndex = 7;
            label1.Text = "Billing Address";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButton1.Location = new Point(346, 392);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(125, 20);
            radioButton1.TabIndex = 8;
            radioButton1.TabStop = true;
            radioButton1.Text = "Pay with cash";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // cardNameLbl
            // 
            cardNameLbl.AutoSize = true;
            cardNameLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            cardNameLbl.Location = new Point(346, 89);
            cardNameLbl.Name = "cardNameLbl";
            cardNameLbl.Size = new Size(109, 16);
            cardNameLbl.TabIndex = 9;
            cardNameLbl.Text = "Name on Card";
            // 
            // cardNameBox
            // 
            cardNameBox.Location = new Point(346, 121);
            cardNameBox.Name = "cardNameBox";
            cardNameBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cardNameBox.Size = new Size(187, 33);
            cardNameBox.TabIndex = 10;
            // 
            // cardNumberLbl
            // 
            cardNumberLbl.AutoSize = true;
            cardNumberLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            cardNumberLbl.Location = new Point(346, 183);
            cardNumberLbl.Name = "cardNumberLbl";
            cardNumberLbl.Size = new Size(150, 16);
            cardNumberLbl.TabIndex = 11;
            cardNumberLbl.Text = "Credit Card Number";
            // 
            // cardNumberBox
            // 
            cardNumberBox.Location = new Point(346, 218);
            cardNumberBox.Name = "cardNumberBox";
            cardNumberBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cardNumberBox.Size = new Size(187, 33);
            cardNumberBox.TabIndex = 12;
            // 
            // expLbl
            // 
            expLbl.AutoSize = true;
            expLbl.Font = new Font("Verdana", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            expLbl.Location = new Point(346, 285);
            expLbl.Name = "expLbl";
            expLbl.Size = new Size(172, 16);
            expLbl.TabIndex = 13;
            expLbl.Text = "Expiration Date  /  CVV";
            // 
            // expDtp
            // 
            expDtp.AllowDrop = true;
            expDtp.CalendarFont = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            expDtp.CustomFormat = "MM/yyyy";
            expDtp.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            expDtp.Format = DateTimePickerFormat.Custom;
            expDtp.Location = new Point(346, 316);
            expDtp.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            expDtp.MinDate = new DateTime(2025, 1, 1, 0, 0, 0, 0);
            expDtp.Name = "expDtp";
            expDtp.Size = new Size(92, 23);
            expDtp.TabIndex = 14;
            expDtp.Value = new DateTime(2025, 8, 17, 0, 0, 0, 0);
            // 
            // cvvBox
            // 
            cvvBox.Location = new Point(476, 310);
            cvvBox.Name = "cvvBox";
            cvvBox.Size = new Size(57, 33);
            cvvBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cvvBox.TabIndex = 15;
            // 
            // orderBtn
            // 
            orderBtn.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            orderBtn.Location = new Point(346, 467);
            orderBtn.Name = "orderBtn";
            orderBtn.Size = new Size(187, 34);
            orderBtn.TabIndex = 16;
            orderBtn.Text = "ORDER";
            orderBtn.UseVisualStyleBackColor = true;
            orderBtn.Click += orderBtn_Click;
            // 
            // backBtn
            // 
            backBtn.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            backBtn.Location = new Point(15, 467);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(187, 34);
            backBtn.TabIndex = 17;
            backBtn.Text = "BACK";
            backBtn.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // CheckoutForm
            // 
            AutoScaleDimensions = new SizeF(15F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 512);
            Controls.Add(backBtn);
            Controls.Add(orderBtn);
            Controls.Add(cvvBox);
            Controls.Add(expDtp);
            Controls.Add(expLbl);
            Controls.Add(cardNumberBox);
            Controls.Add(cardNumberLbl);
            Controls.Add(cardNameBox);
            Controls.Add(cardNameLbl);
            Controls.Add(radioButton1);
            Controls.Add(label1);
            Controls.Add(addressBox);
            Controls.Add(emailBox);
            Controls.Add(emailLbl);
            Controls.Add(addressLbl);
            Controls.Add(nameBox);
            Controls.Add(fullNameLbl);
            Controls.Add(BillingLbl);
            Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(6);
            Name = "CheckoutForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CheckoutForm";
            Load += CheckoutForm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label BillingLbl;
        private Label fullNameLbl;
        private TextBox nameBox;
        private Label addressLbl;
        private Label emailLbl;
        private TextBox emailBox;
        private RichTextBox addressBox;
        private Label label1;
        private RadioButton radioButton1;
        private Label cardNameLbl;
        private TextBox cardNameBox;
        private Label cardNumberLbl;
        private TextBox cardNumberBox;
        private Label expLbl;
        private DateTimePicker expDtp;
        private TextBox cvvBox;
        private Button orderBtn;
        private Button backBtn;
        private ErrorProvider errorProvider1;
        
    }
}