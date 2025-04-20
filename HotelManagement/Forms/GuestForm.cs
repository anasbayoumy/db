using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HotelManagement.Data;

namespace HotelManagement.Forms
{
    public class GuestForm : Form
    {
        private DataGridView guestGridView;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
        private Button refreshButton;

        public GuestForm()
        {
            InitializeUI();
            LoadGuestData();
        }

        private void InitializeUI()
        {
            this.Text = "Guest Management";
            this.Size = new System.Drawing.Size(800, 600);

            // Create DataGridView
            guestGridView = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(740, 400),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            // Create buttons
            addButton = new Button
            {
                Text = "Add Guest",
                Location = new System.Drawing.Point(20, 440),
                Size = new System.Drawing.Size(100, 30)
            };
            addButton.Click += AddButton_Click;

            updateButton = new Button
            {
                Text = "Update Guest",
                Location = new System.Drawing.Point(140, 440),
                Size = new System.Drawing.Size(100, 30)
            };
            updateButton.Click += UpdateButton_Click;

            deleteButton = new Button
            {
                Text = "Delete Guest",
                Location = new System.Drawing.Point(260, 440),
                Size = new System.Drawing.Size(100, 30)
            };
            deleteButton.Click += DeleteButton_Click;

            refreshButton = new Button
            {
                Text = "Refresh",
                Location = new System.Drawing.Point(380, 440),
                Size = new System.Drawing.Size(100, 30)
            };
            refreshButton.Click += RefreshButton_Click;

            // Add controls to form
            this.Controls.Add(guestGridView);
            this.Controls.Add(addButton);
            this.Controls.Add(updateButton);
            this.Controls.Add(deleteButton);
            this.Controls.Add(refreshButton);
        }

        private void LoadGuestData()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    if (connection != null)
                    {
                        string query = "SELECT * FROM Guest";
                        MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        guestGridView.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading guest data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddGuestForm addForm = new AddGuestForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadGuestData();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (guestGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guestGridView.SelectedRows[0];
                int guestId = Convert.ToInt32(selectedRow.Cells["Guest_ID"].Value);
                
                UpdateGuestForm updateForm = new UpdateGuestForm(guestId);
                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    LoadGuestData();
                }
            }
            else
            {
                MessageBox.Show("Please select a guest to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (guestGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guestGridView.SelectedRows[0];
                int guestId = Convert.ToInt32(selectedRow.Cells["Guest_ID"].Value);

                if (MessageBox.Show("Are you sure you want to delete this guest?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection connection = DatabaseConnection.GetConnection())
                        {
                            if (connection != null)
                            {
                                string query = "DELETE FROM Guest WHERE Guest_ID = @Guest_ID";
                                MySqlCommand command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@Guest_ID", guestId);
                                command.ExecuteNonQuery();
                                LoadGuestData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting guest: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a guest to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadGuestData();
        }
    }
} 