namespace HotelManagement.Forms
{
    partial class ViewAllservicesForm
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
            ServicesGrid = new DataGridView();
            Add = new Button();
            Update = new Button();
            Delete = new Button();
            ((System.ComponentModel.ISupportInitialize)ServicesGrid).BeginInit();
            SuspendLayout();
            // 
            // ServicesGrid
            // 
            ServicesGrid.AllowUserToAddRows = false;
            ServicesGrid.AllowUserToDeleteRows = false;
            ServicesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ServicesGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ServicesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ServicesGrid.Dock = DockStyle.Top;
            ServicesGrid.Location = new Point(0, 0);
            ServicesGrid.MultiSelect = false;
            ServicesGrid.Name = "ServicesGrid";
            ServicesGrid.RowHeadersWidth = 51;
            ServicesGrid.RowTemplate.Height = 29;
            ServicesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ServicesGrid.Size = new Size(639, 205);
            ServicesGrid.TabIndex = 0;
            // 
            // Add
            // 
            Add.Location = new Point(70, 244);
            Add.Name = "Add";
            Add.Size = new Size(115, 54);
            Add.TabIndex = 1;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // Update
            // 
            Update.Location = new Point(229, 244);
            Update.Name = "Update";
            Update.Size = new Size(115, 54);
            Update.TabIndex = 2;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(379, 244);
            Delete.Name = "Delete";
            Delete.Size = new Size(115, 54);
            Delete.TabIndex = 3;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // ViewAllservicesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 450);
            Controls.Add(Delete);
            Controls.Add(Update);
            Controls.Add(Add);
            Controls.Add(ServicesGrid);
            Name = "ViewAllservicesForm";
            Text = "ViewAllservicesForm";
            ((System.ComponentModel.ISupportInitialize)ServicesGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView ServicesGrid;
        private Button Add;
        private Button Update;
        private Button Delete;
    }
}