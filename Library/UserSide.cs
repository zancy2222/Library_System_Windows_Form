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
    public partial class UserSide : Form
    {
        private string connectionString = "server=localhost;database=libsys;user=root;password=;";

        private int userId;
        private string username;

        public UserSide(int userId, string username)
        {
            InitializeComponent();
            this.userId = userId;
            this.username = username;

            // Display the logged-in username
            UsernameLabel.Text = username;
            LoadBooks(); // Load books on form open

        }
        private void LoadBooks()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Ensure books with qty = 0 are marked as "Borrowed"
                    string updateQuery = "UPDATE books SET status = 'Borrowed' WHERE quantity = 0 AND status = 'Available'";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.ExecuteNonQuery();
                    }

                    // Fetch all books and display
                    string query = "SELECT * FROM books";
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
                MessageBox.Show("Error loading books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Borrow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a book to borrow!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["book_id"].Value);
            int quantity = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["quantity"].Value);
            string status = dataGridView1.SelectedRows[0].Cells["status"].Value.ToString();

            // Check if book is available
            if (quantity <= 0 || status == "Missing" || status == "Damaged" || status == "Borrowed")
            {
                MessageBox.Show("This book is unavailable for borrowing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert into borrowed_books
                    string borrowQuery = "INSERT INTO borrowed_books (user_id, book_id, borrow_date) VALUES (@userId, @bookId, NOW())";
                    using (MySqlCommand cmd = new MySqlCommand(borrowQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.ExecuteNonQuery();
                    }

                    // Update book quantity and status
                    string updateBookQuery = @"
                UPDATE books 
                SET quantity = quantity - 1, 
                    status = CASE WHEN quantity - 1 = 0 THEN 'Borrowed' ELSE status END 
                WHERE book_id = @bookId";

                    using (MySqlCommand cmd = new MySqlCommand(updateBookQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Book borrowed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RETURN_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a book to return!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["book_id"].Value);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if user has borrowed this book
                    string checkQuery = "SELECT COUNT(*) FROM borrowed_books WHERE book_id = @bookId AND user_id = @userId AND return_date IS NULL";
                    using (MySqlCommand cmd = new MySqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.Parameters.AddWithValue("@userId", userId);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 0)
                        {
                            MessageBox.Show("You haven't borrowed this book!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Mark as returned
                    string returnQuery = "UPDATE borrowed_books SET return_date = NOW(), status = 'Returned' WHERE book_id = @bookId AND user_id = @userId AND return_date IS NULL";
                    using (MySqlCommand cmd = new MySqlCommand(returnQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }

                    // Update book quantity and status
                    string updateBookQuery = "UPDATE books SET quantity = quantity + 1, status = 'Available' WHERE book_id = @bookId";
                    using (MySqlCommand cmd = new MySqlCommand(updateBookQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBooks();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Function to Mark Overdue Books as "Not Returning"
        private void CheckOverdueBooks()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string overdueQuery = @"
                UPDATE borrowed_books 
                SET status = 'Not Returning' 
                WHERE return_date IS NULL AND DATEDIFF(NOW(), borrow_date) > 5";

                    using (MySqlCommand cmd = new MySqlCommand(overdueQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    string updateBookStatusQuery = @"
                UPDATE books 
                SET status = 'Missing' 
                WHERE book_id IN (SELECT book_id FROM borrowed_books WHERE status = 'Not Returning')";

                    using (MySqlCommand cmd = new MySqlCommand(updateBookStatusQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking overdue books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Call CheckOverdueBooks() on Form Load or a Timer every 24 hours
        private void UserSide_Load(object sender, EventArgs e)
        {
            CheckOverdueBooks();
        }


        private void LOG_OUT_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            this.Hide();
            loginform.ShowDialog();
            this.Show();
        }

        // Search Books (Live Search as User Types)
        private void searchfield_TextChanged(object sender, EventArgs e)
        {
            SearchBooks(searchfield.Text);
        }

        // Search Books (When Search Button is Clicked)
        private void search_Click(object sender, EventArgs e)
        {
            SearchBooks(searchfield.Text);
        }

        // Function to Search Books
        private void SearchBooks(string keyword)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM books WHERE book_name LIKE @keyword OR author LIKE @keyword OR category LIKE @keyword OR status LIKE @keyword";

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
                MessageBox.Show("Error searching books: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void WelcomeText_Click(object sender, EventArgs e)
        {

        }

        private void UsernameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
