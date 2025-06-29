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
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Select f.Feedback_ID, g.Name as Guest_Name, h.Name as Hotel_Name, f.Rating, f.Comments, f.Feedback_Date 
                                     from Feedback f
                                     join Guest g on f.Guest_ID = g.Guest_ID
                                     join Hotel h on f.Hotel_ID = h.Hotel_ID
                                     ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
                    using(SqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        string query = @"Delete from Feedback
                                         where Feedback_ID = @FeedbackID
                                        ";
                        SqlCommand cmd = new SqlCommand(query, connection);
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
