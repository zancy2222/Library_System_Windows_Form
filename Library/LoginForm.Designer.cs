namespace Library
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.login = new System.Windows.Forms.Button();
            this.Signup = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.TextBox();
            this.Passfield = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-91, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(463, 301);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.Location = new System.Drawing.Point(26, 494);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(123, 32);
            this.login.TabIndex = 3;
            this.login.Text = "LOGIN";
            this.login.UseVisualStyleBackColor = false;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // Signup
            // 
            this.Signup.BackColor = System.Drawing.Color.LightGreen;
            this.Signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup.Location = new System.Drawing.Point(208, 494);
            this.Signup.Name = "Signup";
            this.Signup.Size = new System.Drawing.Size(123, 32);
            this.Signup.TabIndex = 4;
            this.Signup.Text = "SIGN UP";
            this.Signup.UseVisualStyleBackColor = false;
            this.Signup.Click += new System.EventHandler(this.Signup_Click);
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(26, 360);
            this.Username.Multiline = true;
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(305, 26);
            this.Username.TabIndex = 5;
            this.Username.Text = "Enter Username";
            this.Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // Passfield
            // 
            this.Passfield.Location = new System.Drawing.Point(26, 421);
            this.Passfield.Name = "Passfield";
            this.Passfield.Size = new System.Drawing.Size(305, 20);
            this.Passfield.TabIndex = 6;
            this.Passfield.UseSystemPasswordChar = true;
            this.Passfield.TextChanged += new System.EventHandler(this.Passfield_TextChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 582);
            this.Controls.Add(this.Passfield);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.Signup);
            this.Controls.Add(this.login);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button Signup;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Passfield;
    }
}

