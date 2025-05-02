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
using System.Xml.Linq;

namespace HotelManagement.Forms
{
    public partial class ReservationPaymentsForm : Form
    {
        int ReservationID;
        public ReservationPaymentsForm(int reservationID)
        {
            this.ReservationID = reservationID;
            InitializeComponent();
            LoadPayments();
            Amount.Text = loadAmountDue().ToString();
        }
        private decimal loadAmountDue()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    /* //Amount due from services
                     int servicesCost=0;
                     string query1 = @"select SUM(res.quantity * s.Cost)
                                     from Reservation_Service res
                                     join Service s on res.Service_ID = s.Service_ID
                                     where res.Reservation_ID = @Reservation_ID
                                     ";
                     SqlCommand cmd1 = new SqlCommand(query1, conn);
                     cmd1.Parameters.AddWithValue("@Reservation_ID", this.ReservationID);
                     var res1 = cmd1.ExecuteScalar();
                     if (res1 != DBNull.Value)
                     {
                         servicesCost = Convert.ToInt32(res1);
                     }
                     //Get number of nights
                     int nights=0;
                     string query2 = @"select DATEDIFF(DAY, Check_in_Date, Check_out_Date)
                                       from Reservation
                                       where Reservation_ID = @Reservation_ID
                                     ";
                     SqlCommand cmd2 = new SqlCommand(query2, conn);
                     cmd2.Parameters.AddWithValue("@Reservation_ID", this.ReservationID);
                     var res2 = cmd2.ExecuteScalar();
                     if (res2 != DBNull.Value)
                     {
                         nights = Convert.ToInt32(res2);
                     }
                     //Amount due from rooms prices
                     int RoomsCost=0;
                     string query3 = @"select SUM(c.Price * @Nights)
                                       from Reservation_Rooms res
                                       join Room r on res.Room_Num = r.Room_Num and res.Hotel_ID = r.Hotel_ID
                                       join Room_Category c on res.Hotel_ID = c.Hotel_ID and r.Category = c.Category
                                       where res.Reservation_ID = @Reservation_ID
                                     ";
                     SqlCommand cmd3 = new SqlCommand(query3, conn);
                     cmd3.Parameters.AddWithValue("@Nights", nights);
                     cmd3.Parameters.AddWithValue("@Reservation_ID", this.ReservationID);
                     var res3 = cmd3.ExecuteScalar();
                     if (res3 != DBNull.Value)
                     {
                         RoomsCost = Convert.ToInt32(res3);
                     }


                     int total = RoomsCost + servicesCost;
                     //Remove amount paid by any previous payments
                     int paid = 0;
                     string query4 = @"select SUM(Amount)
                                       from Payment
                                       where Reservation_ID = @Reservation_ID
                                     ";
                     SqlCommand cmd4 = new SqlCommand(query4, conn);
                     cmd4.Parameters.AddWithValue("@Reservation_ID", this.ReservationID);
                     var res4 = cmd4.ExecuteScalar();
                     if (res4 != DBNull.Value)
                     {
                         paid = Convert.ToInt32(res4);
                     }
                     int final = total - paid;
                     return final;*/
                    decimal amount = 0;
                    string query = @"SELECT dbo.Get_Reservation_Amount_Due(@Reservation_ID)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Reservation_ID", this.ReservationID);
                    decimal result = (decimal)cmd.ExecuteScalar();
                    if (result > 0) { amount = result; }
                    return amount;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return -1;
            }
        }
        private void LoadPayments()
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                /* string query = @"Select *
                                  from Payment
                                  where Reservation_ID = @Reservation_ID
                                 ";*/
                string query = @"ListPaymentsForReservationProc";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Reservation_ID", this.ReservationID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                ReservationPaymentsGrid.DataSource = dataTable;
                ReservationPaymentsGrid.Columns["Reservation_ID"].Visible = false;
            }

        }

        private void AddPayment_Click(object sender, EventArgs e)
        {
            using(AddResPaymentForm payment = new AddResPaymentForm(this.ReservationID))
            {
                payment.ShowDialog();
            }
            Amount.Text = loadAmountDue().ToString();
            LoadPayments();
        }

        private void updatePayment_Click(object sender, EventArgs e)
        {
            if (ReservationPaymentsGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = ReservationPaymentsGrid.SelectedRows[0];
                int PaymentID = Convert.ToInt32(selectedRow.Cells["Payment_ID"].Value);
                using (UpdatePaymentForm payment = new UpdatePaymentForm(PaymentID))
                {
                    payment.ShowDialog();
                }
                Amount.Text = loadAmountDue().ToString();
                LoadPayments();
            }
            else
            {
                MessageBox.Show("Please select one row");
            }
        }

        private void DeletePayment_Click(object sender, EventArgs e)
        {
            if (ReservationPaymentsGrid.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Are you sure you want to delete this reservation?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = ReservationPaymentsGrid.SelectedRows[0];
                    int PaymentID = Convert.ToInt32(selectedRow.Cells["Payment_ID"].Value);
                    using (SqlConnection con = DatabaseConnection.GetConnection())
                    {
                        string query = @"Delete from Payment
                                         where Payment_ID = @Payment_ID
                                        ";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Payment_ID", PaymentID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Deleted");
                        Amount.Text = loadAmountDue().ToString();
                        LoadPayments() ;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select one row");
            }
        }
    }
}
