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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManagement.Forms
{
    public partial class AddFeedback : Form
    {
        public AddFeedback()
        {
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
            GuestComboBox.SelectedIndex = 0;
            HotelComboBox.SelectedIndex = 0;
            RatingComboBox.SelectedIndex = 0;
        }
        private void LoadGuests()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    try{
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
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
            }
        }

        private void LoadHotels()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    try
                    {
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
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
            }
        }
        private void Add_Click(object sender, EventArgs e)
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
                DateTime date = DateTime.Now;
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Insert into Feedback(Guest_ID, Hotel_ID, Rating, Comments, Feedback_Date)
                                values(@Guest_ID, @Hotel_ID, @Rating, @Comments, @Feedback_Date)
                                ";
                    SqlCommand cmd = new SqlCommand(@query, con);
                    cmd.Parameters.AddWithValue("@Guest_ID", GuestID);
                    cmd.Parameters.AddWithValue("@Hotel_ID", HotelID);
                    cmd.Parameters.AddWithValue("@Rating", Rating);
                    cmd.Parameters.AddWithValue("@Comments", CommentTextBox.Text);
                    cmd.Parameters.AddWithValue("@Feedback_Date", date);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Added");
                        this.Close();
                    }
                    catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error " + ex.Message);
            }
        }
    }
}
