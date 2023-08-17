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
        const int MAX_TITLE_CHARACTER_LENGTH = 25;

        string connectionString = "Server=krishusdata.mysql.database.azure.com;Port=3306;database=NoteTakingApp;user id=kmg;password=krissupersecretpassword0!";
        bool headerNotesAreDisplayed = true;
        int currentHeaderNoteSelected = 0;
        Dictionary<int, string> allChildNotes = new Dictionary<int, string>();
        DataTable notes = new DataTable();
        IDataAccess dataAccess = new DataAccess();
        public Form1()
        {
            // TODO: form the allChildNotes dictionary
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            GetAllChildNotes();

            notes.Columns.Add("Title");

            IDataAccess dataAccess = new DataAccess();
            string query = "SELECT id, title FROM HeaderNotes";
            List<HeaderNotes> headerNotes = await dataAccess.LoadData<HeaderNotes, dynamic>(query, new { }, connectionString);

            foreach (HeaderNotes headerNote in headerNotes)
            {
                notes.Rows.Add(headerNote.title);
            }

            HeaderNotes.DataSource = notes;
        }

        private async void GetAllChildNotes()
        {
            string query = "SELECT headerID, content from ChildNotes";
            List<ChildNotes> childNotes = await dataAccess.LoadData<ChildNotes, dynamic>(query, new { }, connectionString);

            foreach(ChildNotes childNote in childNotes)
            {
                allChildNotes.Add(childNote.headerID, childNote.content);
            }
        }

        private void AddNote_Click(object sender, EventArgs e)
        {
            if (addNoteTitle.Text.Length <= MAX_TITLE_CHARACTER_LENGTH)
            {
                string query = "";
                int orderid = GetOrderId();
                if (headerNotesAreDisplayed)
                {
                    query = $"INSERT INTO HeaderNotes (title, orderid) VALUES('{addNoteTitle.Text}', {orderid + 1})";
                    dataAccess.InsertData<HeaderNotes, dynamic>(query, new { }, connectionString);
                    notes.Rows.Add(addNoteTitle.Text);

                    query = $"SELECT MAX(id) AS value FROM HeaderNotes";
                    int headerID = dataAccess.LoadSingularDataValue(query, connectionString);

                    query = $"INSERT INTO ChildNotes (headerID, title, content, orderid) VALUES({headerID}, 'New Note', '', {headerID})"; // TODO: change orderid value
                    dataAccess.InsertData<HeaderNotes, dynamic>(query, new { }, connectionString);

                    // TODO: store the new data in the allChildNotes dictionary
                }
                else
                {
                    dataAccess.InsertData<ChildNotes, dynamic>(query, new { }, connectionString);
                }
            }
        }

        private int GetOrderId()
        {
            int orderid = 1;
            if(headerNotesAreDisplayed)
            {
                orderid = dataAccess.LoadSingularDataValue("SELECT MAX(orderid) AS value FROM HeaderNotes", connectionString);
            }
            else
            {
                orderid = dataAccess.LoadSingularDataValue("SELECT MAX(orderid) AS value FROM ChildNotes", connectionString);
            }
            return orderid;
        }

        private void addNoteTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && addNoteTitle.Text != string.Empty)
            {
                AddNote_Click(sender, e);
                addNoteTitle.Clear();
                e.SuppressKeyPress = true;
            }
        }


        private void SortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSortBy = SortBy.Text;
            switch(selectedSortBy)
            {
                case "Custom":
                    break;
                case "Alphabetically":
                    break;
            }
        }

        private void HeaderNotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int test = e.RowIndex;

            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveCurrentNote();
        }

        private void NoteInput_KeyDown(object sender, KeyEventArgs e)
        {
            if((ModifierKeys & Keys.Control) == Keys.Control && e.KeyCode == Keys.S)
            {
                SaveCurrentNote();
            }
        }

        private void SaveCurrentNote()
        {
            // TODO: also add integration for when you switch to another note so it always saves
        }
    }
}