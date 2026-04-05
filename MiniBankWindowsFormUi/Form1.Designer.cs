namespace MiniBankWindowsFormUi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            NameLabel = new Label();
            NameValue = new TextBox();
            IdentityLabel = new Label();
            IdentityValue = new TextBox();
            PhoneNumLabel = new Label();
            PhoneNumValue = new TextBox();
            EmailLabel = new Label();
            EmailValue = new TextBox();
            TypeLabel = new Label();
            CustomerTypeCombo = new ComboBox();
            ClearBtn = new Button();
            AddBtn = new Button();
            UpdateBtn = new Button();
            DeleteBtn = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(1, 8);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(210, 404);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(227, 14);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(49, 20);
            NameLabel.TabIndex = 1;
            NameLabel.Text = "Name";
            NameLabel.Click += label1_Click;
            // 
            // NameValue
            // 
            NameValue.Location = new Point(227, 37);
            NameValue.Name = "NameValue";
            NameValue.Size = new Size(267, 27);
            NameValue.TabIndex = 2;
            // 
            // IdentityLabel
            // 
            IdentityLabel.AutoSize = true;
            IdentityLabel.Location = new Point(227, 99);
            IdentityLabel.Name = "IdentityLabel";
            IdentityLabel.Size = new Size(117, 20);
            IdentityLabel.TabIndex = 3;
            IdentityLabel.Text = "Identity Number";
            // 
            // IdentityValue
            // 
            IdentityValue.Location = new Point(227, 122);
            IdentityValue.Name = "IdentityValue";
            IdentityValue.Size = new Size(267, 27);
            IdentityValue.TabIndex = 4;
            // 
            // PhoneNumLabel
            // 
            PhoneNumLabel.AutoSize = true;
            PhoneNumLabel.Location = new Point(227, 172);
            PhoneNumLabel.Name = "PhoneNumLabel";
            PhoneNumLabel.Size = new Size(103, 20);
            PhoneNumLabel.TabIndex = 5;
            PhoneNumLabel.Text = "Phone Nunber";
            // 
            // PhoneNumValue
            // 
            PhoneNumValue.Location = new Point(227, 195);
            PhoneNumValue.Name = "PhoneNumValue";
            PhoneNumValue.Size = new Size(267, 27);
            PhoneNumValue.TabIndex = 6;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(227, 250);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(46, 20);
            EmailLabel.TabIndex = 7;
            EmailLabel.Text = "Email";
            // 
            // EmailValue
            // 
            EmailValue.Location = new Point(227, 273);
            EmailValue.Name = "EmailValue";
            EmailValue.Size = new Size(267, 27);
            EmailValue.TabIndex = 8;
            // 
            // TypeLabel
            // 
            TypeLabel.AutoSize = true;
            TypeLabel.Location = new Point(227, 318);
            TypeLabel.Name = "TypeLabel";
            TypeLabel.Size = new Size(40, 20);
            TypeLabel.TabIndex = 9;
            TypeLabel.Text = "Type";
            // 
            // CustomerTypeCombo
            // 
            CustomerTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            CustomerTypeCombo.FormattingEnabled = true;
            CustomerTypeCombo.Location = new Point(227, 341);
            CustomerTypeCombo.Name = "CustomerTypeCombo";
            CustomerTypeCombo.Size = new Size(267, 28);
            CustomerTypeCombo.TabIndex = 10;
            // 
            // ClearBtn
            // 
            ClearBtn.BackColor = SystemColors.HotTrack;
            ClearBtn.ForeColor = SystemColors.ButtonFace;
            ClearBtn.Location = new Point(561, 46);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(94, 29);
            ClearBtn.TabIndex = 11;
            ClearBtn.Text = "Clear";
            ClearBtn.UseVisualStyleBackColor = false;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.Lime;
            AddBtn.Location = new Point(561, 155);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(143, 37);
            AddBtn.TabIndex = 12;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += AddBtn_Click;
            // 
            // UpdateBtn
            // 
            UpdateBtn.BackColor = Color.FromArgb(192, 192, 0);
            UpdateBtn.Location = new Point(561, 215);
            UpdateBtn.Name = "UpdateBtn";
            UpdateBtn.Size = new Size(143, 37);
            UpdateBtn.TabIndex = 13;
            UpdateBtn.Text = "Update";
            UpdateBtn.UseVisualStyleBackColor = false;
            UpdateBtn.Click += UpdateBtn_Click;
            // 
            // DeleteBtn
            // 
            DeleteBtn.BackColor = Color.Red;
            DeleteBtn.Location = new Point(561, 273);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(143, 37);
            DeleteBtn.TabIndex = 14;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = false;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(995, 429);
            Controls.Add(DeleteBtn);
            Controls.Add(UpdateBtn);
            Controls.Add(AddBtn);
            Controls.Add(ClearBtn);
            Controls.Add(CustomerTypeCombo);
            Controls.Add(TypeLabel);
            Controls.Add(EmailValue);
            Controls.Add(EmailLabel);
            Controls.Add(PhoneNumValue);
            Controls.Add(PhoneNumLabel);
            Controls.Add(IdentityValue);
            Controls.Add(IdentityLabel);
            Controls.Add(NameValue);
            Controls.Add(NameLabel);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label NameLabel;
        private TextBox NameValue;
        private Label IdentityLabel;
        private TextBox IdentityValue;
        private Label PhoneNumLabel;
        private TextBox PhoneNumValue;
        private Label EmailLabel;
        private TextBox EmailValue;
        private Label TypeLabel;
        private ComboBox CustomerTypeCombo;
        private Button ClearBtn;
        private Button AddBtn;
        private Button UpdateBtn;
        private Button DeleteBtn;
    }
}
