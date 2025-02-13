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

            // Admin Login
            if (username == "admin" && password == "admin")
            {
                AdminSide adminForm = new AdminSide();
                this.Hide();
                adminForm.ShowDialog();
                this.Show();
                return;
            }

            // Librarian Login
            if (username == "Librarian" && password == "Librarian")
            {
                UserSide librarianForm = new UserSide();
                this.Hide();
                librarianForm.ShowDialog();
                this.Show();
                return;
            }

            // Invalid Credentials
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
