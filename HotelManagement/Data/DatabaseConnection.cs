using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagement.Data
{
    public class DatabaseConnection
    {
        private static string connectionString = "Data Source=.;Initial Catalog=HotelManagementSystem;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool TestConnection()
        {
            using (SqlConnection connection = GetConnection())
            {
                if (connection != null)
                {
                    connection.Close();
                    return true;
                }
                return false;
            }
        }
    }
}
