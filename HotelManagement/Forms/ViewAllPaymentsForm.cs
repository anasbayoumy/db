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
    public partial class ViewAllPaymentsForm : Form
    {
        public ViewAllPaymentsForm()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            {
                string query = @"Select * from Payment";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                PaymentsGrid.DataSource = dataTable;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {//Delete
            if (PaymentsGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow selected = PaymentsGrid.SelectedRows[0];
                int paymentID = Convert.ToInt32(selected.Cells["Payment_ID"].Value);
                using (MySqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Delete from Payment
                                     Where Payment_ID = @Payment_ID
                                    ";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Payment_ID", paymentID);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deleted");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex.Message);
                    }
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (AddPaymentForm payment = new AddPaymentForm()) { 
                payment.ShowDialog();
            }
            LoadData();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (PaymentsGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow selected= PaymentsGrid.SelectedRows[0];
                int paymentID = Convert.ToInt32(selected.Cells["Payment_ID"].Value);
                using (UpdatePaymentForm payment = new UpdatePaymentForm(paymentID))
                {
                    payment.ShowDialog();
                }
                LoadData();
            }
        }
    }
}
