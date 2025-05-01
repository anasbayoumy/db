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
    public partial class ViewFeedbackForm : Form
    {
        public ViewFeedbackForm()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            try
            {
                using (MySqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Select f.Feedback_ID, g.Name as Guest_Name, h.Name as Hotel_Name, f.Rating, f.Comments, f.Feedback_Date 
                                     from Feedback f
                                     join Guest g on f.Guest_ID = g.Guest_ID
                                     join Hotel h on f.Hotel_ID = h.Hotel_ID
                                     ";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    FeedbackGrid.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            using (AddFeedback feedback = new AddFeedback()) {
                feedback.ShowDialog();
            }
            loadData();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (FeedbackGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow selected = FeedbackGrid.SelectedRows[0];
                int feedbackID = Convert.ToInt32(selected.Cells["Feedback_ID"].Value);
                using (UpdateFeedback feedback = new UpdateFeedback(feedbackID))
                {
                    feedback.ShowDialog();
                }
                loadData();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (FeedbackGrid.SelectedRows.Count == 1)
                {
                    DataGridViewRow selected= FeedbackGrid.SelectedRows[0];
                    int feedbackID = Convert.ToInt32(selected.Cells["Feedback_ID"].Value);
                    using(MySqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        string query = @"Delete from Feedback
                                         where Feedback_ID = @FeedbackID
                                        ";
                        MySqlCommand cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@FeedbackID", feedbackID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deleted");
                        loadData();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error" + ex.Message);
            }
        }
    }
}
