using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class ViewUsers : Form
    {
        private string connectionString = "server=localhost;database=libsys;user=root;password=;";

        public ViewUsers()
        {
            InitializeComponent();
            LoadUsers();

        }
        private void LoadUsers()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM users"; // Excluding password for security

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_Books_Click(object sender, EventArgs e)
        {
            // Navigate to AdminSide
            AdminSide adminForm = new AdminSide();
            this.Hide();
            adminForm.ShowDialog();
            this.Show();
        }
        private void View_reports_Click(object sender, EventArgs e)
        {
            // Navigate to Reports.cs
            Reports reportsForm = new Reports();
            this.Hide();
            reportsForm.ShowDialog();
            this.Show();
        }

        private void View_users_Click(object sender, EventArgs e)
        {
            // Navigate to ViewUsers.cs
            ViewUsers usersForm = new ViewUsers();
            this.Hide();
            usersForm.ShowDialog();
            this.Show();
        }

        private void LOGOUT_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            this.Hide();
            loginform.ShowDialog();
            this.Show();
        }


        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user to delete!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            string username = dataGridView1.SelectedRows[0].Cells["username"].Value.ToString();

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete user '{username}'?",
                                                   "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM users WHERE id = @userId";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers(); // Refresh the DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SearchUsers(string keyword)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id, fullname, number, email, address, username FROM users " +
                                   "WHERE fullname LIKE @keyword OR " +
                                   "email LIKE @keyword OR " +
                                   "username LIKE @keyword OR " +
                                   "address LIKE @keyword OR " +
                                   "number LIKE @keyword";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchfield_TextChanged(object sender, EventArgs e)
        {
            SearchUsers(searchfield.Text);
        }

        private void search_Click(object sender, EventArgs e)
        {
            SearchUsers(searchfield.Text);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
