namespace HotelManagement.Forms
{
    partial class UpdateCategoryForm
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
            HotelComboBox = new ComboBox();
            PriceTextBox = new TextBox();
            NameTextBox = new TextBox();
            UpdateButton = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // HotelComboBox
            // 
            HotelComboBox.FormattingEnabled = true;
            HotelComboBox.Location = new Point(194, 99);
            HotelComboBox.Name = "HotelComboBox";
            HotelComboBox.Size = new Size(158, 28);
            HotelComboBox.TabIndex = 13;
            // 
            // PriceTextBox
            // 
            PriceTextBox.Location = new Point(194, 231);
            PriceTextBox.Name = "PriceTextBox";
            PriceTextBox.Size = new Size(158, 27);
            PriceTextBox.TabIndex = 12;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(194, 167);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(158, 27);
            NameTextBox.TabIndex = 11;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(124, 299);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(109, 48);
            UpdateButton.TabIndex = 10;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(77, 226);
            label3.Name = "label3";
            label3.Size = new Size(60, 30);
            label3.TabIndex = 9;
            label3.Text = "Price";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(22, 162);
            label2.Name = "label2";
            label2.Size = new Size(166, 30);
            label2.TabIndex = 8;
            label2.Text = "Category Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(71, 99);
            label1.Name = "label1";
            label1.Size = new Size(66, 30);
            label1.TabIndex = 7;
            label1.Text = "Hotel";
            // 
            // UpdateCategoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 450);
            Controls.Add(HotelComboBox);
            Controls.Add(PriceTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(UpdateButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UpdateCategoryForm";
            Text = "UpdateCategoryForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox HotelComboBox;
        private TextBox PriceTextBox;
        private TextBox NameTextBox;
        private Button UpdateButton;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}