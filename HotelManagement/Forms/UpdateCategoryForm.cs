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
    public partial class UpdateCategoryForm : Form
    {
        int Hotel_ID;
        string catName;
        public UpdateCategoryForm(int Hotel_ID, string catName)
        {
            this.Hotel_ID = Hotel_ID;
            this.catName = catName;
            InitializeComponent();
            LoadData();
            HotelComboBox.SelectedValue = Hotel_ID;
            NameTextBox.Text = catName;
        }
        private void LoadData()
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

                string query2 = @"Select Price
                                  from Room_Category
                                  where Hotel_ID = @Hotel_ID and Category = @Category
                                ";
                SqlCommand command = new SqlCommand(query2, con);
                command.Parameters.AddWithValue("@Hotel_ID", this.Hotel_ID);
                command.Parameters.AddWithValue("@Category", this.catName);
                var result = command.ExecuteScalar();
                decimal price=0;
                if (result != DBNull.Value)
                {
                    price = Convert.ToDecimal(result);
                }
                PriceTextBox.Text = price.ToString();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == null)
            {
                MessageBox.Show("Please enter a name");
                return;
            }
            if (!decimal.TryParse(PriceTextBox.Text, out decimal Price) || Price <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for the amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection con = DatabaseConnection.GetConnection())
            {
                try
                {
                    string query = @"Update Room_Category
                                    set Hotel_ID = @Hotel_ID, Category = @Category, Price = @Price
                                    where Hotel_ID = @oldHotel_ID and Category = @oldCategory
                                ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Hotel_ID", HotelComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@Category", NameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    cmd.Parameters.AddWithValue("@oldHotel_ID", this.Hotel_ID);
                    cmd.Parameters.AddWithValue("@oldCategory", this.catName);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated");
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
