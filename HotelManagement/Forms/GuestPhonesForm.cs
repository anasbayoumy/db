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
    public partial class GuestPhonesForm : Form
    {
        int guestID;
        public GuestPhonesForm(int guestID)
        {
            this.guestID = guestID;
            InitializeComponent();
            LoadPhones();
        }

        private void LoadPhones()
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"Select Phone_number 
                                 From Guest_Phone_nums
                                 Where Guest_ID = @Guest_ID
                                ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Guest_ID", this.guestID);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                GuestPhonesGrid.DataSource = dataTable;
            }

        }

        private void AddPhoneButton_Click(object sender, EventArgs e)
        {
            using(AddPhoneForm phone = new AddPhoneForm(this.guestID))
            {
                phone.ShowDialog();
            }
            LoadPhones();
        }

        private void DeletePhoneButton_Click(object sender, EventArgs e)
        {
            if(GuestPhonesGrid.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = GuestPhonesGrid.SelectedRows[0];
                string PhoneNum = selectedRow.Cells["Phone_number"].Value.ToString();
                try
                {
                    using (MySqlConnection conn = DatabaseConnection.GetConnection())
                    {
                        string query = @"Delete from Guest_Phone_nums
                                         Where Phone_number = @Phone
                                        ";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Phone", PhoneNum);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Done");
                        LoadPhones();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }
    }
}
