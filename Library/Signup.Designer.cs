namespace Library
{
    partial class Signup
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
            this.Fullnamefield = new System.Windows.Forms.TextBox();
            this.Emailfield = new System.Windows.Forms.TextBox();
            this.UsernameField = new System.Windows.Forms.TextBox();
            this.Numberfield = new System.Windows.Forms.TextBox();
            this.Addressfield = new System.Windows.Forms.TextBox();
            this.PassField = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.CANCEL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Fullnamefield
            // 
            this.Fullnamefield.Location = new System.Drawing.Point(21, 73);
            this.Fullnamefield.Name = "Fullnamefield";
            this.Fullnamefield.Size = new System.Drawing.Size(182, 20);
            this.Fullnamefield.TabIndex = 0;
            this.Fullnamefield.Text = "Enter Full name";
            this.Fullnamefield.TextChanged += new System.EventHandler(this.Fullnamefield_TextChanged);
            // 
            // Emailfield
            // 
            this.Emailfield.Location = new System.Drawing.Point(21, 128);
            this.Emailfield.Name = "Emailfield";
            this.Emailfield.Size = new System.Drawing.Size(181, 20);
            this.Emailfield.TabIndex = 1;
            this.Emailfield.Text = "Enter Email";
            this.Emailfield.TextChanged += new System.EventHandler(this.Emailfield_TextChanged);
            // 
            // UsernameField
            // 
            this.UsernameField.Location = new System.Drawing.Point(21, 193);
            this.UsernameField.Name = "UsernameField";
            this.UsernameField.Size = new System.Drawing.Size(181, 20);
            this.UsernameField.TabIndex = 2;
            this.UsernameField.Text = "Enter Username";
            this.UsernameField.TextChanged += new System.EventHandler(this.UsernameField_TextChanged);
            // 
            // Numberfield
            // 
            this.Numberfield.Location = new System.Drawing.Point(291, 73);
            this.Numberfield.Name = "Numberfield";
            this.Numberfield.Size = new System.Drawing.Size(181, 20);
            this.Numberfield.TabIndex = 3;
            this.Numberfield.Text = "Enter Contact number";
            this.Numberfield.TextChanged += new System.EventHandler(this.Numberfield_TextChanged);
            // 
            // Addressfield
            // 
            this.Addressfield.Location = new System.Drawing.Point(291, 128);
            this.Addressfield.Name = "Addressfield";
            this.Addressfield.Size = new System.Drawing.Size(181, 20);
            this.Addressfield.TabIndex = 4;
            this.Addressfield.Text = "Enter Address";
            this.Addressfield.TextChanged += new System.EventHandler(this.Addressfield_TextChanged);
            // 
            // PassField
            // 
            this.PassField.Location = new System.Drawing.Point(291, 194);
            this.PassField.Name = "PassField";
            this.PassField.Size = new System.Drawing.Size(181, 20);
            this.PassField.TabIndex = 5;
            this.PassField.Text = "Enter Password";
            this.PassField.UseSystemPasswordChar = true;
            this.PassField.TextChanged += new System.EventHandler(this.PassField_TextChanged);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.PaleGreen;
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(369, 285);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(102, 23);
            this.Save.TabIndex = 6;
            this.Save.Text = "SAVE";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // CANCEL
            // 
            this.CANCEL.BackColor = System.Drawing.Color.Crimson;
            this.CANCEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CANCEL.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CANCEL.Location = new System.Drawing.Point(21, 285);
            this.CANCEL.Name = "CANCEL";
            this.CANCEL.Size = new System.Drawing.Size(102, 23);
            this.CANCEL.TabIndex = 7;
            this.CANCEL.Text = "CANCEL";
            this.CANCEL.UseVisualStyleBackColor = false;
            this.CANCEL.Click += new System.EventHandler(this.CANCEL_Click);
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 339);
            this.Controls.Add(this.CANCEL);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.PassField);
            this.Controls.Add(this.Addressfield);
            this.Controls.Add(this.Numberfield);
            this.Controls.Add(this.UsernameField);
            this.Controls.Add(this.Emailfield);
            this.Controls.Add(this.Fullnamefield);
            this.Name = "Signup";
            this.Text = "Signup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Fullnamefield;
        private System.Windows.Forms.TextBox Emailfield;
        private System.Windows.Forms.TextBox UsernameField;
        private System.Windows.Forms.TextBox Numberfield;
        private System.Windows.Forms.TextBox Addressfield;
        private System.Windows.Forms.TextBox PassField;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button CANCEL;
    }
}