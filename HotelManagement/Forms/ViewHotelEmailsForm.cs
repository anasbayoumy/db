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
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            {
                string query = @"Select * from Hotel_emails
                                 where Hotel_ID = @HotelID
                                ";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HotelID", this.HotelID);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                EmailsGrid.DataSource = dt;
            }
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
                using (MySqlConnection con = DatabaseConnection.GetConnection()) {
                    string query = @"Delete from Hotel_emails
                                     where Hotel_ID = @Hotel_ID  and Email = @Email  
                                    ";
                    MySqlCommand cmd = new MySqlCommand( query, con);
                    cmd.Parameters.AddWithValue("@Hotel_ID", this.HotelID);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted");
                    LoadEmails();
                }

            }
        }
    }
}
