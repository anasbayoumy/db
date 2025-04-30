using MySql.Data.MySqlClient;
using System;

namespace HotelManagement.Data
{
    public class DatabaseConnection
    {
        private static readonly string connectionString = "Server=77.37.35.50;Database=u153805899_dbproj;Uid=u153805899_dbproj;Pwd=Try213213;";
        
        public static MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
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
            using (MySqlConnection connection = GetConnection())
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