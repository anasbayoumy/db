using System;
using System.Windows.Forms;

namespace HotelManagement.Forms
{
    public class ReservationForm : Form
    {
        public ReservationForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Reservation Management";
            this.Size = new System.Drawing.Size(800, 600);
            
            Label placeholderLabel = new Label
            {
                Text = "Reservation Management - Coming Soon",
                Location = new System.Drawing.Point(250, 250),
                AutoSize = true
            };
            
            this.Controls.Add(placeholderLabel);
        }
    }
} 