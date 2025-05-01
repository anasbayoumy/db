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
    public partial class UpdateServiceDataForm : Form
    {
        int ServiceID;
        public UpdateServiceDataForm(int ServiceID)
        {
            this.ServiceID = ServiceID;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection con = DatabaseConnection.GetConnection()) {
                    string query = @"Select * from Service
                                     Where Service_ID = @ServiceID
                                    ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ServiceID", this.ServiceID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            NameTextBox.Text = reader["Service_Name"].ToString();
                            DescriptionTextBox.Text = reader["Description"].ToString();
                            PriceTextBox.Text = reader["Cost"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == null)
            {
                MessageBox.Show("Please enter a Name");
                return;
            }
            if (DescriptionTextBox.Text == null)
            {
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
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Update Service
                                     set Service_Name = @Name, Description = @Description, Cost = @Cost
                                     Where Service_ID = @Service_ID;
                                    ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", NameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Description", DescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@Cost", price);
                    cmd.Parameters.AddWithValue("@Service_ID", this.ServiceID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update");
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}
