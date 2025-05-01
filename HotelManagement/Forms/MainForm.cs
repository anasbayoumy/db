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

            Button CategoryButton = new Button
            {
                Text = "Manage Room Categories",
                Location = new System.Drawing.Point(50, 200),
                Size = new System.Drawing.Size(300, 40)
            };
            CategoryButton.Click += CategoryButton_Click;

            Button hotelButton = new Button
            {
                Text = "Manage Hotels",
                Location = new System.Drawing.Point(50, 250),
                Size = new System.Drawing.Size(300, 40)
            };
            hotelButton.Click += HotelButton_Click;

            Button servicesButton = new Button
            {
                Text = "Manage Services",
                Location = new System.Drawing.Point(50, 300),
                Size = new System.Drawing.Size(300, 40)
            };
            servicesButton.Click += ServicesButton_Click;

            Button paymentButton = new Button
            {
                Text = "Manage Payment",
                Location = new System.Drawing.Point(50, 350),
                Size = new System.Drawing.Size(300, 40)
            };
            paymentButton.Click += PaymentButton_Click;

            Button feedbackButton = new Button
            {
                Text = "Manage Feecback",
                Location = new System.Drawing.Point(50, 400),
                Size = new System.Drawing.Size(300, 40)
            };
            feedbackButton.Click += FeedbackButton_Click;

            // Add controls to form
            //this.Controls.Add(menuStrip);
            this.Controls.Add(guestButton);
            this.Controls.Add(roomButton);
            this.Controls.Add(reservationButton);
            this.Controls.Add(CategoryButton);
            this.Controls.Add(hotelButton);
            this.Controls.Add(servicesButton);
            this.Controls.Add(paymentButton);
            this.Controls.Add(feedbackButton);
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
        private void CategoryButton_Click(object sender, EventArgs e)
        {
            ViewRoomCategories CategoriesForm = new ViewRoomCategories();
            CategoriesForm.ShowDialog();
        }
        private void HotelButton_Click(object sender, EventArgs e)
        {
            ViewHotelsForm HotelsForm = new ViewHotelsForm();
            HotelsForm.ShowDialog();
        }
        private void ServicesButton_Click(object sender, EventArgs e)
        {
            ViewAllservicesForm servicesForm = new ViewAllservicesForm();
            servicesForm.ShowDialog();
        }
        private void PaymentButton_Click(object sender, EventArgs e)
        {
            ViewAllPaymentsForm payment = new ViewAllPaymentsForm();
            payment.ShowDialog();
        }
        private void FeedbackButton_Click(object sender, EventArgs e)
        {
            ReservationForm reservationForm = new ReservationForm();
            reservationForm.ShowDialog();
        }
    }
} 