namespace HotelManagement.Forms
{
    partial class UpdatePaymentForm
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
            methodComboBox = new ComboBox();
            AmountTextBox = new TextBox();
            UpdateButton = new Button();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // methodComboBox
            // 
            methodComboBox.FormattingEnabled = true;
            methodComboBox.Location = new Point(145, 206);
            methodComboBox.Name = "methodComboBox";
            methodComboBox.Size = new Size(151, 28);
            methodComboBox.TabIndex = 9;
            // 
            // AmountTextBox
            // 
            AmountTextBox.Location = new Point(146, 104);
            AmountTextBox.Name = "AmountTextBox";
            AmountTextBox.Size = new Size(150, 27);
            AmountTextBox.TabIndex = 8;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(87, 303);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(124, 48);
            UpdateButton.TabIndex = 7;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(23, 206);
            label2.Name = "label2";
            label2.Size = new Size(90, 30);
            label2.TabIndex = 6;
            label2.Text = "Method";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(23, 99);
            label1.Name = "label1";
            label1.Size = new Size(90, 30);
            label1.TabIndex = 5;
            label1.Text = "Amount";
            // 
            // UpdatePaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(319, 450);
            Controls.Add(methodComboBox);
            Controls.Add(AmountTextBox);
            Controls.Add(UpdateButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UpdatePaymentForm";
            Text = "UpdatePaymentForm";
            Load += UpdatePaymentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox methodComboBox;
        private TextBox AmountTextBox;
        private Button UpdateButton;
        private Label label2;
        private Label label1;
    }
}