namespace HotelManagement.Forms
{
    partial class ViewRoomCategories
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
            RoomCategoriesGrid = new DataGridView();
            AddCategory = new Button();
            UpdateCategory = new Button();
            DeleteCategory = new Button();
            ((System.ComponentModel.ISupportInitialize)RoomCategoriesGrid).BeginInit();
            SuspendLayout();
            // 
            // RoomCategoriesGrid
            // 
            RoomCategoriesGrid.AllowUserToAddRows = false;
            RoomCategoriesGrid.AllowUserToDeleteRows = false;
            RoomCategoriesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RoomCategoriesGrid.Dock = DockStyle.Top;
            RoomCategoriesGrid.Location = new Point(0, 0);
            RoomCategoriesGrid.MultiSelect = false;
            RoomCategoriesGrid.Name = "RoomCategoriesGrid";
            RoomCategoriesGrid.RowHeadersWidth = 51;
            RoomCategoriesGrid.RowTemplate.Height = 29;
            RoomCategoriesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RoomCategoriesGrid.Size = new Size(800, 254);
            RoomCategoriesGrid.TabIndex = 0;
            // 
            // AddCategory
            // 
            AddCategory.Location = new Point(162, 321);
            AddCategory.Name = "AddCategory";
            AddCategory.Size = new Size(116, 46);
            AddCategory.TabIndex = 1;
            AddCategory.Text = "Add";
            AddCategory.UseVisualStyleBackColor = true;
            AddCategory.Click += AddCategory_Click;
            // 
            // UpdateCategory
            // 
            UpdateCategory.Location = new Point(339, 320);
            UpdateCategory.Name = "UpdateCategory";
            UpdateCategory.Size = new Size(116, 46);
            UpdateCategory.TabIndex = 2;
            UpdateCategory.Text = "Update";
            UpdateCategory.UseVisualStyleBackColor = true;
            UpdateCategory.Click += UpdateCategory_Click;
            // 
            // DeleteCategory
            // 
            DeleteCategory.Location = new Point(528, 322);
            DeleteCategory.Name = "DeleteCategory";
            DeleteCategory.Size = new Size(116, 44);
            DeleteCategory.TabIndex = 3;
            DeleteCategory.Text = "Delete";
            DeleteCategory.UseVisualStyleBackColor = true;
            DeleteCategory.Click += DeleteCategory_Click;
            // 
            // ViewRoomCategories
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DeleteCategory);
            Controls.Add(UpdateCategory);
            Controls.Add(AddCategory);
            Controls.Add(RoomCategoriesGrid);
            Name = "ViewRoomCategories";
            Text = "ViewRoomCategories";
            ((System.ComponentModel.ISupportInitialize)RoomCategoriesGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView RoomCategoriesGrid;
        private Button AddCategory;
        private Button UpdateCategory;
        private Button DeleteCategory;
    }
}