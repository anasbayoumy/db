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
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {

                    /* string query = @"
                                     UPDATE h
                                     SET h.Rating = ISNULL(avgRatings.avg, 0)
                                     FROM Hotel h
                                     LEFT JOIN (
                                         SELECT Hotel_ID, AVG(CAST(Rating AS DECIMAL(3,1))) AS avg
                                         FROM Feedback
                                         GROUP BY Hotel_ID
                                     ) AS avgRatings ON h.Hotel_ID = avgRatings.Hotel_ID;
                                     ";*/
                    string query = @"Update_Hotel_Ratings";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void LoadData()
        {
            try
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
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
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
                        /*string delete1 = @"Delete from Hotel_emails
                                           where Hotel_ID = @Hotel_ID
                                          ";
                        SqlCommand deletecmd = new SqlCommand(delete1, con);
                        deletecmd.Parameters.AddWithValue("@Hotel_ID", Hotel_ID);
                        deletecmd.ExecuteNonQuery();
                        string query = @"Delete From Hotel
                                     Where Hotel_ID = @Hotel_ID 
                                    ";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Hotel_ID", Hotel_ID);
                        cmd.ExecuteNonQuery();*/
                        string query = @"DeleteHotelAndEmails";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.CommandType = CommandType.StoredProcedure;
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
