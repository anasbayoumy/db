using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HotelManagement.Data;

namespace HotelManagement.Forms
{
    public class UpdateRoomForm : Form
    {
        private readonly int roomNum;
        private readonly int hotelId;
        private ComboBox hotelComboBox;
        private TextBox roomNumTextBox;
        private ComboBox categoryComboBox;
        private TextBox rentTextBox;
        private ComboBox statusComboBox;
        private Button saveButton;
        private Button cancelButton;

        public UpdateRoomForm(int roomNum, int hotelId)
        {
            this.roomNum = roomNum;
            this.hotelId = hotelId;
            InitializeUI();
            //LoadHotels();
            LoadRoomData();
        }

        private void InitializeUI()
        {
            this.Text = "Update Room";
            this.Size = new System.Drawing.Size(400, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Create labels and controls
           /* Label hotelLabel = new Label { Text = "Hotel:", Location = new System.Drawing.Point(20, 20) };
            hotelComboBox = new ComboBox 
            { 
                Location = new System.Drawing.Point(120, 20), 
                Size = new System.Drawing.Size(240, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            Label roomNumLabel = new Label { Text = "Room Number:", Location = new System.Drawing.Point(20, 60) };
            roomNumTextBox = new TextBox { Location = new System.Drawing.Point(120, 60), Size = new System.Drawing.Size(240, 20) };*/

            Label categoryLabel = new Label { Text = "Category:", Location = new System.Drawing.Point(20, 100) };
            categoryComboBox = new ComboBox 
            { 
                Location = new System.Drawing.Point(120, 100), 
                Size = new System.Drawing.Size(240, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            categoryComboBox.Items.AddRange(new string[] { "Standard", "Deluxe", "Suite", "Executive" });

            /*Label rentLabel = new Label { Text = "Rent:", Location = new System.Drawing.Point(20, 140) };
            rentTextBox = new TextBox { Location = new System.Drawing.Point(120, 140), Size = new System.Drawing.Size(240, 20) };*/

            Label statusLabel = new Label { Text = "Status:", Location = new System.Drawing.Point(20, 180) };
            statusComboBox = new ComboBox 
            { 
                Location = new System.Drawing.Point(120, 180), 
                Size = new System.Drawing.Size(240, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            statusComboBox.Items.AddRange(new string[] { "Available", "Occupied", "Under Maintenance" });

            saveButton = new Button
            {
                Text = "Save",
                Location = new System.Drawing.Point(120, 240),
                Size = new System.Drawing.Size(100, 30)
            };
            saveButton.Click += SaveButton_Click;

            cancelButton = new Button
            {
                Text = "Cancel",
                Location = new System.Drawing.Point(240, 240),
                Size = new System.Drawing.Size(100, 30)
            };
            cancelButton.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // Add controls to form
            this.Controls.AddRange(new Control[] {
                categoryLabel, categoryComboBox,
                statusLabel, statusComboBox,
                saveButton, cancelButton
            });
        }

        /*private void LoadHotels()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    if (connection != null)
                    {
                        string query = "SELECT Hotel_ID, Name FROM Hotel";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                hotelComboBox.Items.Add(new ComboBoxItem
                                {
                                    Id = reader.GetInt32("Hotel_ID"),
                                    Text = reader.GetString("Name")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading hotels: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void LoadRoomData()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    if (connection != null)
                    {
                        string query = "SELECT * FROM Room WHERE Room_Num = @Room_Num and Hotel_ID = @Hotel_ID";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Room_Num", roomNum);
                        command.Parameters.AddWithValue("@Hotel_ID", hotelId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                               /* int hotelId = reader.GetInt32("Hotel_ID");
                                foreach (ComboBoxItem item in hotelComboBox.Items)
                                {
                                    if (item.Id == hotelId)
                                    {
                                        hotelComboBox.SelectedItem = item;
                                        break;
                                    }
                                }*/

                                //roomNumTextBox.Text = reader["Room_Num"].ToString();
                                categoryComboBox.SelectedItem = reader["Category"].ToString();
                                //rentTextBox.Text = reader["Rent"].ToString();
                                statusComboBox.SelectedItem = reader["Status"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    using (MySqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        if (connection != null)
                        {
                            // Check if room number already exists in the selected hotel (excluding current room)
                            string checkQuery = @"SELECT COUNT(*) FROM Room 
                                               WHERE Hotel_ID = @Hotel_ID 
                                               AND Room_Num = @Room_Num 
                                               AND Room_ID != @Room_ID";
                            MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                            var selectedHotel = (ComboBoxItem)hotelComboBox.SelectedItem;
                            checkCommand.Parameters.AddWithValue("@Hotel_ID", selectedHotel.Id);
                            checkCommand.Parameters.AddWithValue("@Room_Num", roomNumTextBox.Text);
                            checkCommand.Parameters.AddWithValue("@Room_ID", roomNum);
                            int roomCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                            if (roomCount > 0)
                            {
                                MessageBox.Show("A room with this number already exists in the selected hotel.",
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            string query = @"UPDATE Room 
                                           SET 
                                               Category = @Category,
                                               Status = @Status
                                           WHERE Room_Num = @Room_Num and Hotel_ID = @Hotel_ID";

                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@Room_Num", roomNum);
                            command.Parameters.AddWithValue("@Hotel_ID", selectedHotel.Id);
                            //command.Parameters.AddWithValue("@Room_Num", roomNumTextBox.Text);
                            command.Parameters.AddWithValue("@Category", categoryComboBox.SelectedItem.ToString());
                            //command.Parameters.AddWithValue("@Rent", Convert.ToDecimal(rentTextBox.Text));
                            command.Parameters.AddWithValue("@Status", statusComboBox.SelectedItem.ToString());

                            command.ExecuteNonQuery();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            if (hotelComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a hotel.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(roomNumTextBox.Text))
            {
                MessageBox.Show("Please enter a room number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (categoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a room category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(rentTextBox.Text, out decimal rent) || rent <= 0)
            {
                MessageBox.Show("Please enter a valid rent amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
} 