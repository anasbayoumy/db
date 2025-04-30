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
            using (MySqlConnection con = DatabaseConnection.GetConnection()) {
                string query = @"Insert into Payment(Reservation_ID, Payment_Date, Amount, Payment_Method)
                                 values(@Reservation_ID, @Payment_Date, @Amount, @Payment_Method)
                                ";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Reservation_ID", this.Reservation_ID);
                cmd.Parameters.AddWithValue("@Payment_Date", Payment_Date);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Payment_Method", method);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added");
                this.Close();
            }
        }
    }
}
