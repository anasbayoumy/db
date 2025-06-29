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
    public partial class ViewAllPaymentsForm : Form
    {
        public ViewAllPaymentsForm()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Select * from Payment";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    PaymentsGrid.DataSource = dataTable;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void button3_Click(object sender, EventArgs e)
        {//Delete
            if (PaymentsGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow selected = PaymentsGrid.SelectedRows[0];
                int paymentID = Convert.ToInt32(selected.Cells["Payment_ID"].Value);
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Delete from Payment
                                     Where Payment_ID = @Payment_ID
                                    ";
                    SqlCommand cmd = new SqlCommand(query, con);
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
