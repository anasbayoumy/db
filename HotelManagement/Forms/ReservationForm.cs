using System;
using System.Data;
using System.Windows.Forms;
using HotelManagement.Data;
using MySql.Data.MySqlClient;

namespace HotelManagement.Forms
{
    public class ReservationForm : Form
    {
        public ReservationForm()
        {
            InitializeUI();
            LoadReservations();
        }

        private void LoadReservations()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    if (connection != null)
                    {
                        string query = @"SELECT DISTINCT res.Reservation_ID, res.Guest_ID, g.Name, res.Check_in_Date,
                                       res.Check_out_Date, h.Hotel_ID, h.Name, r.Room_Num, r.Category, res.Status
                                       FROM Reservation res
                                       JOIN Reservation_Rooms rr on res.Reservation_ID = rr.Reservation_ID 
                                       JOIN Hotel h ON rr.Hotel_ID = h.Hotel_ID
                                       JOIN Room r on rr.Room_Num = r.Room_Num and rr.Hotel_ID = r.Hotel_ID
                                       JOIN Guest g on res.Guest_ID = g.Guest_ID
                                       ORDER BY res.Reservation_ID
                                       ";

                        MySqlCommand command = new MySqlCommand(query, connection);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        reservationGridView.DataSource = dataTable;
                        reservationGridView.Columns["Hotel_ID"].Visible = false;
                        reservationGridView.Columns["Guest_ID"].Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Reservation data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeUI()
        {
            InitializeComponent();
        }
        private void ViewServices_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = reservationGridView.SelectedRows[0];
            int resID = Convert.ToInt32(selectedRow.Cells["Reservation_ID"].Value);
            ReservationServicesForm resServiceForm = new ReservationServicesForm(resID);
            resServiceForm.ShowDialog();

        }

        private void AddReservation_Click(object sender, EventArgs e)
        {
            using (AddReservationForm addForm = new AddReservationForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (MySqlConnection connection = DatabaseConnection.GetConnection())
                        {
                            //connection.Open();

                            // 1. Insert into Reservation
                            string reservationQuery = @"INSERT INTO Reservation (Guest_ID, Check_in_Date, Check_out_Date, Status) 
                                                VALUES (@GuestID, @CheckIn, @CheckOut, 'Pending');
                                                SELECT LAST_INSERT_ID();";

                            MySqlCommand reservationCmd = new MySqlCommand(reservationQuery, connection);
                            reservationCmd.Parameters.AddWithValue("@GuestID", addForm.GuestId);
                            reservationCmd.Parameters.AddWithValue("@CheckIn", addForm.CheckInDate);
                            reservationCmd.Parameters.AddWithValue("@CheckOut", addForm.CheckOutDate);

                            int reservationId = Convert.ToInt32(reservationCmd.ExecuteScalar());

                            // 2. Insert into Reservation_Rooms
                            foreach (string roomNum in addForm.RoomNumbers)
                            {
                                string roomQuery = @"INSERT INTO Reservation_Rooms (Reservation_ID, Room_Num, Hotel_ID) 
                                             VALUES (@ReservationID, @RoomNum, @HotelID);";

                                MySqlCommand roomCmd = new MySqlCommand(roomQuery, connection);
                                roomCmd.Parameters.AddWithValue("@ReservationID", reservationId);
                                roomCmd.Parameters.AddWithValue("@RoomNum", roomNum);
                                roomCmd.Parameters.AddWithValue("@HotelID", addForm.HotelId);

                                roomCmd.ExecuteNonQuery();

                                /*// 3. Update Room Status to Occupied
                                string updateRoomStatus = @"UPDATE Room SET Status = 'Occupied' 
                                                    WHERE Hotel_ID = @HotelID AND Room_Num = @RoomNum;";

                                MySqlCommand updateCmd = new MySqlCommand(updateRoomStatus, connection);
                                updateCmd.Parameters.AddWithValue("@HotelID", addForm.HotelId);
                                updateCmd.Parameters.AddWithValue("@RoomNum", roomNum);

                                updateCmd.ExecuteNonQuery();*/
                            }

                            MessageBox.Show("Reservation added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload the DataGrid
                            LoadReservations();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private DataGridView reservationGridView;

        private void InitializeComponent()
        {
            reservationGridView = new DataGridView();
            AddReservation = new Button();
            updateReservation = new Button();
            DeleteReservation = new Button();
            viewServices = new Button();
            viewPayments = new Button();
            ((System.ComponentModel.ISupportInitialize)reservationGridView).BeginInit();
            SuspendLayout();
            // 
            // reservationGridView
            // 
            reservationGridView.AllowUserToAddRows = false;
            reservationGridView.AllowUserToDeleteRows = false;
            reservationGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reservationGridView.Dock = DockStyle.Top;
            reservationGridView.Location = new Point(0, 0);
            reservationGridView.MultiSelect = false;
            reservationGridView.Name = "reservationGridView";
            reservationGridView.ReadOnly = true;
            reservationGridView.RowHeadersWidth = 51;
            reservationGridView.RowTemplate.Height = 29;
            reservationGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reservationGridView.Size = new Size(902, 308);
            reservationGridView.TabIndex = 0;
            // 
            // AddReservation
            // 
            AddReservation.Location = new Point(23, 374);
            AddReservation.Name = "AddReservation";
            AddReservation.Size = new Size(94, 29);
            AddReservation.TabIndex = 1;
            AddReservation.Text = "Add";
            AddReservation.UseVisualStyleBackColor = true;
            AddReservation.Click += AddReservation_Click;
            // 
            // updateReservation
            // 
            updateReservation.Location = new Point(144, 374);
            updateReservation.Name = "updateReservation";
            updateReservation.Size = new Size(94, 29);
            updateReservation.TabIndex = 2;
            updateReservation.Text = "Update";
            updateReservation.UseVisualStyleBackColor = true;
            // 
            // DeleteReservation
            // 
            DeleteReservation.Location = new Point(265, 374);
            DeleteReservation.Name = "DeleteReservation";
            DeleteReservation.Size = new Size(94, 29);
            DeleteReservation.TabIndex = 3;
            DeleteReservation.Text = "Delete";
            DeleteReservation.UseVisualStyleBackColor = true;
            DeleteReservation.Click += DeleteReservation_Click;
            // 
            // viewServices
            // 
            viewServices.Location = new Point(376, 374);
            viewServices.Name = "viewServices";
            viewServices.Size = new Size(117, 29);
            viewServices.TabIndex = 4;
            viewServices.Text = "View Services";
            viewServices.UseVisualStyleBackColor = true;
            viewServices.Click += ViewServices_Click;
            // 
            // viewPayments
            // 
            viewPayments.Location = new Point(510, 374);
            viewPayments.Name = "viewPayments";
            viewPayments.Size = new Size(135, 29);
            viewPayments.TabIndex = 5;
            viewPayments.Text = "View Payments";
            viewPayments.UseVisualStyleBackColor = true;
            // 
            // ReservationForm
            // 
            ClientSize = new Size(902, 505);
            Controls.Add(viewPayments);
            Controls.Add(viewServices);
            Controls.Add(DeleteReservation);
            Controls.Add(updateReservation);
            Controls.Add(AddReservation);
            Controls.Add(reservationGridView);
            Name = "ReservationForm";
            ((System.ComponentModel.ISupportInitialize)reservationGridView).EndInit();
            ResumeLayout(false);
        }

        private Button AddReservation;
        private Button updateReservation;
        private Button DeleteReservation;
        private Button viewServices;
        private Button viewPayments;

        private void DeleteReservation_Click(object sender, EventArgs e)
        {
            if (reservationGridView.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = reservationGridView.SelectedRows[0];
                int reservationID = Convert.ToInt32(selectedRow.Cells["Reservation_ID"].Value);

                if (MessageBox.Show("Are you sure you want to delete this reservation?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection connection = DatabaseConnection.GetConnection())
                        {
                            if (connection != null)
                            {
                                // First check if the room has any reservations
                                string checkQuery = "SELECT COUNT(*) FROM Payment WHERE Reservation_ID = @Reservation_ID";
                                MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                                checkCommand.Parameters.AddWithValue("@Reservation_ID", reservationID);
                                int reservationPaymentCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                                if (reservationPaymentCount > 0)
                                {
                                    MessageBox.Show("Cannot delete reservation, a payment was made already.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                string query = "DELETE FROM Reservation_Service WHERE Reservation_ID = @Reservation_ID";
                                MySqlCommand command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@Reservation_ID",reservationID);
                                command.ExecuteNonQuery();

                                string query2 = "DELETE FROM Reservation WHERE Reservation_ID = @Reservation_ID";
                                MySqlCommand command2 = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@Reservation_ID", reservationID);
                                command.ExecuteNonQuery();
                                LoadReservations();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select one reservation to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
} 