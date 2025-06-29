namespace HotelManagement.Forms
{
    partial class UpdateHotelForm
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
            UpdateButton = new Button();
            roomsTextBox = new TextBox();
            LocationTextBox = new TextBox();
            NameTextBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(144, 298);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(123, 67);
            UpdateButton.TabIndex = 13;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // roomsTextBox
            // 
            roomsTextBox.Location = new Point(181, 217);
            roomsTextBox.Name = "roomsTextBox";
            roomsTextBox.Size = new Size(176, 27);
            roomsTextBox.TabIndex = 12;
            // 
            // LocationTextBox
            // 
            LocationTextBox.Location = new Point(181, 153);
            LocationTextBox.Name = "LocationTextBox";
            LocationTextBox.Size = new Size(176, 27);
            LocationTextBox.TabIndex = 11;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(181, 86);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(176, 27);
            NameTextBox.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(28, 212);
            label3.Name = "label3";
            label3.Size = new Size(136, 30);
            label3.TabIndex = 9;
            label3.Text = "No of rooms";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(28, 148);
            label2.Name = "label2";
            label2.Size = new Size(94, 30);
            label2.TabIndex = 8;
            label2.Text = "Location";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(28, 86);
            label1.Name = "label1";
            label1.Size = new Size(71, 30);
            label1.TabIndex = 7;
            label1.Text = "Name";
            // 
            // UpdateHotelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 450);
            Controls.Add(UpdateButton);
            Controls.Add(roomsTextBox);
            Controls.Add(LocationTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UpdateHotelForm";
            Text = "UpdateHotelForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button UpdateButton;
        private TextBox roomsTextBox;
        private TextBox LocationTextBox;
        private TextBox NameTextBox;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}