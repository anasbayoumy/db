
namespace HotelManagement.Forms
{
    partial class ReservationServicesForm
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
            RservationServicesGrid = new DataGridView();
            UpdateService = new Button();
            DeleteService = new Button();
            AddService = new Button();
            ((System.ComponentModel.ISupportInitialize)RservationServicesGrid).BeginInit();
            SuspendLayout();
            // 
            // RservationServicesGrid
            // 
            RservationServicesGrid.AllowUserToAddRows = false;
            RservationServicesGrid.AllowUserToDeleteRows = false;
            RservationServicesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RservationServicesGrid.Dock = DockStyle.Top;
            RservationServicesGrid.Location = new Point(0, 0);
            RservationServicesGrid.Name = "RservationServicesGrid";
            RservationServicesGrid.RowHeadersWidth = 51;
            RservationServicesGrid.RowTemplate.Height = 29;
            RservationServicesGrid.Size = new Size(800, 207);
            RservationServicesGrid.TabIndex = 0;
            // 
            // UpdateService
            // 
            UpdateService.Location = new Point(325, 280);
            UpdateService.Name = "UpdateService";
            UpdateService.Size = new Size(108, 44);
            UpdateService.TabIndex = 1;
            UpdateService.Text = "Update";
            UpdateService.UseVisualStyleBackColor = true;
            UpdateService.Click += UpdateService_Click;
            // 
            // DeleteService
            // 
            DeleteService.Location = new Point(485, 280);
            DeleteService.Name = "DeleteService";
            DeleteService.Size = new Size(108, 44);
            DeleteService.TabIndex = 2;
            DeleteService.Text = "Delete";
            DeleteService.UseVisualStyleBackColor = true;
            DeleteService.Click += DeleteService_Click;
            // 
            // AddService
            // 
            AddService.Location = new Point(169, 280);
            AddService.Name = "AddService";
            AddService.Size = new Size(102, 44);
            AddService.TabIndex = 3;
            AddService.Text = "Add";
            AddService.UseVisualStyleBackColor = true;
            AddService.Click += AddService_Click;
            // 
            // ReservationServicesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddService);
            Controls.Add(DeleteService);
            Controls.Add(UpdateService);
            Controls.Add(RservationServicesGrid);
            Name = "ReservationServicesForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)RservationServicesGrid).EndInit();
            ResumeLayout(false);
        }




        #endregion

        private DataGridView RservationServicesGrid;
        private Button UpdateService;
        private Button DeleteService;
        private Button AddService;
    }
}