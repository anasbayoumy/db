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
    public partial class AddEmailForm : Form
    {
        int hotelID;
        public AddEmailForm(int hotelID)
        {
            this.hotelID = hotelID;
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if(Emailtextbox.Text == null)
            {
                MessageBox.Show("Enter an email");
                return;
            }
            using (MySqlConnection con = DatabaseConnection.GetConnection()) {
                string query = @" Insert into Hotel_emails (Hotel_ID, Email)
                                  values(@HotelID, @Email)
                                ";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HotelID", this.hotelID);
                cmd.Parameters.AddWithValue("@Email", Emailtextbox.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added");
                this.Close();
            }
        }
    }
}
