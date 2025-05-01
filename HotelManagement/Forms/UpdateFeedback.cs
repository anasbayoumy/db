using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using HotelManagement.Data;
using System.Data.SqlClient;

namespace HotelManagement.Forms
{
    public partial class UpdateFeedback : Form
    {
        int FeedbackID;
        public UpdateFeedback(int FeedbackID)
        {
            this.FeedbackID = FeedbackID;
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            LoadGuests();
            LoadHotels();
            for (int i = 1; i <= 5; i++)
            {
                RatingComboBox.Items.Add(i);
            }
            using (SqlConnection con = DatabaseConnection.GetConnection()) {
                string query = @"Select * from Feedback
                                 where Feedback_ID = @Feedback_ID
                                ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Feedback_ID", this.FeedbackID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        GuestComboBox.SelectedValue = (int)reader["Guest_ID"];
                        HotelComboBox.SelectedValue = (int)reader["Hotel_ID"];
                        RatingComboBox.SelectedItem = (int)reader["Rating"];
                        CommentTextBox.Text = reader["Comments"].ToString();
                    }
                }
            }
        }
        private void LoadGuests()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    //connection.Open();
                    string query = "SELECT Guest_ID, Name FROM Guest";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dt.Columns.Add("DisplayText", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            row["DisplayText"] = $"{row["Guest_ID"]} - {row["Name"]}";
                        }
                        GuestComboBox.DataSource = dt;
                        GuestComboBox.DisplayMember = "DisplayText";
                        GuestComboBox.ValueMember = "Guest_ID";
                    }
                }
            }
        }

        private void LoadHotels()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    //connection.Open();
                    string query = "SELECT Hotel_ID, Name FROM Hotel";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        HotelComboBox.DataSource = dt;
                        dt.Columns.Add("DisplayText", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            row["DisplayText"] = $"{row["Hotel_ID"]} - {row["Name"]}";
                        }
                        HotelComboBox.DisplayMember = "DisplayText";
                        HotelComboBox.ValueMember = "Hotel_ID";
                    }
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (CommentTextBox.Text == null)
                {
                    MessageBox.Show("Please enter a comment");
                    return;
                }
                int HotelID = Convert.ToInt32(HotelComboBox.SelectedValue);
                int GuestID = Convert.ToInt32(GuestComboBox.SelectedValue);
                int Rating = Convert.ToInt32(RatingComboBox.SelectedItem);
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Update Feedback
                                    set Guest_ID = @Guest_ID, Hotel_ID = @Hotel_ID, Rating = @Rating, Comments = @Comments
                                    where Feedback_ID = @FeedbackID;
                                    ";
                    SqlCommand cmd = new SqlCommand(@query, con);
                    cmd.Parameters.AddWithValue("@Guest_ID", GuestID);
                    cmd.Parameters.AddWithValue("@Hotel_ID", HotelID);
                    cmd.Parameters.AddWithValue("@Rating", Rating);
                    cmd.Parameters.AddWithValue("@Comments", CommentTextBox.Text);
                    cmd.Parameters.AddWithValue("@FeedbackID", this.FeedbackID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
