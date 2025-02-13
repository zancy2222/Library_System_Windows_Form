namespace Library
{
    partial class BookEntryForm
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
            this.bookNameTextBox = new System.Windows.Forms.TextBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.datePublishedPicker = new System.Windows.Forms.DateTimePicker();
            this.statusDropdown = new System.Windows.Forms.ComboBox();
            this.insertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bookNameTextBox
            // 
            this.bookNameTextBox.Location = new System.Drawing.Point(23, 23);
            this.bookNameTextBox.Name = "bookNameTextBox";
            this.bookNameTextBox.Size = new System.Drawing.Size(154, 20);
            this.bookNameTextBox.TabIndex = 0;
            this.bookNameTextBox.Text = "Book name";
            // 
            // authorTextBox
            // 
            this.authorTextBox.Location = new System.Drawing.Point(23, 73);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(154, 20);
            this.authorTextBox.TabIndex = 1;
            this.authorTextBox.Text = "Author";
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(23, 127);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(154, 20);
            this.categoryTextBox.TabIndex = 2;
            this.categoryTextBox.Text = "Category";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(23, 184);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(154, 20);
            this.quantityTextBox.TabIndex = 3;
            this.quantityTextBox.Text = "Quantity";
            // 
            // datePublishedPicker
            // 
            this.datePublishedPicker.Location = new System.Drawing.Point(23, 255);
            this.datePublishedPicker.MaxDate = new System.DateTime(2029, 12, 25, 23, 59, 59, 0);
            this.datePublishedPicker.Name = "datePublishedPicker";
            this.datePublishedPicker.Size = new System.Drawing.Size(154, 20);
            this.datePublishedPicker.TabIndex = 5;
            // 
            // statusDropdown
            // 
            this.statusDropdown.FormattingEnabled = true;
            this.statusDropdown.Items.AddRange(new object[] {
            "Available",
            "Borrowed",
            "Damaged",
            "Missing"});
            this.statusDropdown.Location = new System.Drawing.Point(23, 316);
            this.statusDropdown.Name = "statusDropdown";
            this.statusDropdown.Size = new System.Drawing.Size(154, 21);
            this.statusDropdown.TabIndex = 6;
            this.statusDropdown.Text = "Select Status";
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(23, 392);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(154, 34);
            this.insertButton.TabIndex = 7;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // BookEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 450);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.statusDropdown);
            this.Controls.Add(this.datePublishedPicker);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.authorTextBox);
            this.Controls.Add(this.bookNameTextBox);
            this.Name = "BookEntryForm";
            this.Text = "BookEntryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bookNameTextBox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.DateTimePicker datePublishedPicker;
        private System.Windows.Forms.ComboBox statusDropdown;
        private System.Windows.Forms.Button insertButton;
    }
}