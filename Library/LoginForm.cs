using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library
{
    public partial class LoginForm : Form
    {
         private string connectionString = "server=localhost;database=libsys;user=root;password=;";

        public LoginForm()
        {
            InitializeComponent();
        }
        private void Username_TextChanged(object sender, EventArgs e)
        {

        }
        private void Passfield_TextChanged(object sender, EventArgs e)
        {
        }

            private void login_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Passfield.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, username FROM users WHERE username = @username AND password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32("id");
                                string loggedInUsername = reader.GetString("username");

                                if (username == "admin" && password == "admin")
                                {
                                    // Redirect to AdminSide
                                    AdminSide adminForm = new AdminSide();
                                    this.Hide();
                                    adminForm.ShowDialog();
                                    this.Show();
                                }
                                else
                                {
                                    // Redirect to UserSide with ID and Username
                                    UserSide userForm = new UserSide(userId, loggedInUsername);
                                    this.Hide();
                                    userForm.ShowDialog();
                                    this.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Signup_Click(object sender, EventArgs e)
        {
            Signup signupForm = new Signup();
            this.Hide();
            signupForm.ShowDialog();
            this.Show();
        }
    }
}
