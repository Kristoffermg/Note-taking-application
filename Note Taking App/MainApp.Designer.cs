namespace Note_Taking_App
{
    partial class MainApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
            this.NoteInput = new System.Windows.Forms.RichTextBox();
            this.AddNoteBtn = new System.Windows.Forms.Button();
            this.HeaderNotes = new System.Windows.Forms.DataGridView();
            this.addNoteTitle = new System.Windows.Forms.TextBox();
            this.ChildNotes = new System.Windows.Forms.DataGridView();
            this.backToHeaderBtn = new System.Windows.Forms.Button();
            this.resetdatabase = new System.Windows.Forms.Button();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.openedNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChildNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // NoteInput
            // 
            this.NoteInput.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoteInput.Location = new System.Drawing.Point(281, 47);
            this.NoteInput.Name = "NoteInput";
            this.NoteInput.Size = new System.Drawing.Size(1042, 506);
            this.NoteInput.TabIndex = 1;
            this.NoteInput.Text = "";
            this.NoteInput.Visible = false;
            this.NoteInput.TextChanged += new System.EventHandler(this.NoteInput_TextChanged);
            this.NoteInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoteInput_KeyDown);
            // 
            // AddNoteBtn
            // 
            this.AddNoteBtn.Location = new System.Drawing.Point(159, 541);
            this.AddNoteBtn.Name = "AddNoteBtn";
            this.AddNoteBtn.Size = new System.Drawing.Size(84, 23);
            this.AddNoteBtn.TabIndex = 3;
            this.AddNoteBtn.Text = "Add";
            this.AddNoteBtn.UseVisualStyleBackColor = true;
            this.AddNoteBtn.Click += new System.EventHandler(this.AddNote_Click);
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
            this.HeaderNotes.Location = new System.Drawing.Point(15, 39);
            this.HeaderNotes.Name = "HeaderNotes";
            this.HeaderNotes.RowHeadersVisible = false;
            this.HeaderNotes.Size = new System.Drawing.Size(228, 496);
            this.HeaderNotes.TabIndex = 4;
            this.HeaderNotes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.HeaderNotes_CellContentDoubleClick);
            this.HeaderNotes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.HeaderNotes_CellValueChanged);
            // 
            // addNoteTitle
            // 
            this.addNoteTitle.Location = new System.Drawing.Point(15, 544);
            this.addNoteTitle.Name = "addNoteTitle";
            this.addNoteTitle.Size = new System.Drawing.Size(138, 20);
            this.addNoteTitle.TabIndex = 5;
            this.addNoteTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addNoteTitle_KeyDown);
            // 
            // ChildNotes
            // 
            this.ChildNotes.AllowUserToAddRows = false;
            this.ChildNotes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ChildNotes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ChildNotes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ChildNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChildNotes.CausesValidation = false;
            this.ChildNotes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ChildNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChildNotes.ColumnHeadersVisible = false;
            this.ChildNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ChildNotes.DefaultCellStyle = dataGridViewCellStyle2;
            this.ChildNotes.GridColor = System.Drawing.SystemColors.Control;
            this.ChildNotes.Location = new System.Drawing.Point(15, 47);
            this.ChildNotes.MultiSelect = false;
            this.ChildNotes.Name = "ChildNotes";
            this.ChildNotes.RowHeadersVisible = false;
            this.ChildNotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ChildNotes.Size = new System.Drawing.Size(240, 488);
            this.ChildNotes.TabIndex = 7;
            this.ChildNotes.Visible = false;
            this.ChildNotes.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChildNotes_CellEnter);
            this.ChildNotes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ChildNotes_CellValueChanged);
            // 
            // backToHeaderBtn
            // 
            this.backToHeaderBtn.Enabled = false;
            this.backToHeaderBtn.Location = new System.Drawing.Point(15, 6);
            this.backToHeaderBtn.Name = "backToHeaderBtn";
            this.backToHeaderBtn.Size = new System.Drawing.Size(228, 20);
            this.backToHeaderBtn.TabIndex = 8;
            this.backToHeaderBtn.Text = "Back";
            this.backToHeaderBtn.UseVisualStyleBackColor = true;
            this.backToHeaderBtn.Click += new System.EventHandler(this.backToHeaderBtn_Click);
            // 
            // resetdatabase
            // 
            this.resetdatabase.ForeColor = System.Drawing.Color.Red;
            this.resetdatabase.Location = new System.Drawing.Point(1167, 19);
            this.resetdatabase.Name = "resetdatabase";
            this.resetdatabase.Size = new System.Drawing.Size(75, 23);
            this.resetdatabase.TabIndex = 9;
            this.resetdatabase.Text = "Reset DB";
            this.resetdatabase.UseVisualStyleBackColor = true;
            this.resetdatabase.Visible = false;
            this.resetdatabase.Click += new System.EventHandler(this.resetdatabase_Click);
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(1248, 18);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(75, 23);
            this.settingsBtn.TabIndex = 10;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Turquoise;
            this.topPanel.Location = new System.Drawing.Point(-5, -7);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1347, 14);
            this.topPanel.TabIndex = 11;
            // 
            // openedNote
            // 
            this.openedNote.AutoSize = true;
            this.openedNote.Location = new System.Drawing.Point(288, 10);
            this.openedNote.Name = "openedNote";
            this.openedNote.Size = new System.Drawing.Size(33, 13);
            this.openedNote.TabIndex = 12;
            this.openedNote.Text = "None";
            this.openedNote.Visible = false;
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 573);
            this.Controls.Add(this.openedNote);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.resetdatabase);
            this.Controls.Add(this.backToHeaderBtn);
            this.Controls.Add(this.ChildNotes);
            this.Controls.Add(this.addNoteTitle);
            this.Controls.Add(this.HeaderNotes);
            this.Controls.Add(this.AddNoteBtn);
            this.Controls.Add(this.NoteInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainApp";
            this.Text = "Note App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainApp_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChildNotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox NoteInput;
        private System.Windows.Forms.Button AddNoteBtn;
        private System.Windows.Forms.DataGridView HeaderNotes;
        private System.Windows.Forms.TextBox addNoteTitle;
        private System.Windows.Forms.DataGridView ChildNotes;
        private System.Windows.Forms.Button backToHeaderBtn;
        private System.Windows.Forms.Button resetdatabase;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label openedNote;
    }
}

