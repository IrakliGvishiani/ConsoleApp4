namespace MiniBankWindowsFormUi
{
    partial class Form2
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
            CurrencyLabel = new Label();
            CurrencyValue = new TextBox();
            NameValue = new TextBox();
            NameLabel = new Label();
            CreateAccountBtn = new Button();
            SuspendLayout();
            // 
            // CurrencyLabel
            // 
            CurrencyLabel.AutoSize = true;
            CurrencyLabel.Location = new Point(55, 25);
            CurrencyLabel.Name = "CurrencyLabel";
            CurrencyLabel.Size = new Size(66, 20);
            CurrencyLabel.TabIndex = 0;
            CurrencyLabel.Text = "Currency";
            // 
            // CurrencyValue
            // 
            CurrencyValue.Location = new Point(55, 68);
            CurrencyValue.Name = "CurrencyValue";
            CurrencyValue.Size = new Size(234, 27);
            CurrencyValue.TabIndex = 1;
            // 
            // NameValue
            // 
            NameValue.Location = new Point(55, 164);
            NameValue.Name = "NameValue";
            NameValue.Size = new Size(234, 27);
            NameValue.TabIndex = 3;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(55, 123);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(49, 20);
            NameLabel.TabIndex = 2;
            NameLabel.Text = "Name";
            // 
            // CreateAccountBtn
            // 
            CreateAccountBtn.BackColor = Color.FromArgb(128, 128, 255);
            CreateAccountBtn.Location = new Point(55, 219);
            CreateAccountBtn.Name = "CreateAccountBtn";
            CreateAccountBtn.Size = new Size(165, 42);
            CreateAccountBtn.TabIndex = 4;
            CreateAccountBtn.Text = "Create Account";
            CreateAccountBtn.UseVisualStyleBackColor = false;
            CreateAccountBtn.Click += CreateAccountBtn_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CreateAccountBtn);
            Controls.Add(NameValue);
            Controls.Add(NameLabel);
            Controls.Add(CurrencyValue);
            Controls.Add(CurrencyLabel);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CurrencyLabel;
        private TextBox CurrencyValue;
        private TextBox NameValue;
        private Label NameLabel;
        private Button CreateAccountBtn;
    }
}