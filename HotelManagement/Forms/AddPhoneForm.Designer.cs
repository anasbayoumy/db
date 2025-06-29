namespace HotelManagement.Forms
{
    partial class AddPhoneForm
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
            Phone = new TextBox();
            AddButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(45, 69);
            label1.Name = "label1";
            label1.Size = new Size(216, 30);
            label1.TabIndex = 0;
            label1.Text = "Enter Phone Number";
            // 
            // Phone
            // 
            Phone.Location = new Point(45, 116);
            Phone.Name = "Phone";
            Phone.Size = new Size(216, 27);
            Phone.TabIndex = 1;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(95, 168);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(107, 40);
            AddButton.TabIndex = 2;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // AddPhoneForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 237);
            Controls.Add(AddButton);
            Controls.Add(Phone);
            Controls.Add(label1);
            Name = "AddPhoneForm";
            Text = "AddPhoneForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox Phone;
        private Button AddButton;
    }
}