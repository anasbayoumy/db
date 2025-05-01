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
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"Update Hotel h
                                 Left Join(Select Hotel_ID, AVG(Rating) as avg
                                      From Feedback
                                      Group By Hotel_ID
                                 ) as avgRatings
                                 on h.Hotel_ID = avgRatings.Hotel_ID
                                 set h.Rating = IFNULL(avgRatings.avg,0)
                                ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        private void LoadData()
        {
            using (SqlConnection con = DatabaseConnection.GetConnection())
            {
                string query = "Select * from Hotel";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
                    using (SqlConnection con = DatabaseConnection.GetConnection())
                    {
                        string query = @"Delete From Hotel
                                     Where Hotel_ID = @Hotel_ID 
                                    ";
                        SqlCommand cmd = new SqlCommand(query, con);
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

        private void viewEmailsButton_Click(object sender, EventArgs e)
        {
            if (HotelsGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow selected = HotelsGrid.SelectedRows[0];
                int Hotel_ID = Convert.ToInt32(selected.Cells["Hotel_ID"].Value);
                using (ViewHotelEmailsForm emails = new ViewHotelEmailsForm(Hotel_ID))
                {
                    emails.ShowDialog();
                }
                updateRating();
                LoadData();
            }

        }
    }
}
