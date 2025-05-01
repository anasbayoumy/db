namespace HotelManagement.Forms
{
    partial class AddNewCategory
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
            label3 = new Label();
            AddButton = new Button();
            NameTextBox = new TextBox();
            PriceTextBox = new TextBox();
            HotelComboBox = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(61, 79);
            label1.Name = "label1";
            label1.Size = new Size(66, 30);
            label1.TabIndex = 0;
            label1.Text = "Hotel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 142);
            label2.Name = "label2";
            label2.Size = new Size(166, 30);
            label2.TabIndex = 1;
            label2.Text = "Category Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(67, 206);
            label3.Name = "label3";
            label3.Size = new Size(60, 30);
            label3.TabIndex = 2;
            label3.Text = "Price";
            // 
            // AddButton
            // 
            AddButton.Location = new Point(114, 279);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(109, 48);
            AddButton.TabIndex = 3;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(184, 147);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(158, 27);
            NameTextBox.TabIndex = 4;
            // 
            // PriceTextBox
            // 
            PriceTextBox.Location = new Point(184, 211);
            PriceTextBox.Name = "PriceTextBox";
            PriceTextBox.Size = new Size(158, 27);
            PriceTextBox.TabIndex = 5;
            // 
            // HotelComboBox
            // 
            HotelComboBox.FormattingEnabled = true;
            HotelComboBox.Location = new Point(184, 79);
            HotelComboBox.Name = "HotelComboBox";
            HotelComboBox.Size = new Size(158, 28);
            HotelComboBox.TabIndex = 6;
            // 
            // AddNewCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 450);
            Controls.Add(HotelComboBox);
            Controls.Add(PriceTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(AddButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddNewCategory";
            Text = "AddNewCategory";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button AddButton;
        private TextBox NameTextBox;
        private TextBox PriceTextBox;
        private ComboBox HotelComboBox;
    }
}