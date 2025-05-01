﻿using System;
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
    public partial class ViewRoomCategories : Form
    {
        public ViewRoomCategories()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            using (MySqlConnection con = DatabaseConnection.GetConnection())
            {
                string query = @"Select c.Hotel_ID, h.Name, c.Category, c.Price
                                 from Room_Category c
                                 Join Hotel h on c.Hotel_ID = h.Hotel_ID
                                ";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                RoomCategoriesGrid.DataSource = dataTable;
            }
        }

        private void AddCategory_Click(object sender, EventArgs e)
        {
            using (AddNewCategory category = new AddNewCategory()) { 
                category.ShowDialog();
            }
            LoadCategories();

        }

        private void UpdateCategory_Click(object sender, EventArgs e)
        {
            if (RoomCategoriesGrid.SelectedRows.Count == 1) {
                DataGridViewRow selectedRow = RoomCategoriesGrid.SelectedRows[0];
                int Hotel_ID = Convert.ToInt32(selectedRow.Cells["Hotel_ID"].Value);
                string catName = selectedRow.Cells["Category"].Value.ToString();
                using (UpdateCategoryForm category = new UpdateCategoryForm(Hotel_ID, catName))
                {
                    category.ShowDialog();
                }
                LoadCategories() ;
            }
        }

        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            if (RoomCategoriesGrid.SelectedRows.Count == 1)
            {
                try
                {
                    DataGridViewRow selectedRow = RoomCategoriesGrid.SelectedRows[0];
                    int Hotel_ID = Convert.ToInt32(selectedRow.Cells["Hotel_ID"].Value);
                    string catName = selectedRow.Cells["Category"].Value.ToString();
                    using (MySqlConnection con = DatabaseConnection.GetConnection())
                    {
                        string query = @"Delete from Room_Category
                                         where Hotel_ID = @Hotel_ID and Category = @Category
                                        ";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Hotel_ID", Hotel_ID);
                        cmd.Parameters.AddWithValue("@Category", catName);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Done");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You are not allowed to delete this. " , ex.Message );
                }
                   
                LoadCategories();
            }
        }
    }
}
