namespace HotelManagement.Forms
{
    partial class AddFeedback
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
            label4 = new Label();
            CommentTextBox = new RichTextBox();
            Add = new Button();
            RatingComboBox = new ComboBox();
            HotelComboBox = new ComboBox();
            GuestComboBox = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(44, 36);
            label1.Name = "label1";
            label1.Size = new Size(68, 30);
            label1.TabIndex = 0;
            label1.Text = "Guest";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(44, 107);
            label2.Name = "label2";
            label2.Size = new Size(66, 30);
            label2.TabIndex = 1;
            label2.Text = "Hotel";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(44, 180);
            label3.Name = "label3";
            label3.Size = new Size(109, 30);
            label3.TabIndex = 2;
            label3.Text = "Comment";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(44, 315);
            label4.Name = "label4";
            label4.Size = new Size(74, 30);
            label4.TabIndex = 3;
            label4.Text = "Rating";
            // 
            // CommentTextBox
            // 
            CommentTextBox.Location = new Point(166, 185);
            CommentTextBox.Name = "CommentTextBox";
            CommentTextBox.Size = new Size(239, 89);
            CommentTextBox.TabIndex = 4;
            CommentTextBox.Text = "";
            // 
            // Add
            // 
            Add.Location = new Point(166, 390);
            Add.Name = "Add";
            Add.Size = new Size(94, 29);
            Add.TabIndex = 8;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // RatingComboBox
            // 
            RatingComboBox.FormattingEnabled = true;
            RatingComboBox.Location = new Point(166, 320);
            RatingComboBox.Name = "RatingComboBox";
            RatingComboBox.Size = new Size(239, 28);
            RatingComboBox.TabIndex = 9;
            // 
            // HotelComboBox
            // 
            HotelComboBox.FormattingEnabled = true;
            HotelComboBox.Location = new Point(166, 107);
            HotelComboBox.Name = "HotelComboBox";
            HotelComboBox.Size = new Size(239, 28);
            HotelComboBox.TabIndex = 10;
            // 
            // GuestComboBox
            // 
            GuestComboBox.FormattingEnabled = true;
            GuestComboBox.Location = new Point(166, 41);
            GuestComboBox.Name = "GuestComboBox";
            GuestComboBox.Size = new Size(239, 28);
            GuestComboBox.TabIndex = 11;
            // 
            // AddFeedback
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 450);
            Controls.Add(GuestComboBox);
            Controls.Add(HotelComboBox);
            Controls.Add(RatingComboBox);
            Controls.Add(Add);
            Controls.Add(CommentTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddFeedback";
            Text = "AddFeedback";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RichTextBox CommentTextBox;
        private Button Add;
        private ComboBox RatingComboBox;
        private ComboBox HotelComboBox;
        private ComboBox GuestComboBox;
    }
}