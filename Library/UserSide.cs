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

        public UserSide()
        {
            InitializeComponent();
           

            // Display the logged-in username
            UsernameLabel.Text = "Librarian";
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
        private string ShowInputDialog(string title, string prompt)
        {
            Form promptForm = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = prompt, Width = 350 };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 350 };
            Button confirmButton = new Button() { Text = "OK", Left = 150, Width = 100, Top = 90, DialogResult = DialogResult.OK };

            confirmButton.Click += (sender, e) => { promptForm.Close(); };

            promptForm.Controls.Add(textLabel);
            promptForm.Controls.Add(inputBox);
            promptForm.Controls.Add(confirmButton);
            promptForm.AcceptButton = confirmButton;

            return promptForm.ShowDialog() == DialogResult.OK ? inputBox.Text : string.Empty;
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

            if (quantity <= 0 || status == "Missing" || status == "Damaged" || status == "Borrowed")
            {
                MessageBox.Show("This book is unavailable for borrowing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Use custom InputBox function to get borrower name
            string borrowerName = ShowInputDialog("Borrow Book", "Enter Student name:");

            if (string.IsNullOrWhiteSpace(borrowerName))
            {
                MessageBox.Show("Borrower name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string borrowQuery = "INSERT INTO borrowed_books (borrower_name, book_id, borrow_date) VALUES (@borrowerName, @bookId, NOW())";
                    using (MySqlCommand cmd = new MySqlCommand(borrowQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@borrowerName", borrowerName);
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.ExecuteNonQuery();
                    }

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

            // Use custom InputBox function to get borrower name
            string borrowerName = ShowInputDialog("Return Book", "Enter Student name:");

            if (string.IsNullOrWhiteSpace(borrowerName))
            {
                MessageBox.Show("Borrower name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string checkQuery = "SELECT COUNT(*) FROM borrowed_books WHERE book_id = @bookId AND borrower_name = @borrowerName AND return_date IS NULL";
                    using (MySqlCommand cmd = new MySqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.Parameters.AddWithValue("@borrowerName", borrowerName);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count == 0)
                        {
                            MessageBox.Show("No matching borrowed book found for this name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string returnQuery = "UPDATE borrowed_books SET return_date = NOW(), status = 'Returned' WHERE book_id = @bookId AND borrower_name = @borrowerName AND return_date IS NULL";
                    using (MySqlCommand cmd = new MySqlCommand(returnQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.Parameters.AddWithValue("@borrowerName", borrowerName);
                        cmd.ExecuteNonQuery();
                    }

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
