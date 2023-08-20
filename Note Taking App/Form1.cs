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
using Note_Taking_App.SqlData;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Note_Taking_App
{
    public partial class Form1 : Form
    {
        const int MAX_TITLE_CHARACTER_LENGTH = 25;

        string connectionString = "Server=krishusdata.mysql.database.azure.com;Port=3306;database=NoteTakingApp;user id=kmg;password=krissupersecretpassword0!;Allow User Variables=True";
        bool headerNotesAreDisplayed = true;
        bool childNotesMenuDisplayed = false;
        int latestHeaderNoteId = 0;
        int currentHeaderNoteSelected = 1;
        int currentChildNoteSelected = 1;
        Dictionary<int, string> allChildNotes = new Dictionary<int, string>();
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
            string query = "SELECT id, title FROM HeaderNotes;";
            List<HeaderNotes> headerNotes = await dataAccess.LoadDataAsync<HeaderNotes, dynamic>(query, new { }, connectionString);

            foreach (HeaderNotes headerNote in headerNotes)
            {
                headerNotesMenu.Rows.Add(headerNote.title);
            }

            HeaderNotes.DataSource = headerNotesMenu;
            latestHeaderNoteId = headerNotesMenu.Rows.Count;
        }

        private async void GetSettings()
        {
            string query = "SELECT * FROM Settings"; 
            List<Settings> settings = await dataAccess.LoadDataAsync<Settings, dynamic>(query, new { }, connectionString);


        }

        public void ChangeFormLayout(string fontStyle, int fontSize, string theme)
        {

        }

        private async void AddNote_Click(object sender, EventArgs e)
        {
            if (addNoteTitle.Text.Length <= MAX_TITLE_CHARACTER_LENGTH)
            {
                string query = "";
                if (headerNotesAreDisplayed)
                {
                    headerNotesMenu.Rows.Add(addNoteTitle.Text);
                    latestHeaderNoteId++;

                    query = "INSERT INTO HeaderNotes (title, orderid) VALUES(@title, @orderid);";
                    await dataAccess.InsertData(query, new { title = addNoteTitle.Text, orderid = GetMaxOrderId(true) + 1}, connectionString);

                    // the code below is for inserting a "New Note" automatically when you create a new header note. Will probably get deleted.
                    //query = $"INSERT INTO ChildNotes (headerID, title, content, orderid) VALUES({headerID}, 'New Note', '', {GetMaxOrderId(false, headerID) + 1})"; 
                    //await dataAccess.InsertData<ChildNotes, dynamic>(query, new { }, connectionString);

                }
                else {
                    int nextChildOrderId = GetMaxOrderId(false) + 1;
                    childNotesMenu.Rows.Add(addNoteTitle.Text);
                    try
                    {
                        allChildNotes.Add(nextChildOrderId, "");
                        NoteInput.Visible = true;

                        query = "INSERT INTO ChildNotes (headerID, title, content, orderid) VALUES(@headerID, @title, @content, @orderid);"; // TODO: change orderid value
                        await dataAccess.InsertData(query, new { headerID = currentChildNoteSelected, title = addNoteTitle.Text, content = "", orderid = nextChildOrderId }, connectionString);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("You're adding notes too quickly!");
                    }
                }
            }
        }

        private int GetMaxOrderId(bool wantHeaderNoteOrderId)
        {
            int orderid = 1;
            if(wantHeaderNoteOrderId)
            {
                orderid = Convert.ToInt32(dataAccess.LoadSingularDataValue($"SELECT MAX(orderid) AS value FROM HeaderNotes", new { }, connectionString));
            }
            else
            {
                orderid = Convert.ToInt32(dataAccess.LoadSingularDataValue($"SELECT MAX(orderid) AS value FROM ChildNotes WHERE headerID=@headerID", new {headerID = currentHeaderNoteSelected}, connectionString));
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

        private void SaveCurrentNote()
        {
            string query = $"UPDATE ChildNotes SET content=@content WHERE headerID=@headerID AND orderid=@orderid";
            dataAccess.UpdateData<dynamic>(query, new { content = NoteInput.Text, headerID = currentHeaderNoteSelected, orderid = currentChildNoteSelected }, connectionString);

            allChildNotes[currentChildNoteSelected] = NoteInput.Text;

            // TODO: also add integration for when you switch to another note so it always saves
        }

        private void DisplayChildNotes(List<ChildNotes> currentChildNotes)
        {
            if(childNotesMenu.Columns.Count == 0) childNotesMenu.Columns.Add("Title");
            foreach (ChildNotes childNote in currentChildNotes)
            {
                childNotesMenu.Rows.Add(childNote.title);
                allChildNotes.Add(childNote.orderid, childNote.content);
            }
            ChildNotes.DataSource = childNotesMenu;

            if(allChildNotes.Count >= 1)
                NoteInput.Text = allChildNotes[currentChildNoteSelected];

            childNotesMenuDisplayed = true;
        }

        private async void HeaderNotes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            currentHeaderNoteSelected = e.RowIndex + 1;

            string query = $"SELECT * FROM ChildNotes WHERE headerID = @headerID";
            List<ChildNotes> currentChildNotes = await dataAccess.LoadDataAsync<ChildNotes, dynamic>(query, new { headerID = currentHeaderNoteSelected }, connectionString);

            headerNotesAreDisplayed = false;
            HeaderNotes.Visible = false;
            ChildNotes.Visible = true;
            backToHeaderBtn.Enabled = true;
            if (currentChildNotes.Count >= 1) NoteInput.Visible = true;
            DisplayChildNotes(currentChildNotes);
        }

        private void ChildNotes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (childNotesMenuDisplayed == false || allChildNotes.Count == 0) return;
            currentChildNoteSelected = e.RowIndex + 1;
            DisplayChildNoteContent();
        }

        private void DisplayChildNoteContent()
        {
            var test1 = allChildNotes;
            int test2 = currentChildNoteSelected;
            NoteInput.Text = allChildNotes[currentChildNoteSelected];
        }

        private void backToHeaderBtn_Click(object sender, EventArgs e)
        {
            headerNotesAreDisplayed = true;
            HeaderNotes.Visible = true;
            ChildNotes.Visible = false;
            backToHeaderBtn.Enabled = false;
            NoteInput.Visible = false;
            childNotesMenuDisplayed = false;
            currentChildNoteSelected = 1;
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            CheckForKeyInput(sender, e);
        }

        private void NoteInput_KeyDown(object sender, KeyEventArgs e)
        {
            CheckForKeyInput(sender, e);
        }

        private void CheckForKeyInput(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control && e.KeyCode == Keys.S && childNotesMenuDisplayed)
            {
                SaveCurrentNote();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (childNotesMenuDisplayed)
                    backToHeaderBtn_Click(sender, e);
            }
        }

        private void ChildNotes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string newCellName = (string)childNotesMenu.Rows[e.RowIndex].ItemArray[0]; 
            ChangeCellName(newCellName, false, 0);
        }

        private void HeaderNotes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string newCellName = (string)headerNotesMenu.Rows[e.RowIndex].ItemArray[0];
            int cellID = e.RowIndex + 1;
            ChangeCellName(newCellName, true, cellID);
        }

        private void ChangeCellName(string newCellName, bool isHeaderNoteCell, int cellID)
        {
            int id = isHeaderNoteCell ? cellID : currentHeaderNoteSelected;
            string query = isHeaderNoteCell ? "UPDATE HeaderNotes SET title='{newCellName}' WHERE id=@id"
                                            : "UPDATE ChildNotes SET title='{newCellName}' WHERE id=@id";
            dataAccess.UpdateData<dynamic>(query, new { id = id }, connectionString);
        }
    }
}