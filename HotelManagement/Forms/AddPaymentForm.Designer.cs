namespace HotelManagement.Forms
{
    partial class AddPaymentForm
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
            AddButton = new Button();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            ReservationComboBox = new ComboBox();
            SuspendLayout();
            // 
            // methodComboBox
            // 
            methodComboBox.FormattingEnabled = true;
            methodComboBox.Location = new Point(159, 281);
            methodComboBox.Name = "methodComboBox";
            methodComboBox.Size = new Size(151, 28);
            methodComboBox.TabIndex = 9;
            // 
            // AmountTextBox
            // 
            AmountTextBox.Location = new Point(160, 179);
            AmountTextBox.Name = "AmountTextBox";
            AmountTextBox.Size = new Size(150, 27);
            AmountTextBox.TabIndex = 8;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(101, 378);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(124, 48);
            AddButton.TabIndex = 7;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 281);
            label2.Name = "label2";
            label2.Size = new Size(90, 30);
            label2.TabIndex = 6;
            label2.Text = "Method";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 174);
            label1.Name = "label1";
            label1.Size = new Size(90, 30);
            label1.TabIndex = 5;
            label1.Text = "Amount";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 85);
            label3.Name = "label3";
            label3.Size = new Size(125, 30);
            label3.TabIndex = 10;
            label3.Text = "Reservation";
            // 
            // ReservationComboBox
            // 
            ReservationComboBox.FormattingEnabled = true;
            ReservationComboBox.Location = new Point(160, 90);
            ReservationComboBox.Name = "ReservationComboBox";
            ReservationComboBox.Size = new Size(151, 28);
            ReservationComboBox.TabIndex = 11;
            // 
            // AddPaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 496);
            Controls.Add(ReservationComboBox);
            Controls.Add(label3);
            Controls.Add(methodComboBox);
            Controls.Add(AmountTextBox);
            Controls.Add(AddButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddPaymentForm";
            Text = "AddPaymentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox methodComboBox;
        private TextBox AmountTextBox;
        private Button AddButton;
        private Label label2;
        private Label label1;
        private Label label3;
        private ComboBox ReservationComboBox;
    }
}