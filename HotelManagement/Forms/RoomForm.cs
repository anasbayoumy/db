using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HotelManagement.Data;

namespace HotelManagement.Forms
{
    public class RoomForm : Form
    {
        private DataGridView roomGridView;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
        private Button refreshButton;
        private ComboBox filterHotelComboBox;
        private Label filterLabel;

        public RoomForm()
        {
            InitializeUI();
            LoadHotels();
            LoadRoomData();
        }

        private void InitializeUI()
        {
            this.Text = "Room Management";
            this.Size = new System.Drawing.Size(1000, 600);

            // Create filter controls
            filterLabel = new Label
            {
                Text = "Filter by Hotel:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(100, 20)
            };

            filterHotelComboBox = new ComboBox
            {
                Location = new System.Drawing.Point(120, 20),
                Size = new System.Drawing.Size(200, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            filterHotelComboBox.SelectedIndexChanged += (s, e) => LoadRoomData();

            // Create DataGridView
            roomGridView = new DataGridView
            {
                Location = new System.Drawing.Point(20, 50),
                Size = new System.Drawing.Size(940, 400),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true
            };

            // Create buttons
            addButton = new Button
            {
                Text = "Add Room",
                Location = new System.Drawing.Point(20, 470),
                Size = new System.Drawing.Size(100, 30)
            };
            addButton.Click += AddButton_Click;

            updateButton = new Button
            {
                Text = "Update Room",
                Location = new System.Drawing.Point(140, 470),
                Size = new System.Drawing.Size(100, 30)
            };
            updateButton.Click += UpdateButton_Click;

            deleteButton = new Button
            {
                Text = "Delete Room",
                Location = new System.Drawing.Point(260, 470),
                Size = new System.Drawing.Size(100, 30)
            };
            deleteButton.Click += DeleteButton_Click;

            refreshButton = new Button
            {
                Text = "Refresh",
                Location = new System.Drawing.Point(380, 470),
                Size = new System.Drawing.Size(100, 30)
            };
            refreshButton.Click += RefreshButton_Click;

            // Add controls to form
            this.Controls.AddRange(new Control[] {
                filterLabel,
                filterHotelComboBox,
                roomGridView,
                addButton,
                updateButton,
                deleteButton,
                refreshButton
            });
        }

        private void LoadHotels()
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
                            filterHotelComboBox.Items.Clear();
                            filterHotelComboBox.Items.Add(new ComboBoxItem { Id = 0, Text = "All Hotels" });
                            
                            while (reader.Read())
                            {
                                filterHotelComboBox.Items.Add(new ComboBoxItem
                                {
                                    Id = reader.GetInt32("Hotel_ID"),
                                    Text = reader.GetString("Name")
                                });
                            }
                        }
                        filterHotelComboBox.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading hotels: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoomData()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    if (connection != null)
                    {
                        string query = @"SELECT r.Room_Num, h.Name as Hotel_Name, r.Category, 
                                             r.Status, c.Price, r.Hotel_ID
                                      FROM Room r
                                      JOIN Hotel h ON r.Hotel_ID = h.Hotel_ID
                                      JOIN Room_Category c ON r.Category = c.Category and r.Hotel_ID = c.Hotel_ID";

                        if (filterHotelComboBox.SelectedIndex > 0)
                        {
                            var selectedHotel = (ComboBoxItem)filterHotelComboBox.SelectedItem;
                            query += " WHERE r.Hotel_ID = @Hotel_ID";
                        }

                        MySqlCommand command = new MySqlCommand(query, connection);
                        
                        if (filterHotelComboBox.SelectedIndex > 0)
                        {
                            var selectedHotel = (ComboBoxItem)filterHotelComboBox.SelectedItem;
                            command.Parameters.AddWithValue("@Hotel_ID", selectedHotel.Id);
                        }

                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        roomGridView.DataSource = dataTable;
                        roomGridView.Columns["Hotel_ID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddRoomForm addForm = new AddRoomForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadRoomData();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (roomGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = roomGridView.SelectedRows[0];
                int roomNum = Convert.ToInt32(selectedRow.Cells["Room_Num"].Value);
                int hotelId = Convert.ToInt32(selectedRow.Cells["Hotel_ID"].Value);

                UpdateRoomForm updateForm = new UpdateRoomForm(roomNum,hotelId);
                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRoomData();
                }
            }
            else
            {
                MessageBox.Show("Please select a room to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (roomGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = roomGridView.SelectedRows[0];
                int roomId = Convert.ToInt32(selectedRow.Cells["Room_ID"].Value);

                if (MessageBox.Show("Are you sure you want to delete this room?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection connection = DatabaseConnection.GetConnection())
                        {
                            if (connection != null)
                            {
                                // First check if the room has any reservations
                                string checkQuery = "SELECT COUNT(*) FROM Reservation WHERE Room_ID = @Room_ID";
                                MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                                checkCommand.Parameters.AddWithValue("@Room_ID", roomId);
                                int reservationCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                                if (reservationCount > 0)
                                {
                                    MessageBox.Show("Cannot delete this room as it has existing reservations.",
                                        "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                string query = "DELETE FROM Room WHERE Room_ID = @Room_ID";
                                MySqlCommand command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@Room_ID", roomId);
                                command.ExecuteNonQuery();
                                LoadRoomData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a room to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadRoomData();
        }
    }

    // Helper class for ComboBox items
    public class ComboBoxItem
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
} 