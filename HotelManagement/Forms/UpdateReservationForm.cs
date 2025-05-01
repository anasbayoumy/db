using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using HotelManagement.Data;

namespace HotelManagement.Forms
{
    public partial class UpdateReservationForm : Form
    {
        private int reservationId;

        private ComboBox guestComboBox;
        private ComboBox hotelComboBox;
        private CheckedListBox roomsListBox;
        private DateTimePicker checkInPicker;
        private DateTimePicker checkOutPicker;
        private Button saveButton;
        private Button cancelButton;

        public UpdateReservationForm(int reservationId)
        {
            this.reservationId = reservationId;
            InitializeUI();
            LoadGuests();
            LoadHotels();
            LoadReservationData();
        }

        private void InitializeUI()
        {
            Text = "Update Reservation";
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

            saveButton = new Button { Text = "Save", Location = new Point(50, 350), Size = new Size(75, 50) };
            saveButton.Click += SaveButton_Click;

            cancelButton = new Button { Text = "Cancel", Location = new Point(200, 350), Size = new Size(75, 50) };
            cancelButton.Click += (s, e) => { DialogResult = DialogResult.Cancel; };

            Controls.AddRange(new Control[] {
                guestLabel, guestComboBox,
                hotelLabel, hotelComboBox,
                roomLabel, roomsListBox,
                checkInLabel, checkInPicker,
                checkOutLabel, checkOutPicker,
                saveButton, cancelButton
            });
        }

        private void LoadGuests()
        {
            using var connection = DatabaseConnection.GetConnection();
            string query = "SELECT Guest_ID, Name FROM Guest";
            using var cmd = new SqlCommand(query, connection);
            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            dt.Columns.Add("DisplayText", typeof(string));
            foreach (DataRow row in dt.Rows)
                row["DisplayText"] = $"{row["Guest_ID"]} - {row["Name"]}";
            guestComboBox.DataSource = dt;
            guestComboBox.DisplayMember = "DisplayText";
            guestComboBox.ValueMember = "Guest_ID";
        }

        private void LoadHotels()
        {
            using var connection = DatabaseConnection.GetConnection();
            string query = "SELECT Hotel_ID, Name FROM Hotel";
            using var cmd = new SqlCommand(query, connection);
            var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            dt.Columns.Add("DisplayText", typeof(string));
            foreach (DataRow row in dt.Rows)
                row["DisplayText"] = $"{row["Hotel_ID"]} - {row["Name"]}";
            hotelComboBox.DataSource = dt;
            hotelComboBox.DisplayMember = "DisplayText";
            hotelComboBox.ValueMember = "Hotel_ID";
        }

        private void LoadReservationData()
        {
            using var connection = DatabaseConnection.GetConnection();
            string query = @"
                SELECT r.Guest_ID, rr.Hotel_ID, r.Check_in_Date, r.Check_out_Date,
                       rr.Room_Num
                FROM Reservation r
                LEFT JOIN Reservation_Rooms rr ON r.Reservation_ID = rr.Reservation_ID
                WHERE r.Reservation_ID = @ReservationID";

            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ReservationID", reservationId);

            using var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Reservation not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            DataRow firstRow = dt.Rows[0];

            guestComboBox.SelectedValue = Convert.ToInt32(firstRow["Guest_ID"]);
            hotelComboBox.SelectedValue = Convert.ToInt32(firstRow["Hotel_ID"]);
            checkInPicker.Value = Convert.ToDateTime(firstRow["Check_in_Date"]);
            checkOutPicker.Value = Convert.ToDateTime(firstRow["Check_out_Date"]);

            HotelComboBox_SelectedIndexChanged(null, null); // Load rooms

            foreach (DataRow row in dt.Rows)
            {
                string roomNum = row["Room_Num"].ToString();
                for (int i = 0; i < roomsListBox.Items.Count; i++)
                {
                    if (roomsListBox.Items[i].ToString() == roomNum)
                        roomsListBox.SetItemChecked(i, true);
                }
            }
        }

        private void HotelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hotelComboBox.SelectedValue is int hotelId)
            {
                roomsListBox.Items.Clear();
                using var connection = DatabaseConnection.GetConnection();
                string query = "SELECT Room_Num FROM Room WHERE Hotel_ID = @HotelID";
                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@HotelID", hotelId);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    roomsListBox.Items.Add(reader["Room_Num"].ToString());
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (guestComboBox.SelectedValue == null || hotelComboBox.SelectedValue == null || roomsListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select Guest, Hotel, and at least one Room.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkOutPicker.Value <= checkInPicker.Value)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var connection = DatabaseConnection.GetConnection();

            try
            {
                int hotelId = Convert.ToInt32(hotelComboBox.SelectedValue);
                DateTime checkIn = checkInPicker.Value.Date;
                DateTime checkOut = checkOutPicker.Value.Date;

                // Validate each selected room for availability
                foreach (var room in roomsListBox.CheckedItems)
                {
                    string roomNum = room.ToString();

                    string checkQuery = @"
                SELECT COUNT(*) FROM Reservation_Rooms rr
                JOIN Reservation r ON rr.Reservation_ID = r.Reservation_ID
                WHERE rr.Hotel_ID = @HotelID
                  AND rr.Room_Num = @RoomNum
                  AND r.Reservation_ID != @CurrentReservationID
                  AND r.Status IN ('Pending', 'Confirmed')
                  AND NOT (r.Check_out_Date <= @CheckIn OR r.Check_in_Date >= @CheckOut)";

                    using var checkCmd = new SqlCommand(checkQuery, connection);
                    checkCmd.Parameters.AddWithValue("@HotelID", hotelId);
                    checkCmd.Parameters.AddWithValue("@RoomNum", roomNum);
                    checkCmd.Parameters.AddWithValue("@CurrentReservationID", reservationId);
                    checkCmd.Parameters.AddWithValue("@CheckIn", checkIn);
                    checkCmd.Parameters.AddWithValue("@CheckOut", checkOut);

                    long count = (long)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show($"Room {roomNum} is already booked in the selected dates.", "Room Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Update reservation
                string updateQuery = @"
            UPDATE Reservation
            SET Guest_ID = @GuestID,
                Check_in_Date = @CheckIn,
                Check_out_Date = @CheckOut
            WHERE Reservation_ID = @ReservationID";

                using (var cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@GuestID", guestComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@CheckIn", checkIn);
                    cmd.Parameters.AddWithValue("@CheckOut", checkOut);
                    cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                    cmd.ExecuteNonQuery();
                }

                // Delete old room assignments
                string deleteRoomsQuery = "DELETE FROM Reservation_Rooms WHERE Reservation_ID = @ReservationID";
                using (var cmd = new SqlCommand(deleteRoomsQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                    cmd.ExecuteNonQuery();
                }

                // Insert new room assignments
                foreach (var room in roomsListBox.CheckedItems)
                {
                    string insertRoomQuery = @"
                INSERT INTO Reservation_Rooms (Reservation_ID, Room_Num, Hotel_ID)
                VALUES (@ReservationID, @RoomNum, @HotelID)";
                    using (var cmd = new SqlCommand(insertRoomQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                        cmd.Parameters.AddWithValue("@RoomNum", room.ToString());
                        cmd.Parameters.AddWithValue("@HotelID", hotelId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Reservation updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating reservation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // No need to override Dispose unless you manage unmanaged resources.
        // You can now use this form with `using`.
    }
}
