using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Note_Taking_App.SQL;
using Note_Taking_App.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Note_Taking_App
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=krishusdata.mysql.database.azure.com;Port=3306;database=NoteTakingApp;user id=kmg;password=krissupersecretpassword0!";
        bool headerNotesAreDisplayed = true;
        DataTable notes = new DataTable();
        public Form1()
        {
            // form DataTables for the notes
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");

            IDataAccess dataAccess = new DataAccess();
            string query = "SELECT id, title FROM HeaderNotes";
            List<HeaderNotes> headerNotes = await dataAccess.LoadData<HeaderNotes, dynamic>(query, new { }, connectionString);
            
            foreach(HeaderNotes headerNote in headerNotes)
            {
                notes.Rows.Add(headerNote.title);
            }

            HeaderNotes.DataSource = notes;
        }

        private void AddNote_Click(object sender, EventArgs e)
        {
            IDataAccess dataAccess = new DataAccess();
            string query = "";
            if (headerNotesAreDisplayed)
            {
                query = $"INSERT INTO HeaderNotes (title) VALUES('{addNoteTitle.Text}')";
                dataAccess.InsertData<HeaderNotes, dynamic>(query, new { }, connectionString);
                notes.Rows.Add(addNoteTitle.Text);
            }
            else
            {
                dataAccess.InsertData<ChildNotes, dynamic>(query, new { }, connectionString);
            }
        }

        private void addNoteTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && addNoteTitle.Text != string.Empty)
            {
                AddNote_Click(sender, e);
                addNoteTitle.Clear();
                e.SuppressKeyPress = true;
            }
        }
    }
}
