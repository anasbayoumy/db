namespace HotelManagement.Forms
{
    partial class AddNewService
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
            Add = new Button();
            label1 = new Label();
            NameTextBox = new TextBox();
            DescriptionTextBox = new RichTextBox();
            label2 = new Label();
            Label3 = new Label();
            PriceTextBox = new TextBox();
            SuspendLayout();
            // 
            // Add
            // 
            Add.Location = new Point(147, 468);
            Add.Name = "Add";
            Add.Size = new Size(91, 55);
            Add.TabIndex = 1;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(122, 36);
            label1.Name = "label1";
            label1.Size = new Size(147, 30);
            label1.TabIndex = 2;
            label1.Text = "Service Name";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(106, 81);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(176, 27);
            NameTextBox.TabIndex = 3;
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new Point(63, 162);
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.Size = new Size(248, 150);
            DescriptionTextBox.TabIndex = 4;
            DescriptionTextBox.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(135, 120);
            label2.Name = "label2";
            label2.Size = new Size(122, 30);
            label2.TabIndex = 5;
            label2.Text = "Description";
            label2.Click += label2_Click;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Label3.Location = new Point(166, 338);
            Label3.Name = "Label3";
            Label3.Size = new Size(60, 30);
            Label3.TabIndex = 6;
            Label3.Text = "Price";
            // 
            // PriceTextBox
            // 
            PriceTextBox.Location = new Point(106, 386);
            PriceTextBox.Name = "PriceTextBox";
            PriceTextBox.Size = new Size(176, 27);
            PriceTextBox.TabIndex = 7;
            // 
            // AddNewService
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 556);
            Controls.Add(PriceTextBox);
            Controls.Add(Label3);
            Controls.Add(label2);
            Controls.Add(DescriptionTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(label1);
            Controls.Add(Add);
            Name = "AddNewService";
            Text = "AddNewService";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Add;
        private Label label1;
        private TextBox NameTextBox;
        private RichTextBox DescriptionTextBox;
        private Label label2;
        private Label Label3;
        private TextBox PriceTextBox;
    }
}