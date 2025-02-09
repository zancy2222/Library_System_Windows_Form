using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library
{
    public partial class Signup : Form
    {
        private string connectionString = "server=localhost;database=libsys;user=root;password=;";

        public Signup()
        {
            InitializeComponent();
        }
        private void Fullnamefield_TextChanged(object sender, EventArgs e)
        {
            // THIS IS A TEXTBOX
        }

        private void Numberfield_TextChanged(object sender, EventArgs e)
        {
            // THIS IS A TEXTBOX
        }

        private void Emailfield_TextChanged(object sender, EventArgs e)
        {
            // THIS IS A TEXTBOX
        }

        private void Addressfield_TextChanged(object sender, EventArgs e)
        {
            // THIS IS A TEXTBOX
        }

        private void UsernameField_TextChanged(object sender, EventArgs e)
        {
            // THIS IS A TEXTBOX
        }

        private void PassField_TextChanged(object sender, EventArgs e)
        {
            // THIS IS A TEXTBOX
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // Get user input from text fields
            string fullname = Fullnamefield.Text;
            string number = Numberfield.Text;
            string email = Emailfield.Text;
            string address = Addressfield.Text;
            string username = UsernameField.Text;
            string password = PassField.Text;

            // Validate input fields
            if (string.IsNullOrWhiteSpace(fullname) || string.IsNullOrWhiteSpace(number) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save user data to MySQL
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO users (fullname, number, email, address, username, password) VALUES (@fullname, @number, @email, @address, @username, @password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@fullname", fullname);
                        cmd.Parameters.AddWithValue("@number", number);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Signup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Close the signup form
                        }
                        else
                        {
                            MessageBox.Show("Signup failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CANCEL_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the signup form
        }
    }
}
