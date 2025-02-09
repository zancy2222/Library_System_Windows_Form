using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library
{
    public partial class AdminSide : Form
    {
        private string connectionString = "server=localhost;database=libsys;user=root;password=;";

        public AdminSide()
        {
            InitializeComponent();
            LoadBooks(); // Load books on form open

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

        // Load Books into DataGridView
        private void LoadBooks()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
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

        // Insert Book
        private void Insert_Click(object sender, EventArgs e)
        {
            string bookName = Prompt.ShowDialog("Enter Book Name:", "Insert Book");
            string author = Prompt.ShowDialog("Enter Author:", "Insert Book");
            string category = Prompt.ShowDialog("Enter Category:", "Insert Book");
            string quantityInput = Prompt.ShowDialog("Enter Quantity (Number of Copies):", "Insert Book");

            if (string.IsNullOrWhiteSpace(bookName) || string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(quantityInput))
            {
                MessageBox.Show("All fields are required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(quantityInput, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Invalid quantity! Please enter a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 250;
                prompt.Text = "Select Date and Status";

                DateTimePicker datePicker = new DateTimePicker() { Left = 50, Top = 20, Width = 300, Format = DateTimePickerFormat.Short };
                ComboBox statusDropdown = new ComboBox() { Left = 50, Top = 60, Width = 300 };
                statusDropdown.Items.AddRange(new string[] { "Borrowed", "Available", "Damaged", "Missing" });
                statusDropdown.SelectedIndex = 1; // Default: Available

                Button confirmButton = new Button() { Text = "OK", Left = 150, Width = 100, Top = 100 };
                confirmButton.Click += (s, ev) => { prompt.Close(); };

                prompt.Controls.Add(datePicker);
                prompt.Controls.Add(statusDropdown);
                prompt.Controls.Add(confirmButton);
                prompt.ShowDialog();

                string datePublished = datePicker.Value.ToString("yyyy-MM-dd");
                string status = statusDropdown.SelectedItem.ToString();

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO books (book_name, author, date_published, category, status, quantity) VALUES (@bookName, @author, @datePublished, @category, @status, @quantity)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@bookName", bookName);
                            cmd.Parameters.AddWithValue("@author", author);
                            cmd.Parameters.AddWithValue("@datePublished", datePublished);
                            cmd.Parameters.AddWithValue("@category", category);
                            cmd.Parameters.AddWithValue("@status", status);
                            cmd.Parameters.AddWithValue("@quantity", quantity);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Book inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBooks();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Update Selected Book
        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a book to update!", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["book_id"].Value);
            string newBookName = Prompt.ShowDialog("Enter new Book Name:", "Update Book");
            string newAuthor = Prompt.ShowDialog("Enter new Author:", "Update Book");
            string newCategory = Prompt.ShowDialog("Enter new Category:", "Update Book");
            string newQuantityInput = Prompt.ShowDialog("Enter new Quantity (Number of Copies):", "Update Book");

            if (!int.TryParse(newQuantityInput, out int newQuantity) || newQuantity <= 0)
            {
                MessageBox.Show("Invalid quantity! Please enter a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 250;
                prompt.Text = "Select Date and Status";

                DateTimePicker datePicker = new DateTimePicker() { Left = 50, Top = 20, Width = 300, Format = DateTimePickerFormat.Short };
                ComboBox statusDropdown = new ComboBox() { Left = 50, Top = 60, Width = 300 };
                statusDropdown.Items.AddRange(new string[] { "Borrowed", "Available", "Damaged", "Missing" });
                statusDropdown.SelectedIndex = 1;

                Button confirmButton = new Button() { Text = "OK", Left = 150, Width = 100, Top = 100 };
                confirmButton.Click += (s, ev) => { prompt.Close(); };

                prompt.Controls.Add(datePicker);
                prompt.Controls.Add(statusDropdown);
                prompt.Controls.Add(confirmButton);
                prompt.ShowDialog();

                string newDatePublished = datePicker.Value.ToString("yyyy-MM-dd");
                string newStatus = statusDropdown.SelectedItem.ToString();

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "UPDATE books SET book_name=@bookName, author=@author, date_published=@datePublished, category=@category, status=@status, quantity=@quantity WHERE book_id=@bookId";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@bookId", bookId);
                            cmd.Parameters.AddWithValue("@bookName", newBookName);
                            cmd.Parameters.AddWithValue("@author", newAuthor);
                            cmd.Parameters.AddWithValue("@datePublished", newDatePublished);
                            cmd.Parameters.AddWithValue("@category", newCategory);
                            cmd.Parameters.AddWithValue("@status", newStatus);
                            cmd.Parameters.AddWithValue("@quantity", newQuantity);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBooks();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a book to delete!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["book_id"].Value);
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM books WHERE book_id=@bookId";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@bookId", bookId);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBooks(); // Refresh data
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Helper class for simple input dialogs with improved design
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 450,
                    Height = 220,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    StartPosition = FormStartPosition.CenterScreen,
                    Text = caption
                };

                Label textLabel = new Label()
                {
                    Left = 20,
                    Top = 20,
                    Width = 400,
                    Text = text,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };

                TextBox inputBox = new TextBox()
                {
                    Left = 20,
                    Top = 60,
                    Width = 380,
                    Font = new Font("Arial", 10)
                };

                Button confirmation = new Button()
                {
                    Text = "OK",
                    Left = 150,
                    Width = 120,
                    Height = 35,
                    Top = 110,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };

                confirmation.Click += (sender, e) => { prompt.Close(); };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);

                prompt.AcceptButton = confirmation;
                prompt.ShowDialog();

                return inputBox.Text;
            }

            // Dialog for Date Picker and Status Dropdown
            public static (string, string) ShowDateAndStatusDialog()
            {
                Form prompt = new Form()
                {
                    Width = 450,
                    Height = 260,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    StartPosition = FormStartPosition.CenterScreen,
                    Text = "Select Date and Status"
                };

 
                DateTimePicker datePicker = new DateTimePicker()
                {
                    Left = 20,
                    Top = 50,
                    Width = 380,
                    Format = DateTimePickerFormat.Short
                };

  
                ComboBox statusDropdown = new ComboBox()
                {
                    Left = 20,
                    Top = 120,
                    Width = 380
                };
                statusDropdown.Items.AddRange(new string[] { "Borrowed", "Available", "Damaged", "Missing" });
                statusDropdown.SelectedIndex = 1;

                Button confirmButton = new Button()
                {
                    Text = "OK",
                    Left = 150,
                    Width = 120,
                    Height = 35,
                    Top = 170,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };

                confirmButton.Click += (s, ev) => { prompt.Close(); };

                 prompt.Controls.Add(datePicker);
                 prompt.Controls.Add(statusDropdown);
                prompt.Controls.Add(confirmButton);

                prompt.AcceptButton = confirmButton;
                prompt.ShowDialog();

                return (datePicker.Value.ToString("yyyy-MM-dd"), statusDropdown.SelectedItem.ToString());
            }
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
    }
}
