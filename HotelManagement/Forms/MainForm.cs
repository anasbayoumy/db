using System;
using System.Windows.Forms;

namespace HotelManagement.Forms
{
    public class MainForm : Form
    {
        public MainForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Hotel Management System";
            this.Size = new System.Drawing.Size(800, 600);

           /* // Create menu strip
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit");
            exitMenuItem.Click += (s, e) => Application.Exit();
            fileMenu.DropDownItems.Add(exitMenuItem);
            menuStrip.Items.Add(fileMenu);*/

            // Create buttons for different operations
            Button guestButton = new Button
            {
                Text = "Manage Guests",
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(300, 40)
            };
            guestButton.Click += GuestButton_Click;

            Button roomButton = new Button
            {
                Text = "Manage Rooms",
                Location = new System.Drawing.Point(50, 100),
                Size = new System.Drawing.Size(300, 40)
            };
            roomButton.Click += RoomButton_Click;

            Button reservationButton = new Button
            {
                Text = "Manage Reservations",
                Location = new System.Drawing.Point(50, 150),
                Size = new System.Drawing.Size(300, 40)
            };
            reservationButton.Click += ReservationButton_Click;

            // Add controls to form
            //this.Controls.Add(menuStrip);
            this.Controls.Add(guestButton);
            this.Controls.Add(roomButton);
            this.Controls.Add(reservationButton);
        }

        private void GuestButton_Click(object sender, EventArgs e)
        {
            GuestForm guestForm = new GuestForm();
            guestForm.ShowDialog();
        }

        private void RoomButton_Click(object sender, EventArgs e)
        {
            RoomForm roomForm = new RoomForm();
            roomForm.ShowDialog();
        }

        private void ReservationButton_Click(object sender, EventArgs e)
        {
            ReservationForm reservationForm = new ReservationForm();
            reservationForm.ShowDialog();
        }
    }
} 