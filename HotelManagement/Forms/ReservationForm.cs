using System;
using System.Data;
using System.Windows.Forms;
using HotelManagement.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

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
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    if (connection != null)
                    {
                        /* string query = @"SELECT res.Reservation_ID, res.Guest_ID, g.Name as 'Guest_Name', res.Check_in_Date,
                                        res.Check_out_Date, h.Hotel_ID, h.Name as 'Hotel_Name', r.Room_Num, r.Category, res.Status
                                        FROM Reservation res
                                        JOIN Reservation_Rooms rr on res.Reservation_ID = rr.Reservation_ID 
                                        JOIN Hotel h ON rr.Hotel_ID = h.Hotel_ID
                                        JOIN Room r on rr.Room_Num = r.Room_Num and rr.Hotel_ID = r.Hotel_ID
                                        JOIN Guest g on res.Guest_ID = g.Guest_ID
                                        ORDER BY res.Reservation_ID
                                        ";*/
                        string query = @"Select * from GetAllReservationDetails()";

                        SqlCommand command = new SqlCommand(query, connection);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
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
                        using (SqlConnection connection = DatabaseConnection.GetConnection())
                        {

                            // 1. Insert into Reservation
                            string reservationQuery = @"INSERT INTO Reservation (Guest_ID, Check_in_Date, Check_out_Date, Status) 
                                                VALUES (@GuestID, @CheckIn, @CheckOut, 'Pending');
                                                SELECT SCOPE_IDENTITY();";

                            SqlCommand reservationCmd = new SqlCommand(reservationQuery, connection);
                            reservationCmd.Parameters.AddWithValue("@GuestID", addForm.GuestId);
                            reservationCmd.Parameters.AddWithValue("@CheckIn", addForm.CheckInDate);
                            reservationCmd.Parameters.AddWithValue("@CheckOut", addForm.CheckOutDate);

                            int reservationId = Convert.ToInt32(reservationCmd.ExecuteScalar());

                            // 2. Insert into Reservation_Rooms
                            foreach (string roomNum in addForm.RoomNumbers)
                            {
                                string roomQuery = @"INSERT INTO Reservation_Rooms (Reservation_ID, Room_Num, Hotel_ID) 
                                             VALUES (@ReservationID, @RoomNum, @HotelID);";

                                SqlCommand roomCmd = new SqlCommand(roomQuery, connection);
                                roomCmd.Parameters.AddWithValue("@ReservationID", reservationId);
                                roomCmd.Parameters.AddWithValue("@RoomNum", roomNum);
                                roomCmd.Parameters.AddWithValue("@HotelID", addForm.HotelId);

                                roomCmd.ExecuteNonQuery();

                                /*// 3. Update Room Status to Occupied
                                string updateRoomStatus = @"UPDATE Room SET Status = 'Occupied' 
                                                    WHERE Hotel_ID = @HotelID AND Room_Num = @RoomNum;";

                                SqlCommand updateCmd = new SqlCommand(updateRoomStatus, connection);
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
            reservationGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
            AddReservation.Location = new Point(12, 374);
            AddReservation.Name = "AddReservation";
            AddReservation.Size = new Size(144, 45);
            AddReservation.TabIndex = 1;
            AddReservation.Text = "Add";
            AddReservation.UseVisualStyleBackColor = true;
            AddReservation.Click += AddReservation_Click;
            // 
            // updateReservation
            // 
            updateReservation.Location = new Point(176, 374);
            updateReservation.Name = "updateReservation";
            updateReservation.Size = new Size(156, 45);
            updateReservation.TabIndex = 2;
            updateReservation.Text = "Update";
            updateReservation.UseVisualStyleBackColor = true;
            updateReservation.Click += updateReservation_Click;
            // 
            // DeleteReservation
            // 
            DeleteReservation.Location = new Point(348, 374);
            DeleteReservation.Name = "DeleteReservation";
            DeleteReservation.Size = new Size(156, 45);
            DeleteReservation.TabIndex = 3;
            DeleteReservation.Text = "Delete";
            DeleteReservation.UseVisualStyleBackColor = true;
            DeleteReservation.Click += DeleteReservation_Click;
            // 
            // viewServices
            // 
            viewServices.Location = new Point(522, 374);
            viewServices.Name = "viewServices";
            viewServices.Size = new Size(156, 45);
            viewServices.TabIndex = 4;
            viewServices.Text = "View Services";
            viewServices.UseVisualStyleBackColor = true;
            viewServices.Click += ViewServices_Click;
            // 
            // viewPayments
            // 
            viewPayments.Location = new Point(697, 374);
            viewPayments.Name = "viewPayments";
            viewPayments.Size = new Size(156, 45);
            viewPayments.TabIndex = 5;
            viewPayments.Text = "View Payments";
            viewPayments.UseVisualStyleBackColor = true;
            viewPayments.Click += viewPayments_Click;
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
                        using (SqlConnection connection = DatabaseConnection.GetConnection())
                        {
                            if (connection != null)
                            {
                                // First check if the room has any reservations
                                string checkQuery = "SELECT COUNT(*) FROM Payment WHERE Reservation_ID = @Reservation_ID";
                                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                                checkCommand.Parameters.AddWithValue("@Reservation_ID", reservationID);
                                int reservationPaymentCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                                if (reservationPaymentCount > 0)
                                {
                                    MessageBox.Show("Cannot delete reservation, a payment was made already.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    /* string delete1 = "DELETE FROM Reservation_Service WHERE Reservation_ID = @Reservation_ID";
                                     SqlCommand command = new SqlCommand(delete1, connection);
                                     command.Parameters.AddWithValue("@Reservation_ID", reservationID);
                                     command.ExecuteNonQuery();

                                     string delete2 = "DELETE FROM Reservation_Rooms WHERE Reservation_ID = @Reservation_ID";
                                     SqlCommand command2 = new SqlCommand(delete2, connection);
                                     command2.Parameters.AddWithValue("@Reservation_ID", reservationID);
                                     command2.ExecuteNonQuery();

                                     string delete3 = "DELETE FROM Reservation WHERE Reservation_ID = @Reservation_ID";
                                     SqlCommand command3 = new SqlCommand(delete3, connection);
                                     command3.Parameters.AddWithValue("@Reservation_ID", reservationID);
                                     command3.ExecuteNonQuery();*/
                                    string delete = @"DeleteReservationCascade";
                                    SqlCommand cmd = new SqlCommand(delete, connection);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@Reservation_ID", reservationID);
                                    cmd.ExecuteNonQuery();
                                }
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

        private void viewPayments_Click(object sender, EventArgs e)
        {
            if (reservationGridView.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = reservationGridView.SelectedRows[0];
                int reservationID = Convert.ToInt32(selectedRow.Cells["Reservation_ID"].Value);
                using (ReservationPaymentsForm payments = new ReservationPaymentsForm(reservationID))
                {
                    payments.ShowDialog();
                }
                LoadReservations();  
                
            }
        }

        private void updateReservation_Click(object sender, EventArgs e)
        {

            if (reservationGridView.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = reservationGridView.SelectedRows[0];
                int reservationID = Convert.ToInt32(selectedRow.Cells["Reservation_ID"].Value);
                using (UpdateReservationForm reservation = new UpdateReservationForm(reservationID))
                {
                    reservation.ShowDialog();
                }
                LoadReservations();

            }
        }
    }
} 