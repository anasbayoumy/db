namespace HotelManagement.Forms
{
    partial class AddResPaymentForm
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
            label1 = new Label();
            label2 = new Label();
            AddButton = new Button();
            AmountTextBox = new TextBox();
            methodComboBox = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(34, 81);
            label1.Name = "label1";
            label1.Size = new Size(90, 30);
            label1.TabIndex = 0;
            label1.Text = "Amount";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(34, 188);
            label2.Name = "label2";
            label2.Size = new Size(90, 30);
            label2.TabIndex = 1;
            label2.Text = "Method";
            // 
            // AddButton
            // 
            AddButton.Location = new Point(98, 285);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(124, 48);
            AddButton.TabIndex = 2;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // AmountTextBox
            // 
            AmountTextBox.Location = new Point(157, 86);
            AmountTextBox.Name = "AmountTextBox";
            AmountTextBox.Size = new Size(150, 27);
            AmountTextBox.TabIndex = 3;
            // 
            // methodComboBox
            // 
            methodComboBox.FormattingEnabled = true;
            methodComboBox.Location = new Point(156, 188);
            methodComboBox.Name = "methodComboBox";
            methodComboBox.Size = new Size(151, 28);
            methodComboBox.TabIndex = 4;
            // 
            // AddResPaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 450);
            Controls.Add(methodComboBox);
            Controls.Add(AmountTextBox);
            Controls.Add(AddButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddResPaymentForm";
            Text = "AddResPaymentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button AddButton;
        private TextBox AmountTextBox;
        private ComboBox methodComboBox;
    }
}