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
            this.NoteInput = new System.Windows.Forms.RichTextBox();
            this.AddNote = new System.Windows.Forms.Button();
            this.HeaderNotes = new System.Windows.Forms.DataGridView();
            this.addNoteTitle = new System.Windows.Forms.TextBox();
            this.SortBy = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // NoteInput
            // 
            this.NoteInput.Location = new System.Drawing.Point(281, 47);
            this.NoteInput.Name = "NoteInput";
            this.NoteInput.Size = new System.Drawing.Size(736, 542);
            this.NoteInput.TabIndex = 1;
            this.NoteInput.Text = "";
            // 
            // AddNote
            // 
            this.AddNote.Location = new System.Drawing.Point(156, 595);
            this.AddNote.Name = "AddNote";
            this.AddNote.Size = new System.Drawing.Size(96, 23);
            this.AddNote.TabIndex = 3;
            this.AddNote.Text = "+";
            this.AddNote.UseVisualStyleBackColor = true;
            this.AddNote.Click += new System.EventHandler(this.AddNote_Click);
            // 
            // HeaderNotes
            // 
            this.HeaderNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HeaderNotes.ColumnHeadersVisible = false;
            this.HeaderNotes.GridColor = System.Drawing.SystemColors.Control;
            this.HeaderNotes.Location = new System.Drawing.Point(12, 47);
            this.HeaderNotes.Name = "HeaderNotes";
            this.HeaderNotes.RowHeadersVisible = false;
            this.HeaderNotes.Size = new System.Drawing.Size(240, 542);
            this.HeaderNotes.TabIndex = 4;
            // 
            // addNoteTitle
            // 
            this.addNoteTitle.Location = new System.Drawing.Point(12, 598);
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
            this.SortBy.Location = new System.Drawing.Point(59, 12);
            this.SortBy.Name = "SortBy";
            this.SortBy.Size = new System.Drawing.Size(121, 21);
            this.SortBy.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 645);
            this.Controls.Add(this.SortBy);
            this.Controls.Add(this.addNoteTitle);
            this.Controls.Add(this.HeaderNotes);
            this.Controls.Add(this.AddNote);
            this.Controls.Add(this.NoteInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderNotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox NoteInput;
        private System.Windows.Forms.Button AddNote;
        private System.Windows.Forms.DataGridView HeaderNotes;
        private System.Windows.Forms.TextBox addNoteTitle;
        private System.Windows.Forms.ComboBox SortBy;
    }
}

