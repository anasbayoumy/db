namespace HotelManagement.Forms
{
    partial class ViewFeedbackForm
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
            FeedbackGrid = new DataGridView();
            Add = new Button();
            Update = new Button();
            Delete = new Button();
            ((System.ComponentModel.ISupportInitialize)FeedbackGrid).BeginInit();
            SuspendLayout();
            // 
            // FeedbackGrid
            // 
            FeedbackGrid.AllowUserToAddRows = false;
            FeedbackGrid.AllowUserToDeleteRows = false;
            FeedbackGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            FeedbackGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FeedbackGrid.Dock = DockStyle.Top;
            FeedbackGrid.Location = new Point(0, 0);
            FeedbackGrid.MultiSelect = false;
            FeedbackGrid.Name = "FeedbackGrid";
            FeedbackGrid.RowHeadersWidth = 51;
            FeedbackGrid.RowTemplate.Height = 29;
            FeedbackGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            FeedbackGrid.Size = new Size(800, 224);
            FeedbackGrid.TabIndex = 0;
            // 
            // Add
            // 
            Add.Location = new Point(105, 270);
            Add.Name = "Add";
            Add.Size = new Size(108, 44);
            Add.TabIndex = 1;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // Update
            // 
            Update.Location = new Point(297, 270);
            Update.Name = "Update";
            Update.Size = new Size(113, 44);
            Update.TabIndex = 2;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(491, 270);
            Delete.Name = "Delete";
            Delete.Size = new Size(116, 44);
            Delete.TabIndex = 3;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // ViewFeedbackForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Delete);
            Controls.Add(Update);
            Controls.Add(Add);
            Controls.Add(FeedbackGrid);
            Name = "ViewFeedbackForm";
            Text = "ViewFeedbackForm";
            ((System.ComponentModel.ISupportInitialize)FeedbackGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView FeedbackGrid;
        private Button Add;
        private Button Update;
        private Button Delete;
    }
}