using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Reports : Form
    {
        private string connectionString = "server=localhost;database=libsys;user=root;password=;";
        public Reports()
        {
            InitializeComponent();
            LoadReports();

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

        private void LOGOUT_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            this.Hide();
            loginform.ShowDialog();
            this.Show();
        }
        private void LoadReports()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
            SELECT 
                bb.borrower_name AS 'Borrower Name', 
                b.book_name AS 'Book Title', 
                bb.status AS 'Status', 
                bb.borrow_date AS 'Borrowed Date', 
                bb.return_date AS 'Return Date'
            FROM borrowed_books bb
            JOIN books b ON bb.book_id = b.book_id
            ORDER BY bb.borrow_date DESC";

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
                MessageBox.Show("Error loading reports: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void searchfield_TextChanged(object sender, EventArgs e)
        {
            SearchReports(searchfield.Text);
        }

        private void search_Click(object sender, EventArgs e)
        {
            SearchReports(searchfield.Text);
        }

        private void SearchReports(string keyword)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
            SELECT 
                bb.borrower_name AS 'Borrower Name', 
                b.book_name AS 'Book Title', 
                bb.status AS 'Status', 
                bb.borrow_date AS 'Borrowed Date', 
                bb.return_date AS 'Return Date'
            FROM borrowed_books bb
            JOIN books b ON bb.book_id = b.book_id
            WHERE 
                bb.borrower_name LIKE @keyword OR 
                b.book_name LIKE @keyword OR 
                bb.status LIKE @keyword
            ORDER BY bb.borrow_date DESC";

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
                MessageBox.Show("Error searching reports: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Download_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No data available to export!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV Files (*.csv)|*.csv";
                    sfd.FileName = "Reports.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(sfd.FileName))
                        {
                            // Write column headers
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                writer.Write(dataGridView1.Columns[i].HeaderText);
                                if (i < dataGridView1.Columns.Count - 1)
                                    writer.Write(",");
                            }
                            writer.WriteLine();

                            // Write row data
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                                {
                                    writer.Write(row.Cells[i].Value?.ToString());
                                    if (i < dataGridView1.Columns.Count - 1)
                                        writer.Write(",");
                                }
                                writer.WriteLine();
                            }
                        }

                        MessageBox.Show("Data successfully exported!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
