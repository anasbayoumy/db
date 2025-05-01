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
using Google.Protobuf.Reflection;
using HotelManagement.Data;
using System.Data.SqlClient;
using Org.BouncyCastle.Utilities.Collections;

namespace HotelManagement.Forms
{
    public partial class UpdateServiceForm : Form
    {
        int Reservation_ID;
        int Service_ID;
        public UpdateServiceForm(int Reservation_ID, int Service_ID)
        {
            this.Reservation_ID = Reservation_ID;
            this.Service_ID = Service_ID;
            InitializeComponent();
            LoadQuantity();
        }

        private void LoadQuantity()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"Select Quantity from Reservation_Service
                                where Reservation_ID = @Reservation_ID and Service_ID = @Service_ID
                                ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Reservation_ID", this.Reservation_ID);
                cmd.Parameters.AddWithValue("@Service_ID", this.Service_ID);
                int quantity = (int)cmd.ExecuteScalar();
                QuantityCounter.Value = quantity;

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    string update = @"Update Reservation_Service
                                    set Quantity = @Quantity
                                    where Reservation_ID = @Reservation_ID and Service_ID = @Service_ID
                                    ";
                    SqlCommand cmd = new SqlCommand(update, conn);
                    cmd.Parameters.AddWithValue("@Reservation_ID", this.Reservation_ID);
                    cmd.Parameters.AddWithValue("@Service_ID", this.Service_ID);
                    cmd.Parameters.AddWithValue("@Quantity", QuantityCounter.Value);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Quantity Updated.");
                    this.Close();
                }
                catch (Exception ex){
                    MessageBox.Show("Error adding service: " + ex.Message);
                }
            }
        }
    }
}
