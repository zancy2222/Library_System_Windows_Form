namespace Library
{
    partial class ViewUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.search = new System.Windows.Forms.Button();
            this.searchfield = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.View_users = new System.Windows.Forms.Button();
            this.View_reports = new System.Windows.Forms.Button();
            this.Add_Books = new System.Windows.Forms.Button();
            this.LOGOUT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(796, 43);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 13;
            this.search.Text = "SEARCH";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // searchfield
            // 
            this.searchfield.Location = new System.Drawing.Point(657, 46);
            this.searchfield.Name = "searchfield";
            this.searchfield.Size = new System.Drawing.Size(126, 20);
            this.searchfield.TabIndex = 12;
            this.searchfield.TextChanged += new System.EventHandler(this.searchfield_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(228, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 353);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(744, 471);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(127, 54);
            this.Delete.TabIndex = 10;
            this.Delete.Text = "DELETE";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.YellowGreen;
            this.panel1.Controls.Add(this.View_users);
            this.panel1.Controls.Add(this.View_reports);
            this.panel1.Controls.Add(this.Add_Books);
            this.panel1.Controls.Add(this.LOGOUT);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 687);
            this.panel1.TabIndex = 7;
            // 
            // View_users
            // 
            this.View_users.BackColor = System.Drawing.Color.LemonChiffon;
            this.View_users.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View_users.Location = new System.Drawing.Point(25, 298);
            this.View_users.Name = "View_users";
            this.View_users.Size = new System.Drawing.Size(156, 38);
            this.View_users.TabIndex = 5;
            this.View_users.Text = "VIEW ALL USERS";
            this.View_users.UseVisualStyleBackColor = false;
            this.View_users.Click += new System.EventHandler(this.View_users_Click);
            // 
            // View_reports
            // 
            this.View_reports.BackColor = System.Drawing.Color.LemonChiffon;
            this.View_reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View_reports.Location = new System.Drawing.Point(25, 208);
            this.View_reports.Name = "View_reports";
            this.View_reports.Size = new System.Drawing.Size(156, 38);
            this.View_reports.TabIndex = 4;
            this.View_reports.Text = "VIEW REPORTS";
            this.View_reports.UseVisualStyleBackColor = false;
            this.View_reports.Click += new System.EventHandler(this.View_reports_Click);
            // 
            // Add_Books
            // 
            this.Add_Books.BackColor = System.Drawing.Color.LemonChiffon;
            this.Add_Books.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_Books.Location = new System.Drawing.Point(25, 119);
            this.Add_Books.Name = "Add_Books";
            this.Add_Books.Size = new System.Drawing.Size(156, 38);
            this.Add_Books.TabIndex = 2;
            this.Add_Books.Text = "ADD BOOKS";
            this.Add_Books.UseVisualStyleBackColor = false;
            this.Add_Books.Click += new System.EventHandler(this.Add_Books_Click);
            // 
            // LOGOUT
            // 
            this.LOGOUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.LOGOUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOGOUT.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LOGOUT.Location = new System.Drawing.Point(25, 559);
            this.LOGOUT.Name = "LOGOUT";
            this.LOGOUT.Size = new System.Drawing.Size(156, 61);
            this.LOGOUT.TabIndex = 1;
            this.LOGOUT.Text = "LOG OUT";
            this.LOGOUT.UseVisualStyleBackColor = false;
            this.LOGOUT.Click += new System.EventHandler(this.LOGOUT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "WELCOME ADMIN";
            // 
            // ViewUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 685);
            this.Controls.Add(this.search);
            this.Controls.Add(this.searchfield);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.panel1);
            this.Name = "ViewUsers";
            this.Text = "ViewUsers";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox searchfield;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button View_users;
        private System.Windows.Forms.Button View_reports;
        private System.Windows.Forms.Button Add_Books;
        private System.Windows.Forms.Button LOGOUT;
        private System.Windows.Forms.Label label1;
    }
}