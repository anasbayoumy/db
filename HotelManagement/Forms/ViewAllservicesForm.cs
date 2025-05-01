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
    public partial class ViewAllservicesForm : Form
    {
        public ViewAllservicesForm()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            {
                string query = @"Select * from Service";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                ServicesGrid.DataSource = dt;
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            using(AddNewService service = new AddNewService())
            {
                service.ShowDialog();
            }
            LoadData();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (ServicesGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow selected = ServicesGrid.SelectedRows[0];
                int service_ID = Convert.ToInt32(selected.Cells["Service_ID"].Value);
                using (UpdateServiceDataForm service = new UpdateServiceDataForm(service_ID)) { 
                    service.ShowDialog();
                }
                LoadData();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServicesGrid.SelectedRows.Count == 1)
                {
                    DataGridViewRow selected = ServicesGrid.SelectedRows[0];
                    int service_ID = Convert.ToInt32(selected.Cells["Service_ID"].Value);
                    using (MySqlConnection con = DatabaseConnection.GetConnection())
                    {
                        string query = @"Delete from Service 
                                     where Service_ID = @Service_ID
                                    ";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Service_ID", service_ID);
                        cmd.ExecuteNonQuery();
                        LoadData();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
    }
}
