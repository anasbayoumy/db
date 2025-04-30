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
    public partial class AddServiceForm : Form
    {
        int Reservation_ID;
        public AddServiceForm(int Reservation_ID)
        {
            this.Reservation_ID = Reservation_ID;
            InitializeComponent();
            loadServices();
        }
        
        private void loadServices()
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                String query = @"SELECT s.Service_ID, s.Service_Name, s.Cost
                                 FROM Service s
                                 where s.Service_ID NOT in (Select Service_ID from Reservation_Service 
                                                            where Reservation_ID = @Reservation_ID)
                                ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Reservation_ID", this.Reservation_ID);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dt.Columns.Add("DisplayText", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    row["DisplayText"] = $"{row["Service_Name"]} - ${row["Cost"]}";
                }
                ServiceOptions.DisplayMember = "DisplayText";
                ServiceOptions.ValueMember = "Service_ID";
                ServiceOptions.DataSource = dt;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addService_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    String insert = @"Insert into Reservation_Service (Reservation_ID, Service_ID, Quantity)
                             Values(@Reservation_ID, @Service_ID, @Quantity)
                            ";
                    MySqlCommand cmd = new MySqlCommand(insert, connection);
                    cmd.Parameters.AddWithValue("@Reservation_ID", this.Reservation_ID);
                    cmd.Parameters.AddWithValue("@Service_ID", ServiceOptions.SelectedValue);
                    cmd.Parameters.AddWithValue("@Quantity", quantityCounter.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Service added/updated successfully.");
                    this.Close();
              
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding service: " + ex.Message);
                }
            }
        }
    }
}
