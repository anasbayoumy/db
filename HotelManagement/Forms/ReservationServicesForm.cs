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
using System.Data.SqlClient;

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
                using (SqlConnection connection = DatabaseConnection.GetConnection())
                {
                    String query = @"Select s.Service_Name, s.Description, res.Quantity, res.Quantity*s.Cost as 'TotalCost', res.Service_ID
                                        from Reservation_Service res
                                        Join Service s on res.Service_ID = s.Service_ID
                                        where res.Reservation_ID = @Reservation_ID
                                        ";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Reservation_ID", this.Reservation_ID);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    RservationServicesGrid.DataSource = dataTable;
                    RservationServicesGrid.Columns["Service_ID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading service data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddService_Click(object sender, EventArgs e)
        {
            using (AddServiceForm addService = new AddServiceForm(this.Reservation_ID))
            {
                addService.ShowDialog();
            }
            loadServices();
            
        }
        private void UpdateService_Click(object sender, EventArgs e)
        {
            if (RservationServicesGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = RservationServicesGrid.SelectedRows[0];
                int service_ID = Convert.ToInt32(selectedRow.Cells["Service_ID"].Value);
                using (UpdateServiceForm update = new UpdateServiceForm(this.Reservation_ID, service_ID))
                {
                    update.ShowDialog();
                }
                loadServices();
            }
            
        }
        private void DeleteService_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this service?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                if (RservationServicesGrid.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = RservationServicesGrid.SelectedRows[0];
                    int service_ID = Convert.ToInt32(selectedRow.Cells["Service_ID"].Value);
                    try
                    {
                        using (SqlConnection conn = DatabaseConnection.GetConnection())
                        {
                            string delete = @"Delete from Reservation_Service
                                      where Reservation_ID = @Reservation_ID and Service_ID = @Service_ID
                                     ";
                            SqlCommand command = new SqlCommand(delete, conn);
                            command.Parameters.AddWithValue("@Reservation_ID", this.Reservation_ID);
                            command.Parameters.AddWithValue("@Service_ID", service_ID);
                            command.ExecuteNonQuery();
                        }
                        MessageBox.Show("Service Removed");
                        loadServices();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


    }
}
