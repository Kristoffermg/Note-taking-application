namespace Note_Taking_App
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NoteInput = new System.Windows.Forms.RichTextBox();
            this.AddNote = new System.Windows.Forms.Button();
            this.HeaderNotes = new System.Windows.Forms.DataGridView();
            this.addNoteTitle = new System.Windows.Forms.TextBox();
            this.SortBy = new System.Windows.Forms.ComboBox();
            this.ChildNotes = new System.Windows.Forms.DataGridView();
            this.backToHeaderBtn = new System.Windows.Forms.Button();
            this.resetdatabase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChildNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // NoteInput
            // 
            this.NoteInput.Location = new System.Drawing.Point(281, 47);
            this.NoteInput.Name = "NoteInput";
            this.NoteInput.Size = new System.Drawing.Size(736, 542);
            this.NoteInput.TabIndex = 1;
            this.NoteInput.Text = "";
            this.NoteInput.Visible = false;
            this.NoteInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoteInput_KeyDown_1);
            // 
            // AddNote
            // 
            this.AddNote.Location = new System.Drawing.Point(156, 585);
            this.AddNote.Name = "AddNote";
            this.AddNote.Size = new System.Drawing.Size(96, 23);
            this.AddNote.TabIndex = 3;
            this.AddNote.Text = "+";
            this.AddNote.UseVisualStyleBackColor = true;
            this.AddNote.Click += new System.EventHandler(this.AddNote_Click);
            // 
            // HeaderNotes
            // 
            this.HeaderNotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.HeaderNotes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.HeaderNotes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.HeaderNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HeaderNotes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.HeaderNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HeaderNotes.ColumnHeadersVisible = false;
            this.HeaderNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.HeaderNotes.DefaultCellStyle = dataGridViewCellStyle1;
            this.HeaderNotes.GridColor = System.Drawing.SystemColors.Control;
            this.HeaderNotes.Location = new System.Drawing.Point(0, 39);
            this.HeaderNotes.Name = "HeaderNotes";
            this.HeaderNotes.RowHeadersVisible = false;
            this.HeaderNotes.Size = new System.Drawing.Size(240, 542);
            this.HeaderNotes.TabIndex = 4;
            this.HeaderNotes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.HeaderNotes_CellContentClick);
            // 
            // addNoteTitle
            // 
            this.addNoteTitle.Location = new System.Drawing.Point(12, 587);
            this.addNoteTitle.Name = "addNoteTitle";
            this.addNoteTitle.Size = new System.Drawing.Size(138, 20);
            this.addNoteTitle.TabIndex = 5;
            this.addNoteTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addNoteTitle_KeyDown);
            // 
            // SortBy
            // 
            this.SortBy.FormattingEnabled = true;
            this.SortBy.Items.AddRange(new object[] {
            "Custom",
            "Alphabetically"});
            this.SortBy.Location = new System.Drawing.Point(15, 12);
            this.SortBy.Name = "SortBy";
            this.SortBy.Size = new System.Drawing.Size(121, 21);
            this.SortBy.TabIndex = 6;
            // 
            // ChildNotes
            // 
            this.ChildNotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ChildNotes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ChildNotes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ChildNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChildNotes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ChildNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChildNotes.ColumnHeadersVisible = false;
            this.ChildNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ChildNotes.DefaultCellStyle = dataGridViewCellStyle2;
            this.ChildNotes.GridColor = System.Drawing.SystemColors.Control;
            this.ChildNotes.Location = new System.Drawing.Point(3, 37);
            this.ChildNotes.Name = "ChildNotes";
            this.ChildNotes.RowHeadersVisible = false;
            this.ChildNotes.Size = new System.Drawing.Size(240, 542);
            this.ChildNotes.TabIndex = 7;
            this.ChildNotes.Visible = false;
            this.ChildNotes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChildNotes_CellContentClick);
            // 
            // backToHeaderBtn
            // 
            this.backToHeaderBtn.Enabled = false;
            this.backToHeaderBtn.Location = new System.Drawing.Point(168, 13);
            this.backToHeaderBtn.Name = "backToHeaderBtn";
            this.backToHeaderBtn.Size = new System.Drawing.Size(75, 23);
            this.backToHeaderBtn.TabIndex = 8;
            this.backToHeaderBtn.Text = "<-";
            this.backToHeaderBtn.UseVisualStyleBackColor = true;
            this.backToHeaderBtn.Click += new System.EventHandler(this.backToHeaderBtn_Click);
            // 
            // resetdatabase
            // 
            this.resetdatabase.ForeColor = System.Drawing.Color.Red;
            this.resetdatabase.Location = new System.Drawing.Point(339, 9);
            this.resetdatabase.Name = "resetdatabase";
            this.resetdatabase.Size = new System.Drawing.Size(75, 23);
            this.resetdatabase.TabIndex = 9;
            this.resetdatabase.Text = "Reset DB";
            this.resetdatabase.UseVisualStyleBackColor = true;
            this.resetdatabase.Click += new System.EventHandler(this.resetdatabase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 645);
            this.Controls.Add(this.resetdatabase);
            this.Controls.Add(this.backToHeaderBtn);
            this.Controls.Add(this.ChildNotes);
            this.Controls.Add(this.SortBy);
            this.Controls.Add(this.addNoteTitle);
            this.Controls.Add(this.HeaderNotes);
            this.Controls.Add(this.AddNote);
            this.Controls.Add(this.NoteInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChildNotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox NoteInput;
        private System.Windows.Forms.Button AddNote;
        private System.Windows.Forms.DataGridView HeaderNotes;
        private System.Windows.Forms.TextBox addNoteTitle;
        private System.Windows.Forms.ComboBox SortBy;
        private System.Windows.Forms.DataGridView ChildNotes;
        private System.Windows.Forms.Button backToHeaderBtn;
        private System.Windows.Forms.Button resetdatabase;
    }
}

