using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.Data;
using System.Data.SqlClient;

namespace HotelManagement.Forms
{
    public partial class UpdateHotelForm : Form
    {
        int HotelID;
        public UpdateHotelForm(int HotelID)
        {
            this.HotelID = HotelID;
            InitializeComponent();
            loadData();
        }

        private void loadData() {
            using (SqlConnection con = DatabaseConnection.GetConnection()) {
                string query = @"Select * from Hotel
                                 where Hotel_ID = @Hotel_ID
                                ";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Hotel_ID", this.HotelID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NameTextBox.Text = reader["Name"].ToString();
                        LocationTextBox.Text = reader["Location"].ToString();
                        roomsTextBox.Text = reader["Num_Rooms"].ToString();
                    }
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == null)
            {
                MessageBox.Show("Please enter a name");
                return;
            }
            if (LocationTextBox.Text == null)
            {
                MessageBox.Show("Please enter a location");
                return;
            }
            if (!int.TryParse(roomsTextBox.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Enter a positive number");
                return;
            }
            try
            {
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Update Hotel
                                 set Name = @Name, Location = @Location, Num_Rooms = @Rooms
                                 where Hotel_ID = @Hotel_ID
                                ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", NameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Location", LocationTextBox.Text);
                    cmd.Parameters.AddWithValue("@Rooms", roomsTextBox.Text);
                    cmd.Parameters.AddWithValue("@Hotel_ID", this.HotelID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Done");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
    }
}
