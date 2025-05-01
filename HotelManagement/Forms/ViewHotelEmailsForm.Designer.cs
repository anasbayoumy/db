namespace HotelManagement.Forms
{
    partial class ViewHotelEmailsForm
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
            EmailsGrid = new DataGridView();
            button1 = new Button();
            Delete = new Button();
            ((System.ComponentModel.ISupportInitialize)EmailsGrid).BeginInit();
            SuspendLayout();
            // 
            // EmailsGrid
            // 
            EmailsGrid.AllowUserToAddRows = false;
            EmailsGrid.AllowUserToDeleteRows = false;
            EmailsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            EmailsGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            EmailsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EmailsGrid.Dock = DockStyle.Top;
            EmailsGrid.Location = new Point(0, 0);
            EmailsGrid.Name = "EmailsGrid";
            EmailsGrid.RowHeadersWidth = 51;
            EmailsGrid.RowTemplate.Height = 29;
            EmailsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            EmailsGrid.Size = new Size(438, 218);
            EmailsGrid.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(46, 290);
            button1.Name = "button1";
            button1.Size = new Size(112, 51);
            button1.TabIndex = 1;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(256, 290);
            Delete.Name = "Delete";
            Delete.Size = new Size(112, 51);
            Delete.TabIndex = 2;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // ViewHotelEmailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 450);
            Controls.Add(Delete);
            Controls.Add(button1);
            Controls.Add(EmailsGrid);
            Name = "ViewHotelEmailsForm";
            Text = "ViewHotelEmailsForm";
            ((System.ComponentModel.ISupportInitialize)EmailsGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView EmailsGrid;
        private Button button1;
        private Button Delete;
    }
}