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
using MySql.Data.MySqlClient;

namespace HotelManagement.Forms
{
    public partial class ViewHotelsForm : Form
    {
        public ViewHotelsForm()
        {
            InitializeComponent();
            updateRating();
            LoadData();
        }

        private void updateRating()
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"Update Hotel h
                                 Left Join(Select Hotel_ID, AVG(Rating) as avg
                                      From Feedback
                                      Group By Hotel_ID
                                 ) as avgRatings
                                 on h.Hotel_ID = avgRatings.Hotel_ID
                                 set h.Rating = IFNULL(avgRatings.avg,0)
                                ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        private void LoadData()
        {
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            {
                string query = "Select * from Hotel";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                HotelsGrid.DataSource = dt;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (NewHotelForm hotel = new NewHotelForm())
            {
                hotel.ShowDialog();
            }
            updateRating();
            LoadData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (HotelsGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow selected = HotelsGrid.SelectedRows[0];
                int Hotel_ID = Convert.ToInt32(selected.Cells["Hotel_ID"].Value);
                using (UpdateHotelForm Hotel = new UpdateHotelForm(Hotel_ID))
                {
                    Hotel.ShowDialog();
                }
                updateRating();
                LoadData();
            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (HotelsGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow selected = HotelsGrid.SelectedRows[0];
                int Hotel_ID = Convert.ToInt32(selected.Cells["Hotel_ID"].Value);
                try
                {
                    using (MySqlConnection con = DatabaseConnection.GetConnection())
                    {
                        string query = @"Delete From Hotel
                                     Where Hotel_ID = @Hotel_ID 
                                    ";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Hotel_ID", Hotel_ID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deleted");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You cannot delete this hotel" + ex.Message);
                }
                updateRating();
                LoadData();
            }
        }
    }
}
