using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HotelManagement.Data;
using System.Data.SqlClient;

namespace HotelManagement.Forms
{
    public class AddReservationForm : Form
    {
        public int GuestId { get; private set; }
        public int HotelId { get; private set; }
        public List<string> RoomNumbers { get; private set; }
        public DateTime CheckInDate => checkInPicker.Value;
        public DateTime CheckOutDate => checkOutPicker.Value;

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
            checkInPicker = new DateTimePicker { Location = new Point(150, 240), Format = DateTimePickerFormat.Short, Value = DateTime.Today, MinDate = DateTime.Today };

            Label checkOutLabel = new Label { Text = "Check-out Date:", Location = new Point(20, 280), Size = new Size(100, 20) };
            checkOutPicker = new DateTimePicker { Location = new Point(150, 280), Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddDays(1), MinDate = DateTime.Today.AddDays(1) };

            saveButton = new Button { Text = "Save", Location = new Point(50, 350) };
            saveButton.Size = new Size(75, 50);
            saveButton.Click += SaveButton_Click;

            cancelButton = new Button { Text = "Cancel", Location = new Point(200, 350) };
            cancelButton.Size = new Size(75, 50);
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
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    //connection.Open();
                    string query = "SELECT Guest_ID, Name FROM Guest";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dt.Columns.Add("DisplayText", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            row["DisplayText"] = $"{row["Guest_ID"]} - {row["Name"]}";
                        }
                        guestComboBox.DataSource = dt;
                        guestComboBox.DisplayMember = "DisplayText";
                        guestComboBox.ValueMember = "Guest_ID";
                    }
                }
            }
        }

        private void LoadHotels()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    //connection.Open();
                    string query = "SELECT Hotel_ID, Name FROM Hotel";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        hotelComboBox.DataSource = dt;
                        dt.Columns.Add("DisplayText", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            row["DisplayText"] = $"{row["Hotel_ID"]} - {row["Name"]}";
                        }
                        hotelComboBox.DisplayMember = "DisplayText";
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
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    if (connection != null)
                    {
                        //connection.Open();
                        string query = @"SELECT Room_Num FROM Room WHERE Hotel_ID = @HotelID AND Status = 'Available'";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@HotelID", hotelId);
                            using (SqlDataReader reader = cmd.ExecuteReader())
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
