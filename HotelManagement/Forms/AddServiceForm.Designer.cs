namespace HotelManagement.Forms
{
    partial class AddServiceForm
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
            ServiceOptions = new ComboBox();
            label1 = new Label();
            quantityCounter = new NumericUpDown();
            label2 = new Label();
            addService = new Button();
            ((System.ComponentModel.ISupportInitialize)quantityCounter).BeginInit();
            SuspendLayout();
            // 
            // ServiceOptions
            // 
            ServiceOptions.FormattingEnabled = true;
            ServiceOptions.Location = new Point(123, 35);
            ServiceOptions.Name = "ServiceOptions";
            ServiceOptions.Size = new Size(187, 28);
            ServiceOptions.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(83, 30);
            label1.TabIndex = 1;
            label1.Text = "Service";
            label1.Click += label1_Click;
            // 
            // quantityCounter
            // 
            quantityCounter.Location = new Point(123, 125);
            quantityCounter.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            quantityCounter.Name = "quantityCounter";
            quantityCounter.Size = new Size(187, 27);
            quantityCounter.TabIndex = 2;
            quantityCounter.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 119);
            label2.Name = "label2";
            label2.Size = new Size(95, 30);
            label2.TabIndex = 3;
            label2.Text = "Quantity";
            // 
            // addService
            // 
            addService.Location = new Point(109, 226);
            addService.Name = "addService";
            addService.Size = new Size(118, 51);
            addService.TabIndex = 4;
            addService.Text = "Add";
            addService.UseVisualStyleBackColor = true;
            addService.Click += addService_Click;
            // 
            // AddServiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 392);
            Controls.Add(addService);
            Controls.Add(label2);
            Controls.Add(quantityCounter);
            Controls.Add(label1);
            Controls.Add(ServiceOptions);
            Name = "AddServiceForm";
            Text = "AddServiceForm";
            ((System.ComponentModel.ISupportInitialize)quantityCounter).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ServiceOptions;
        private Label label1;
        private NumericUpDown quantityCounter;
        private Label label2;
        private Button addService;
    }
}