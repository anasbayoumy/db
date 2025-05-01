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
using Org.BouncyCastle.Ocsp;

namespace HotelManagement.Forms
{
    public partial class AddResPaymentForm : Form
    {
        int Reservation_ID;
        public AddResPaymentForm(int Reservation_ID)
        {
            this.Reservation_ID = Reservation_ID;
            InitializeComponent();
            methodComboBox.Items.AddRange(new string[] {"Cash", "Credit Card", "Online Transfer" });
            methodComboBox.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(AmountTextBox.Text, out int amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for the amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String method = methodComboBox.SelectedItem as string;
            DateTime Payment_Date = DateTime.Now;
            try
            {
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Insert into Payment(Reservation_ID, Payment_Date, Amount, Payment_Method)
                                 values(@Reservation_ID, @Payment_Date, @Amount, @Payment_Method)
                                ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Reservation_ID", this.Reservation_ID);
                    cmd.Parameters.AddWithValue("@Payment_Date", Payment_Date);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Payment_Method", method);
                    cmd.ExecuteNonQuery();
                    string query2 = @"Update Reservation
                                    set Status = 'Confirmed'
                                    where Reservation_ID = @Reservation_ID
                                    ";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.Parameters.AddWithValue("@Reservation_ID", this.Reservation_ID);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Added");
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error " + ex.Message); }
        }
    }
}
