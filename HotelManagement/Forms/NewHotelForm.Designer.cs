namespace HotelManagement.Forms
{
    partial class NewHotelForm
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
            NameTextBox = new TextBox();
            LocationTextBox = new TextBox();
            roomsTextBox = new TextBox();
            AddButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 56);
            label1.Name = "label1";
            label1.Size = new Size(71, 30);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 118);
            label2.Name = "label2";
            label2.Size = new Size(94, 30);
            label2.TabIndex = 1;
            label2.Text = "Location";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 182);
            label3.Name = "label3";
            label3.Size = new Size(136, 30);
            label3.TabIndex = 2;
            label3.Text = "No of rooms";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(165, 56);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(176, 27);
            NameTextBox.TabIndex = 3;
            // 
            // LocationTextBox
            // 
            LocationTextBox.Location = new Point(165, 123);
            LocationTextBox.Name = "LocationTextBox";
            LocationTextBox.Size = new Size(176, 27);
            LocationTextBox.TabIndex = 4;
            // 
            // roomsTextBox
            // 
            roomsTextBox.Location = new Point(165, 187);
            roomsTextBox.Name = "roomsTextBox";
            roomsTextBox.Size = new Size(176, 27);
            roomsTextBox.TabIndex = 5;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(128, 268);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(123, 67);
            AddButton.TabIndex = 6;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // NewHotelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 450);
            Controls.Add(AddButton);
            Controls.Add(roomsTextBox);
            Controls.Add(LocationTextBox);
            Controls.Add(NameTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "NewHotelForm";
            Text = "NewHotelForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox NameTextBox;
        private TextBox LocationTextBox;
        private TextBox roomsTextBox;
        private Button AddButton;
    }
}