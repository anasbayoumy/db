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
    public partial class NewHotelForm : Form
    {
        public NewHotelForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(NameTextBox.Text == null)
            {
                MessageBox.Show("Please enter a name");
                return;
            }
            if (LocationTextBox.Text == null)
            {
                MessageBox.Show("Please enter a location");
                return;
            }
            if (!int.TryParse(roomsTextBox.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Enter a positive number");
                return;
            }
            try
            {
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Insert into Hotel(Name,Location,Num_Rooms)
                                 values(@Name, @Location, @Rooms)
                                ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", NameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Location", LocationTextBox.Text);
                    cmd.Parameters.AddWithValue("@Rooms", roomsTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added");
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error:" + ex.Message); }
        }
    }
}
