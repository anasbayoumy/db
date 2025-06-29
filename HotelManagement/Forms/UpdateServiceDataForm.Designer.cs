namespace HotelManagement.Forms
{
    partial class UpdateServiceDataForm
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
            PriceTextBox = new TextBox();
            Label3 = new Label();
            label2 = new Label();
            DescriptionTextBox = new RichTextBox();
            NameTextBox = new TextBox();
            label1 = new Label();
            Add = new Button();
            SuspendLayout();
            // 
            // PriceTextBox
            // 
            PriceTextBox.Location = new Point(70, 391);
            PriceTextBox.Name = "PriceTextBox";
            PriceTextBox.Size = new Size(176, 27);
            PriceTextBox.TabIndex = 14;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Label3.Location = new Point(130, 343);
            Label3.Name = "Label3";
            Label3.Size = new Size(60, 30);
            Label3.TabIndex = 13;
            Label3.Text = "Price";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(99, 125);
            label2.Name = "label2";
            label2.Size = new Size(122, 30);
            label2.TabIndex = 12;
            label2.Text = "Description";
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new Point(27, 167);
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(248, 150);
            DescriptionTextBox.TabIndex = 11;
            DescriptionTextBox.Text = "";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(70, 86);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(176, 27);
            NameTextBox.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(87, 39);
            label1.Name = "label1";
            label1.Size = new Size(147, 30);
            label1.TabIndex = 9;
            label1.Text = "Service Name";
            label1.Click += label1_Click;
            // 
            // Add
            // 
            Add.Location = new Point(111, 457);
            Add.Name = "Add";
            Add.Size = new Size(91, 55);
            Add.TabIndex = 8;
            Add.Text = "Update";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // UpdateServiceDataForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 540);
            Controls.Add(PriceTextBox);
            Controls.Add(Label3);
            Controls.Add(label2);
            Controls.Add(DescriptionTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(label1);
            Controls.Add(Add);
            Name = "UpdateServiceDataForm";
            Text = "UpdateServiceDataForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PriceTextBox;
        private Label Label3;
        private Label label2;
        private RichTextBox DescriptionTextBox;
        private TextBox NameTextBox;
        private Label label1;
        private Button Add;
    }
}