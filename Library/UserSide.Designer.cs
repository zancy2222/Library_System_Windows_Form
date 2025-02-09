namespace Library
{
    partial class UserSide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSide));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.search = new System.Windows.Forms.Button();
            this.searchfield = new System.Windows.Forms.TextBox();
            this.Borrow = new System.Windows.Forms.Button();
            this.RETURN = new System.Windows.Forms.Button();
            this.LOG_OUT = new System.Windows.Forms.Button();
            this.WelcomeText = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.UsernameLabel);
            this.panel1.Controls.Add(this.WelcomeText);
            this.panel1.Controls.Add(this.LOG_OUT);
            this.panel1.Controls.Add(this.RETURN);
            this.panel1.Controls.Add(this.Borrow);
            this.panel1.Controls.Add(this.search);
            this.panel1.Controls.Add(this.searchfield);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(121, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 477);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(181, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(620, 354);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(726, 64);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 8;
            this.search.Text = "SEARCH";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // searchfield
            // 
            this.searchfield.Location = new System.Drawing.Point(587, 67);
            this.searchfield.Name = "searchfield";
            this.searchfield.Size = new System.Drawing.Size(126, 20);
            this.searchfield.TabIndex = 7;
            this.searchfield.TextChanged += new System.EventHandler(this.searchfield_TextChanged);
            // 
            // Borrow
            // 
            this.Borrow.Location = new System.Drawing.Point(15, 105);
            this.Borrow.Name = "Borrow";
            this.Borrow.Size = new System.Drawing.Size(160, 39);
            this.Borrow.TabIndex = 9;
            this.Borrow.Text = "BORROW";
            this.Borrow.UseVisualStyleBackColor = true;
            this.Borrow.Click += new System.EventHandler(this.Borrow_Click);
            // 
            // RETURN
            // 
            this.RETURN.Location = new System.Drawing.Point(15, 184);
            this.RETURN.Name = "RETURN";
            this.RETURN.Size = new System.Drawing.Size(160, 39);
            this.RETURN.TabIndex = 10;
            this.RETURN.Text = "RETURN";
            this.RETURN.UseVisualStyleBackColor = true;
            this.RETURN.Click += new System.EventHandler(this.RETURN_Click);
            // 
            // LOG_OUT
            // 
            this.LOG_OUT.Location = new System.Drawing.Point(15, 420);
            this.LOG_OUT.Name = "LOG_OUT";
            this.LOG_OUT.Size = new System.Drawing.Size(160, 39);
            this.LOG_OUT.TabIndex = 11;
            this.LOG_OUT.Text = "LOG OUT";
            this.LOG_OUT.UseVisualStyleBackColor = true;
            this.LOG_OUT.Click += new System.EventHandler(this.LOG_OUT_Click);
            // 
            // WelcomeText
            // 
            this.WelcomeText.AutoSize = true;
            this.WelcomeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeText.Location = new System.Drawing.Point(12, 14);
            this.WelcomeText.Name = "WelcomeText";
            this.WelcomeText.Size = new System.Drawing.Size(203, 20);
            this.WelcomeText.TabIndex = 12;
            this.WelcomeText.Text = "WELCOME TO SYSTEM";
            this.WelcomeText.Click += new System.EventHandler(this.WelcomeText_Click);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(221, 14);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(0, 20);
            this.UsernameLabel.TabIndex = 13;
            this.UsernameLabel.Click += new System.EventHandler(this.UsernameLabel_Click);
            // 
            // UserSide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1048, 622);
            this.Controls.Add(this.panel1);
            this.Name = "UserSide";
            this.Text = "UserSide";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button LOG_OUT;
        private System.Windows.Forms.Button RETURN;
        private System.Windows.Forms.Button Borrow;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox searchfield;
        private System.Windows.Forms.Label WelcomeText;
        private System.Windows.Forms.Label UsernameLabel;
    }
}