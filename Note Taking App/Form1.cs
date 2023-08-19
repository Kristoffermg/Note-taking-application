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
        int currentHeaderNoteSelected = 1;
        int currentChildNoteSelected = 0;
        Dictionary<int, string> allChildNotes = new Dictionary<int, string>();
        //Dictionary<int, string> allChildNotes = new Dictionary<int, string>();
        DataTable headerNotesMenu = new DataTable();
        IDataAccess dataAccess = new DataAccess();
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //GetAllChildNotes();

            headerNotesMenu.Columns.Add("Title");

            IDataAccess dataAccess = new DataAccess();
            string query = "SELECT id, title FROM HeaderNotes";
            List<HeaderNotes> headerNotes = await dataAccess.LoadData<HeaderNotes, dynamic>(query, new { }, connectionString);

            foreach (HeaderNotes headerNote in headerNotes)
            {
                headerNotesMenu.Rows.Add(headerNote.title);
            }

            HeaderNotes.DataSource = headerNotesMenu;
        }

        //private async void GetAllChildNotes()
        //{
        //    string query = "SELECT headerID, content from ChildNotes";
        //    List<ChildNotes> childNotes = await dataAccess.LoadData<ChildNotes, dynamic>(query, new { }, connectionString);

        //    foreach(ChildNotes childNote in childNotes)
        //    {
        //        allChildNotes.Add(childNote.headerID, childNote.content);
        //    }
        //}

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
                    headerNotesMenu.Rows.Add(addNoteTitle.Text);

                    query = $"SELECT MAX(id) AS value FROM HeaderNotes";
                    int headerID = dataAccess.LoadSingularDataValue(query, connectionString);

                    query = $"INSERT INTO ChildNotes (headerID, title, content, orderid) VALUES({headerID}, 'New Note', '', 0)"; // TODO: change orderid value
                    dataAccess.InsertData<ChildNotes, dynamic>(query, new { }, connectionString);

                }
                else { 
                    query = $"INSERT INTO ChildNotes (headerID, title, content, orderid) VALUES({currentHeaderNoteSelected}, 'New Note', '', 0)"; // TODO: change orderid value
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
            string query = $"UPDATE ChildNotes SET content='{NoteInput.Text}' WHERE headerID={currentHeaderNoteSelected} AND orderid={currentChildNoteSelected}";
            dataAccess.UpdateData<dynamic>(query, new { }, connectionString);

            // TODO: also add integration for when you switch to another note so it always saves
        }

        private async void HeaderNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentHeaderNoteSelected = e.RowIndex + 1;

            string query = $"SELECT * FROM ChildNotes WHERE headerID = {currentHeaderNoteSelected}";
            List<ChildNotes> currentChildNotes = await dataAccess.LoadData<ChildNotes, dynamic>(query, new { }, connectionString);

            headerNotesAreDisplayed = false;
            HeaderNotes.Visible = false;
            ChildNotes.Visible = true;
            backToHeaderBtn.Enabled = true;
            NoteInput.Visible = true;
            DisplayChildNotes(currentChildNotes);
        }

        private void DisplayChildNotes(List<ChildNotes> currentChildNotes)
        {
            DataTable childNotesMenu = new DataTable();
            childNotesMenu.Columns.Add("Title");
            foreach (ChildNotes childNote in currentChildNotes)
            {
                childNotesMenu.Rows.Add(childNote.title);
                allChildNotes.Add(childNote.orderid, childNote.content);
            }

            ChildNotes.DataSource = childNotesMenu;
            NoteInput.Text = allChildNotes[currentChildNoteSelected];
        }

        private void ChildNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentChildNoteSelected = e.RowIndex;
            DisplayChildNoteContent();
        }

        private void DisplayChildNoteContent()
        {
            NoteInput.Text = allChildNotes[currentChildNoteSelected];
        }

        private void NoteInput_KeyDown_1(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control && e.KeyCode == Keys.S)
            {
                SaveCurrentNote();
            }
        }

        private void backToHeaderBtn_Click(object sender, EventArgs e)
        {
            headerNotesAreDisplayed = true;
            HeaderNotes.Visible = true;
            ChildNotes.Visible = false;
            backToHeaderBtn.Enabled = false;
            NoteInput.Visible = false;
            NoteInput.Clear();
            allChildNotes.Clear();
        }
    }
}