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
        int latestHeaderNoteId = 0;
        int currentHeaderNoteSelected = 1;
        int currentChildNoteSelected = 1;
        Dictionary<int, string> allChildNotes = new Dictionary<int, string>();
        //Dictionary<int, string> allChildNotes = new Dictionary<int, string>();
        DataTable headerNotesMenu = new DataTable();
        DataTable childNotesMenu = new DataTable();
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

            query = "SELECT MAX(id) FROM HeaderNotes";

            latestHeaderNoteId = headerNotesMenu.Rows.Count;
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

        private async void AddNote_Click(object sender, EventArgs e)
        {
            if (addNoteTitle.Text.Length <= MAX_TITLE_CHARACTER_LENGTH)
            {
                string query = "";
                if (headerNotesAreDisplayed)
                {
                    headerNotesMenu.Rows.Add(addNoteTitle.Text);
                    latestHeaderNoteId++;
                    query = $"INSERT INTO HeaderNotes (title, orderid) VALUES('{addNoteTitle.Text}', {GetMaxOrderId(true) + 1})";
                    await dataAccess.InsertData<HeaderNotes, dynamic>(query, new { }, connectionString);

                    // the code below is for inserting a "New Note" automatically when you create a new header note. Will probably get deleted.
                    //query = $"INSERT INTO ChildNotes (headerID, title, content, orderid) VALUES({headerID}, 'New Note', '', {GetMaxOrderId(false, headerID) + 1})"; 
                    //await dataAccess.InsertData<ChildNotes, dynamic>(query, new { }, connectionString);

                }
                else {
                    int nextChildOrderId = GetMaxOrderId(false) + 1;
                    childNotesMenu.Rows.Add(addNoteTitle.Text);
                    allChildNotes.Add(nextChildOrderId, "");
                    query = $"INSERT INTO ChildNotes (headerID, title, content, orderid) VALUES({currentHeaderNoteSelected}, '{addNoteTitle.Text}', '', {nextChildOrderId})"; // TODO: change orderid value
                    await dataAccess.InsertData<ChildNotes, dynamic>(query, new { }, connectionString);
                }
            }
        }

        private int GetMaxOrderId(bool wantHeaderNoteOrderId)
        {
            int orderid = 1;
            if(wantHeaderNoteOrderId)
            {
                orderid = Convert.ToInt32(dataAccess.LoadSingularDataValue($"SELECT MAX(orderid) AS value FROM HeaderNotes", connectionString));
            }
            else
            {
                orderid = Convert.ToInt32(dataAccess.LoadSingularDataValue($"SELECT MAX(orderid) AS value FROM ChildNotes WHERE headerID={currentHeaderNoteSelected}", connectionString));
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
            if(currentChildNotes.Count >= 1) NoteInput.Visible = true;
            DisplayChildNotes(currentChildNotes);
        }

        private void DisplayChildNotes(List<ChildNotes> currentChildNotes)
        {
            if(childNotesMenu.Columns.Count == 0) childNotesMenu.Columns.Add("Title");
            foreach (ChildNotes childNote in currentChildNotes)
            {
                childNotesMenu.Rows.Add(childNote.title);
                allChildNotes.Add(childNote.orderid, childNote.content);
            }
            var test = allChildNotes;
            ChildNotes.DataSource = childNotesMenu;
            if(allChildNotes.Count >= 1)
                NoteInput.Text = allChildNotes[currentChildNoteSelected];
        }

        private void ChildNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentChildNoteSelected = e.RowIndex + 1;
            DisplayChildNoteContent();
        }

        private void DisplayChildNoteContent()
        {
            NoteInput.Text = allChildNotes[currentChildNoteSelected];
        }

        private void DisplayChildNoteSelection()
        {

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
            childNotesMenu.Clear();
        }

        private void resetdatabase_Click(object sender, EventArgs e)
        {
            string query = "";

            query = "DELETE FROM ChildNotes";
            dataAccess.UpdateData<dynamic>(query, new { }, connectionString);

            query = "DELETE FROM HeaderNotes";
            dataAccess.UpdateData<dynamic>(query, new { }, connectionString);

            query = "ALTER TABLE HeaderNotes AUTO_INCREMENT = 1";
            dataAccess.UpdateData<dynamic>(query, new { }, connectionString);

            query = "ALTER TABLE ChildNotes AUTO_INCREMENT = 1";
            dataAccess.UpdateData<dynamic>(query, new { }, connectionString);
        }
    }
}