using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HotelManagement.Data;

namespace HotelManagement.Forms
{
    public class AddGuestForm : Form
    {
        private TextBox nameTextBox;
        private TextBox emailTextBox;
        private TextBox nationalityTextBox;
        private ComboBox genderComboBox;
        private DateTimePicker dateOfBirthPicker;
        private TextBox ageTextBox;
        private TextBox passportTextBox;
        private Button saveButton;
        private Button cancelButton;

        public AddGuestForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Add New Guest";
            this.Size = new System.Drawing.Size(400, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Create labels and controls
            Label nameLabel = new Label { Text = "Name:", Location = new System.Drawing.Point(20, 20) };
            nameTextBox = new TextBox { Location = new System.Drawing.Point(130, 20), Size = new System.Drawing.Size(240, 20) };

            Label nationalityLabel = new Label { Text = "Nationality:", Location = new System.Drawing.Point(20, 60) };
            nationalityTextBox = new TextBox { Location = new System.Drawing.Point(130, 60), Size = new System.Drawing.Size(240, 20) };

            Label genderLabel = new Label { Text = "Gender:", Location = new System.Drawing.Point(20, 100) };
            genderComboBox = new ComboBox { Location = new System.Drawing.Point(130, 100), Size = new System.Drawing.Size(240, 20) };
            genderComboBox.Items.AddRange(new string[] { "Male", "Female" });

            Label dobLabel = new Label { Text = "Date of Birth:", Location = new System.Drawing.Point(20, 140) };
            dateOfBirthPicker = new DateTimePicker { Location = new System.Drawing.Point(130, 140), Size = new System.Drawing.Size(240, 20) };

            Label ageLabel = new Label { Text = "Age:", Location = new System.Drawing.Point(20, 180) };
            ageTextBox = new TextBox { Location = new System.Drawing.Point(130, 180), Size = new System.Drawing.Size(240, 20) };

            Label passportLabel = new Label { Text = "Passport No:", Location = new System.Drawing.Point(20, 220) };
            passportTextBox = new TextBox { Location = new System.Drawing.Point(130, 220), Size = new System.Drawing.Size(240, 20) };

            Label EmailLabel = new Label { Text = "Email:", Location = new System.Drawing.Point(20, 260) };
            emailTextBox = new TextBox { Location = new System.Drawing.Point(130, 260), Size = new System.Drawing.Size(240, 20) };

            saveButton = new Button
            {
                Text = "Save",
                Location = new System.Drawing.Point(130, 300),
                Size = new System.Drawing.Size(100, 30)
            };
            saveButton.Click += SaveButton_Click;

            cancelButton = new Button
            {
                Text = "Cancel",
                Location = new System.Drawing.Point(270, 300),
                Size = new System.Drawing.Size(100, 30)
            };
            cancelButton.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // Add controls to form
            this.Controls.AddRange(new Control[] {
                nameLabel, nameTextBox,
                nationalityLabel, nationalityTextBox,
                genderLabel, genderComboBox,
                dobLabel, dateOfBirthPicker,
                ageLabel, ageTextBox,
                passportLabel, passportTextBox,
                EmailLabel, emailTextBox,
                saveButton, cancelButton
            });
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    using (MySqlConnection connection = DatabaseConnection.GetConnection())
                    {
                        if (connection != null)
                        {
                            string query = @"INSERT INTO Guest (Name, Nationality, Gender, Date_of_Birth, Age, Passport_Number, email)
                                           VALUES (@Name, @Nationality, @Gender, @Date_of_Birth, @Age, @Passport_Number, @email)";

                            MySqlCommand command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@Name", nameTextBox.Text);
                            command.Parameters.AddWithValue("@Nationality", nationalityTextBox.Text);
                            command.Parameters.AddWithValue("@Gender", genderComboBox.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@Date_of_Birth", dateOfBirthPicker.Value);
                            command.Parameters.AddWithValue("@Age", Convert.ToInt32(ageTextBox.Text));
                            command.Parameters.AddWithValue("@Passport_Number", passportTextBox.Text);
                            command.Parameters.AddWithValue("@email", emailTextBox.Text);

                            command.ExecuteNonQuery();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding guest: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InitializeComponent()
        {

        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please enter a name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (genderComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(ageTextBox.Text, out int age) || age < 0)
            {
                MessageBox.Show("Please enter a valid age.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(passportTextBox.Text))
            {
                MessageBox.Show("Please enter a passport number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Please enter an email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
} 