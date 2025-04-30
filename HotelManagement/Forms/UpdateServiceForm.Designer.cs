namespace HotelManagement.Forms
{
    partial class UpdateServiceForm
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
            QuantityCounter = new NumericUpDown();
            label1 = new Label();
            Update = new Button();
            ((System.ComponentModel.ISupportInitialize)QuantityCounter).BeginInit();
            SuspendLayout();
            // 
            // QuantityCounter
            // 
            QuantityCounter.Location = new Point(135, 96);
            QuantityCounter.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            QuantityCounter.Name = "QuantityCounter";
            QuantityCounter.Size = new Size(150, 27);
            QuantityCounter.TabIndex = 0;
            QuantityCounter.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 93);
            label1.Name = "label1";
            label1.Size = new Size(95, 30);
            label1.TabIndex = 1;
            label1.Text = "Quantity";
            label1.Click += label1_Click;
            // 
            // Update
            // 
            Update.Location = new Point(81, 168);
            Update.Name = "Update";
            Update.Size = new Size(121, 45);
            Update.TabIndex = 2;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // UpdateServiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(297, 276);
            Controls.Add(Update);
            Controls.Add(label1);
            Controls.Add(QuantityCounter);
            Name = "UpdateServiceForm";
            Text = "UpdateServiceForm";
            ((System.ComponentModel.ISupportInitialize)QuantityCounter).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown QuantityCounter;
        private Label label1;
        private Button Update;
    }
}