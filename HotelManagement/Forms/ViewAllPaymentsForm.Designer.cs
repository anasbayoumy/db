namespace HotelManagement.Forms
{
    partial class ViewAllPaymentsForm
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
            PaymentsGrid = new DataGridView();
            Add = new Button();
            Update = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)PaymentsGrid).BeginInit();
            SuspendLayout();
            // 
            // PaymentsGrid
            // 
            PaymentsGrid.AllowUserToAddRows = false;
            PaymentsGrid.AllowUserToDeleteRows = false;
            PaymentsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            PaymentsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PaymentsGrid.Dock = DockStyle.Top;
            PaymentsGrid.Location = new Point(0, 0);
            PaymentsGrid.MultiSelect = false;
            PaymentsGrid.Name = "PaymentsGrid";
            PaymentsGrid.RowHeadersWidth = 51;
            PaymentsGrid.RowTemplate.Height = 29;
            PaymentsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PaymentsGrid.Size = new Size(800, 232);
            PaymentsGrid.TabIndex = 0;
            // 
            // Add
            // 
            Add.Location = new Point(123, 289);
            Add.Name = "Add";
            Add.Size = new Size(115, 55);
            Add.TabIndex = 1;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // Update
            // 
            Update.Location = new Point(345, 289);
            Update.Name = "Update";
            Update.Size = new Size(115, 55);
            Update.TabIndex = 2;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // button3
            // 
            button3.Location = new Point(575, 289);
            button3.Name = "button3";
            button3.Size = new Size(115, 55);
            button3.TabIndex = 3;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ViewAllPaymentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(Update);
            Controls.Add(Add);
            Controls.Add(PaymentsGrid);
            Name = "ViewAllPaymentsForm";
            Text = "ViewAllPaymentsForm";
            ((System.ComponentModel.ISupportInitialize)PaymentsGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView PaymentsGrid;
        private Button Add;
        private Button Update;
        private Button button3;
    }
}