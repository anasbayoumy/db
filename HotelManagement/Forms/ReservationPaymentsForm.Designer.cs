namespace HotelManagement.Forms
{
    partial class ReservationPaymentsForm
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
            ReservationPaymentsGrid = new DataGridView();
            AddPayment = new Button();
            updatePayment = new Button();
            DeletePayment = new Button();
            AmountDue = new Label();
            Amount = new Label();
            ((System.ComponentModel.ISupportInitialize)ReservationPaymentsGrid).BeginInit();
            SuspendLayout();
            // 
            // ReservationPaymentsGrid
            // 
            ReservationPaymentsGrid.AllowUserToAddRows = false;
            ReservationPaymentsGrid.AllowUserToDeleteRows = false;
            ReservationPaymentsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ReservationPaymentsGrid.Dock = DockStyle.Top;
            ReservationPaymentsGrid.Location = new Point(0, 0);
            ReservationPaymentsGrid.Name = "ReservationPaymentsGrid";
            ReservationPaymentsGrid.RowHeadersWidth = 51;
            ReservationPaymentsGrid.RowTemplate.Height = 29;
            ReservationPaymentsGrid.Size = new Size(800, 233);
            ReservationPaymentsGrid.TabIndex = 0;
            // 
            // AddPayment
            // 
            AddPayment.Location = new Point(149, 320);
            AddPayment.Name = "AddPayment";
            AddPayment.Size = new Size(120, 44);
            AddPayment.TabIndex = 1;
            AddPayment.Text = "Add Payment";
            AddPayment.UseVisualStyleBackColor = true;
            // 
            // updatePayment
            // 
            updatePayment.Location = new Point(293, 320);
            updatePayment.Name = "updatePayment";
            updatePayment.Size = new Size(120, 44);
            updatePayment.TabIndex = 2;
            updatePayment.Text = "Update";
            updatePayment.UseVisualStyleBackColor = true;
            // 
            // DeletePayment
            // 
            DeletePayment.Location = new Point(438, 320);
            DeletePayment.Name = "DeletePayment";
            DeletePayment.Size = new Size(120, 44);
            DeletePayment.TabIndex = 3;
            DeletePayment.Text = "Delete";
            DeletePayment.UseVisualStyleBackColor = true;
            // 
            // AmountDue
            // 
            AmountDue.AutoSize = true;
            AmountDue.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            AmountDue.Location = new Point(12, 257);
            AmountDue.Name = "AmountDue";
            AmountDue.Size = new Size(140, 30);
            AmountDue.TabIndex = 4;
            AmountDue.Text = "Amount Due:";
            // 
            // Amount
            // 
            Amount.AutoSize = true;
            Amount.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Amount.Location = new Point(158, 257);
            Amount.Name = "Amount";
            Amount.Size = new Size(25, 30);
            Amount.TabIndex = 5;
            Amount.Text = "0";
            // 
            // ReservationPaymentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Amount);
            Controls.Add(AmountDue);
            Controls.Add(DeletePayment);
            Controls.Add(updatePayment);
            Controls.Add(AddPayment);
            Controls.Add(ReservationPaymentsGrid);
            Name = "ReservationPaymentsForm";
            Text = "ReservationPaymentsForm";
            ((System.ComponentModel.ISupportInitialize)ReservationPaymentsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ReservationPaymentsGrid;
        private Button AddPayment;
        private Button updatePayment;
        private Button DeletePayment;
        private Label AmountDue;
        private Label Amount;
    }
}