namespace HotelManagement.Forms
{
    partial class UpdateFeedback
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
            GuestComboBox = new ComboBox();
            HotelComboBox = new ComboBox();
            RatingComboBox = new ComboBox();
            Update = new Button();
            CommentTextBox = new RichTextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // GuestComboBox
            // 
            GuestComboBox.FormattingEnabled = true;
            GuestComboBox.Location = new Point(154, 35);
            GuestComboBox.Name = "GuestComboBox";
            GuestComboBox.Size = new Size(239, 28);
            GuestComboBox.TabIndex = 20;
            // 
            // HotelComboBox
            // 
            HotelComboBox.FormattingEnabled = true;
            HotelComboBox.Location = new Point(154, 101);
            HotelComboBox.Name = "HotelComboBox";
            HotelComboBox.Size = new Size(239, 28);
            HotelComboBox.TabIndex = 19;
            // 
            // RatingComboBox
            // 
            RatingComboBox.FormattingEnabled = true;
            RatingComboBox.Location = new Point(154, 314);
            RatingComboBox.Name = "RatingComboBox";
            RatingComboBox.Size = new Size(239, 28);
            RatingComboBox.TabIndex = 18;
            // 
            // Update
            // 
            Update.Location = new Point(154, 384);
            Update.Name = "Update";
            Update.Size = new Size(94, 29);
            Update.TabIndex = 17;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // CommentTextBox
            // 
            CommentTextBox.Location = new Point(154, 179);
            CommentTextBox.Name = "CommentTextBox";
            CommentTextBox.Size = new Size(239, 89);
            CommentTextBox.TabIndex = 16;
            CommentTextBox.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(32, 309);
            label4.Name = "label4";
            label4.Size = new Size(74, 30);
            label4.TabIndex = 15;
            label4.Text = "Rating";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(32, 174);
            label3.Name = "label3";
            label3.Size = new Size(109, 30);
            label3.TabIndex = 14;
            label3.Text = "Comment";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(32, 101);
            label2.Name = "label2";
            label2.Size = new Size(66, 30);
            label2.TabIndex = 13;
            label2.Text = "Hotel";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(32, 30);
            label1.Name = "label1";
            label1.Size = new Size(68, 30);
            label1.TabIndex = 12;
            label1.Text = "Guest";
            // 
            // UpdateFeedback
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 450);
            Controls.Add(GuestComboBox);
            Controls.Add(HotelComboBox);
            Controls.Add(RatingComboBox);
            Controls.Add(Update);
            Controls.Add(CommentTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UpdateFeedback";
            Text = "UpdateFeedback";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox GuestComboBox;
        private ComboBox HotelComboBox;
        private ComboBox RatingComboBox;
        private Button Update;
        private RichTextBox CommentTextBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}