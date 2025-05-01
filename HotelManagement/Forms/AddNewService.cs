using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.Reflection;
using HotelManagement.Data;
using MySql.Data.MySqlClient;

namespace HotelManagement.Forms
{
    public partial class AddNewService : Form
    {
        public AddNewService()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if(NameTextBox.Text == null)
            {
                MessageBox.Show("Please enter a Name");
                return;
            }
            if (DescriptionTextBox.Text == null) {
                MessageBox.Show("Please enter a description");
                return;
            }
            if (!decimal.TryParse(PriceTextBox.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Enter a positive number");
                return;
            }
            try
            {
                using (MySqlConnection con = DatabaseConnection.GetConnection()) {
                    string query = @"Insert into Service(Service_Name, Description, Cost)
                                     values(@Name, @Description, @Cost)
                                    ";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", NameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Description",DescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@Cost", price);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added");
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
