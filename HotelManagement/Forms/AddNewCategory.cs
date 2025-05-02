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
    public partial class AddNewCategory : Form
    {
        public AddNewCategory()
        {
            InitializeComponent();
            LoadData();
            HotelComboBox.SelectedIndex = 0;
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection con = DatabaseConnection.GetConnection())
                {
                    string query = @"Select Hotel_ID, Name
                                 from Hotel
                                ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataTable.Columns.Add("DisplayText", typeof(string));
                    foreach (DataRow row in dataTable.Rows)
                    {
                        row["DisplayText"] = $"{row["Hotel_ID"]} - {row["Name"]}";
                    }
                    HotelComboBox.DataSource = dataTable;
                    HotelComboBox.DisplayMember = "DisplayText";
                    HotelComboBox.ValueMember = "Hotel_ID";
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(NameTextBox.Text == null)
            {
                MessageBox.Show("Please enter a name");
                return;
            }
            if (!int.TryParse(PriceTextBox.Text, out int Price) || Price <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for the amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection con = DatabaseConnection.GetConnection()) {
                try
                {
                    string query = @"Insert into Room_Category(Hotel_ID, Category, Price)
                                 values(@Hotel_ID, @Category, @Price)
                                ";
                    SqlCommand cmd= new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Hotel_ID", HotelComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@Category", NameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
