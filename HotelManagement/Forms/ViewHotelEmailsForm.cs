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
    public partial class ViewHotelEmailsForm : Form
    {
        int HotelID;
        public ViewHotelEmailsForm(int HotelID)
        {
            this.HotelID = HotelID;
            InitializeComponent();
            LoadEmails();
        }

        private void LoadEmails()
        {
            try
            {
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Select * from Hotel_emails
                                 where Hotel_ID = @HotelID
                                ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@HotelID", this.HotelID);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    EmailsGrid.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {//Add
            using(AddEmailForm email = new AddEmailForm(this.HotelID)) { email.ShowDialog(); }
            LoadEmails();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (EmailsGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow selected = EmailsGrid.SelectedRows[0];
                string email = selected.Cells["Email"].Value.ToString();
                try
                {
                    using (SqlConnection con = DatabaseConnection.GetConnection())
                    {
                        string query = @"Delete from Hotel_emails
                                     where Hotel_ID = @Hotel_ID  and Email = @Email  
                                    ";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Hotel_ID", this.HotelID);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deleted");
                        LoadEmails();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }

            }
        }
    }
}
