namespace HotelManagement.Forms
{
    partial class GuestPhonesForm
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
            GuestPhonesGrid = new DataGridView();
            AddPhoneButton = new Button();
            DeletePhoneButton = new Button();
            ((System.ComponentModel.ISupportInitialize)GuestPhonesGrid).BeginInit();
            SuspendLayout();
            // 
            // GuestPhonesGrid
            // 
            GuestPhonesGrid.AllowUserToAddRows = false;
            GuestPhonesGrid.AllowUserToDeleteRows = false;
            GuestPhonesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GuestPhonesGrid.Dock = DockStyle.Top;
            GuestPhonesGrid.Location = new Point(0, 0);
            GuestPhonesGrid.Name = "GuestPhonesGrid";
            GuestPhonesGrid.RowHeadersWidth = 51;
            GuestPhonesGrid.RowTemplate.Height = 29;
            GuestPhonesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GuestPhonesGrid.Size = new Size(430, 221);
            GuestPhonesGrid.TabIndex = 0;
            // 
            // AddPhoneButton
            // 
            AddPhoneButton.Location = new Point(41, 283);
            AddPhoneButton.Name = "AddPhoneButton";
            AddPhoneButton.Size = new Size(113, 39);
            AddPhoneButton.TabIndex = 1;
            AddPhoneButton.Text = "Add";
            AddPhoneButton.UseVisualStyleBackColor = true;
            AddPhoneButton.Click += AddPhoneButton_Click;
            // 
            // DeletePhoneButton
            // 
            DeletePhoneButton.Location = new Point(253, 283);
            DeletePhoneButton.Name = "DeletePhoneButton";
            DeletePhoneButton.Size = new Size(113, 39);
            DeletePhoneButton.TabIndex = 2;
            DeletePhoneButton.Text = "Delete";
            DeletePhoneButton.UseVisualStyleBackColor = true;
            DeletePhoneButton.Click += DeletePhoneButton_Click;
            // 
            // GuestPhonesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 450);
            Controls.Add(DeletePhoneButton);
            Controls.Add(AddPhoneButton);
            Controls.Add(GuestPhonesGrid);
            Name = "GuestPhonesForm";
            Text = "GuestPhonesForm";
            ((System.ComponentModel.ISupportInitialize)GuestPhonesGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView GuestPhonesGrid;
        private Button AddPhoneButton;
        private Button DeletePhoneButton;
    }
}