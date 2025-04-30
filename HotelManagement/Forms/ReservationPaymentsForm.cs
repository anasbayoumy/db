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
        private int loadAmountDue()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    //Amount due from services
                    int servicesCost;
                    string query1 = @"select SUM(res.quantity * s.Cost)
                                    from Reservation_Service res
                                    join Service s on res.Service_ID = s.Service_ID
                                    where res.Reservation_ID = @Reservation_ID
                                    ";
                    MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                    cmd1.Parameters.AddWithValue("@Reservation_ID", this.ReservationID);
                    servicesCost = Convert.ToInt32(cmd1.ExecuteScalar());
                    //Get number of nights
                    int nights;
                    string query2 = @"select DATEDIFF(Check_out_Date, Check_in_Date)
                                      from Reservation
                                      where Reservation_ID = @Reservation_ID
                                    ";
                    MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                    cmd2.Parameters.AddWithValue("@Reservation_ID", this.ReservationID);
                    nights = Convert.ToInt32(cmd2.ExecuteScalar());
                    //Amount due from rooms prices
                    int RoomsCost;
                    string query3 = @"select SUM(c.Price * @Nights)
                                      from Reservation_Rooms res
                                      join Room r on res.Room_Num = r.Room_Num and res.Hotel_ID = r.Hotel_ID
                                      join Room_Category c on res.Hotel_ID = c.Hotel_ID and r.Category = c.Category
                                      where res.Reservation_ID = @Reservation_ID
                                    "; 
                    MySqlCommand cmd3 = new MySqlCommand(query3, conn);
                    cmd3.Parameters.AddWithValue("@Nights", nights);
                    cmd3.Parameters.AddWithValue("@Reservation_ID", this.ReservationID);
                    RoomsCost = Convert.ToInt32(cmd3.ExecuteScalar());

                    int total = RoomsCost + servicesCost;
                    //Remove amount paid by any previous payments
                    int paid;
                    string query4 = @"select SUM(Amount)
                                      from Payment
                                      where Reservation_ID = @Reservation_ID
                                    ";
                    MySqlCommand cmd4 = new MySqlCommand(query4, conn);
                    cmd4.Parameters.AddWithValue("@Reservation_ID", this.ReservationID);
                    paid = Convert.ToInt32(cmd4.ExecuteScalar());

                    int final = total - paid;
                    return final;
                }
            }
            catch (Exception ex) { 
                    MessageBox.Show("Error: " +  ex.Message);
                return -1;
            }
        }
        private void LoadPayments()
        {

        }
    }
}
