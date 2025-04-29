using System;
using System.Collections;
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
    public partial class ReservationServicesForm : Form
    {
        int Reservation_ID;
        public ReservationServicesForm(int Reservation_ID)
        {
            this.Reservation_ID = Reservation_ID;
            InitializeComponent();
            loadServices();
        }
        private void loadServices()
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    String query = @"Select s.Service_Name, s.Description, res.Quantity, res.Quantity*s.Cost as 'TotalCost'
                                        from Reservation_Service res
                                        Join Service s on res.Service_ID = s.Service_ID
                                        where res.Reservation_ID = @Reservation_ID
                                        ";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Reservation_ID", this.Reservation_ID);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    RservationServicesGrid.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddService_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void UpdateService_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void DeleteService_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
