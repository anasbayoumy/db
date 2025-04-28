using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HotelManagement.Data;
using MySql.Data.MySqlClient;

namespace HotelManagement.Forms
{
    public class AddReservationForm : Form
    {
        public int GuestId { get; private set; }
        public int HotelId { get; private set; }
        public List<string> RoomNumbers { get; private set; }
        public DateTime CheckInDate => checkInPicker.Value.Date;
        public DateTime CheckOutDate => checkOutPicker.Value.Date;

        private ComboBox guestComboBox;
        private ComboBox hotelComboBox;
        private CheckedListBox roomsListBox;
        private DateTimePicker checkInPicker;
        private DateTimePicker checkOutPicker;
        private Button saveButton;
        private Button cancelButton;

        public AddReservationForm()
        {
            InitializeUI();
            LoadGuests();
            LoadHotels();
        }

        private void InitializeUI()
        {
            Text = "Add Reservation";
            Size = new Size(400, 500);

            Label guestLabel = new Label { Text = "Guest:", Location = new Point(20, 20), Size = new Size(100, 20) };
            guestComboBox = new ComboBox { Location = new Point(150, 20), Size = new Size(200, 20) };

            Label hotelLabel = new Label { Text = "Hotel:", Location = new Point(20, 60), Size = new Size(100, 20) };
            hotelComboBox = new ComboBox { Location = new Point(150, 60), Size = new Size(200, 20) };
            hotelComboBox.SelectedIndexChanged += HotelComboBox_SelectedIndexChanged;

            Label roomLabel = new Label { Text = "Rooms:", Location = new Point(20, 100), Size = new Size(100, 20) };
            roomsListBox = new CheckedListBox { Location = new Point(150, 100), Size = new Size(200, 120) };

            Label checkInLabel = new Label { Text = "Check-in Date:", Location = new Point(20, 240), Size = new Size(100, 20) };
            checkInPicker = new DateTimePicker { Location = new Point(150, 240), Format = DateTimePickerFormat.Short };

            Label checkOutLabel = new Label { Text = "Check-out Date:", Location = new Point(20, 280), Size = new Size(100, 20) };
            checkOutPicker = new DateTimePicker { Location = new Point(150, 280), Format = DateTimePickerFormat.Short };

            saveButton = new Button { Text = "Save", Location = new Point(50, 350) };
            saveButton.Click += SaveButton_Click;

            cancelButton = new Button { Text = "Cancel", Location = new Point(200, 350) };
            cancelButton.Click += (s, e) => { DialogResult = DialogResult.Cancel; };

            Controls.Add(guestLabel);
            Controls.Add(guestComboBox);
            Controls.Add(hotelLabel);
            Controls.Add(hotelComboBox);
            Controls.Add(roomLabel);
            Controls.Add(roomsListBox);
            Controls.Add(checkInLabel);
            Controls.Add(checkInPicker);
            Controls.Add(checkOutLabel);
            Controls.Add(checkOutPicker);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
        }

        private void LoadGuests()
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    //connection.Open();
                    string query = "SELECT Guest_ID, Name FROM Guest";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        guestComboBox.DataSource = dt;
                        guestComboBox.DisplayMember = "Name";
                        guestComboBox.ValueMember = "Guest_ID";
                    }
                }
            }
        }

        private void LoadHotels()
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    //connection.Open();
                    string query = "SELECT Hotel_ID, Name FROM Hotel";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        hotelComboBox.DataSource = dt;
                        hotelComboBox.DisplayMember = "Name";
                        hotelComboBox.ValueMember = "Hotel_ID";
                    }
                }
            }
        }

        private void HotelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hotelComboBox.SelectedValue is int hotelId)
            {
                roomsListBox.Items.Clear();
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    if (connection != null)
                    {
                        //connection.Open();
                        string query = @"SELECT Room_Num FROM Room WHERE Hotel_ID = @HotelID AND Status = 'Available'";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@HotelID", hotelId);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    roomsListBox.Items.Add(reader["Room_Num"].ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (guestComboBox.SelectedValue == null || hotelComboBox.SelectedValue == null || roomsListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select Guest, Hotel, and at least one Room.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkOutPicker.Value <= checkInPicker.Value)
            {
                MessageBox.Show("Check-out date must be after Check-in date.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GuestId = (int)guestComboBox.SelectedValue;
            HotelId = (int)hotelComboBox.SelectedValue;
            RoomNumbers = new List<string>();

            foreach (var item in roomsListBox.CheckedItems)
            {
                RoomNumbers.Add(item.ToString());
            }

            DialogResult = DialogResult.OK;
        }
    }
}
