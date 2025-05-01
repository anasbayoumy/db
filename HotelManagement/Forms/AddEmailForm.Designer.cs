namespace HotelManagement.Forms
{
    partial class AddEmailForm
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
            Emailtextbox = new TextBox();
            Add = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(28, 121);
            label1.Name = "label1";
            label1.Size = new Size(64, 30);
            label1.TabIndex = 0;
            label1.Text = "Email";
            // 
            // Emailtextbox
            // 
            Emailtextbox.Location = new Point(98, 126);
            Emailtextbox.Name = "Emailtextbox";
            Emailtextbox.Size = new Size(170, 27);
            Emailtextbox.TabIndex = 1;
            // 
            // Add
            // 
            Add.Location = new Point(80, 202);
            Add.Name = "Add";
            Add.Size = new Size(114, 48);
            Add.TabIndex = 2;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // AddEmailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 450);
            Controls.Add(Add);
            Controls.Add(Emailtextbox);
            Controls.Add(label1);
            Name = "AddEmailForm";
            Text = "AddEmailForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox Emailtextbox;
        private Button Add;
    }
}