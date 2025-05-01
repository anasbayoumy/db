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
    public partial class UpdatePaymentForm : Form
    {
        int PaymentID;
        public UpdatePaymentForm(int PaymentID)
        {
            this.PaymentID = PaymentID;
            InitializeComponent();
            string[] options = { "Cash", "Credit Card", "Online Transfer" };
            methodComboBox.Items.AddRange(options);
            loadData();
        }

        private void loadData()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    string query = "SELECT * FROM Payment WHERE Payment_ID = @Payment_ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Payment_ID", this.PaymentID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            AmountTextBox.Text = reader["Amount"].ToString();
                            methodComboBox.SelectedItem = reader["Payment_Method"].ToString();
                        }
                    }
                }
            }

        }

        private void UpdatePaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(AmountTextBox.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for the amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String method = methodComboBox.SelectedItem as string;
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"Update Payment
                                set Amount = @Amount, Payment_Method = @Payment_Method
                                where Payment_ID = @Payment_ID
                                ";
                SqlCommand command = new SqlCommand( query, conn);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@Payment_Method", method);
                command.Parameters.AddWithValue("@Payment_ID", this.PaymentID);
                command.ExecuteNonQuery();
                MessageBox.Show("Updated");
                this.Close();
            }
        }
    }
}
