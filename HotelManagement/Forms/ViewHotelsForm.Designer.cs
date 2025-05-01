namespace HotelManagement.Forms
{
    partial class ViewHotelsForm
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
            HotelsGrid = new DataGridView();
            AddButton = new Button();
            UpdateButton = new Button();
            DeleteButton = new Button();
            viewEmailsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)HotelsGrid).BeginInit();
            SuspendLayout();
            // 
            // HotelsGrid
            // 
            HotelsGrid.AllowUserToAddRows = false;
            HotelsGrid.AllowUserToDeleteRows = false;
            HotelsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            HotelsGrid.Dock = DockStyle.Top;
            HotelsGrid.Location = new Point(0, 0);
            HotelsGrid.MultiSelect = false;
            HotelsGrid.Name = "HotelsGrid";
            HotelsGrid.RowHeadersWidth = 51;
            HotelsGrid.RowTemplate.Height = 29;
            HotelsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            HotelsGrid.Size = new Size(800, 201);
            HotelsGrid.TabIndex = 0;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(85, 267);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(118, 48);
            AddButton.TabIndex = 1;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(262, 267);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(118, 48);
            UpdateButton.TabIndex = 2;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(418, 267);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(118, 48);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // viewEmailsButton
            // 
            viewEmailsButton.Location = new Point(582, 267);
            viewEmailsButton.Name = "viewEmailsButton";
            viewEmailsButton.Size = new Size(118, 48);
            viewEmailsButton.TabIndex = 4;
            viewEmailsButton.Text = "View Emails";
            viewEmailsButton.UseVisualStyleBackColor = true;
            // 
            // ViewHotelsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(viewEmailsButton);
            Controls.Add(DeleteButton);
            Controls.Add(UpdateButton);
            Controls.Add(AddButton);
            Controls.Add(HotelsGrid);
            Name = "ViewHotelsForm";
            Text = "ViewHotelsForm";
            ((System.ComponentModel.ISupportInitialize)HotelsGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView HotelsGrid;
        private Button AddButton;
        private Button UpdateButton;
        private Button DeleteButton;
        private Button viewEmailsButton;
    }
}