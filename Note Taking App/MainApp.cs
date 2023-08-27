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
    public partial class MainApp : Form
    {
        const int MAX_TITLE_CHARACTER_LENGTH = 25;

        bool headerNotesAreDisplayed = true;
        bool childNotesMenuDisplayed = false;
        int latestHeaderNoteId = 0;
        int currentHeaderNoteSelected = 1;
        int currentChildNoteSelected = 1;
        Dictionary<int, string> allChildNotes = new Dictionary<int, string>();
        DataTable headerNotesMenu = new DataTable();
        DataTable childNotesMenu = new DataTable();
        IDataAccess dataAccess = new DataAccess();

        public MainApp()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //GetAllChildNotes();

            headerNotesMenu.Columns.Add("Title");

            //Settings settings = await GetSettings();
            //ChangeFormLayout(settings.Theme, settings.FontStyle, settings.FontSize);
            //Program._MainApp.Height = settings.AppSizeY;
            //Program._MainApp.Width = settings.AppSizeX;

            IDataAccess dataAccess = new DataAccess();
            string query = "SELECT id, title FROM HeaderNotes;";
            List<HeaderNotes> headerNotes = await dataAccess.LoadDataAsync<HeaderNotes, dynamic>(query, new { });

            foreach (HeaderNotes headerNote in headerNotes)
            {
                headerNotesMenu.Rows.Add(headerNote.title);
            }

            HeaderNotes.DataSource = headerNotesMenu;
            latestHeaderNoteId = headerNotesMenu.Rows.Count;
        }

        private async Task<Settings> GetSettings()
        {
            string query = "SELECT * FROM Settings"; 
            List<Settings> settings = await dataAccess.LoadDataAsync<Settings, dynamic>(query, new { });

            return settings.FirstOrDefault();
        }

        public void ChangeFormLayout(string theme, string fontStyle, int fontSize)
        {
            Font menuFont = new Font(fontStyle, 18);
            Font inputFont = new Font(fontStyle, 8);
            Font noteFont = new Font(fontStyle, fontSize);
            Font buttonFont = new Font(fontStyle, 8);

            HeaderNotes.Font = menuFont;
            ChildNotes.Font = menuFont;
            addNoteTitle.Font = inputFont;
            NoteInput.Font = noteFont;
            backToHeaderBtn.Font = buttonFont;
            openedNote.Font = menuFont;

            if (theme == "Dark")
                ChangeToDarkTheme();
            else if (theme == "Bright")
                ChangeToBrightTheme();
        }

        #region Themes
        private void ChangeToDarkTheme()
        {
            Color dark = Color.FromArgb(40, 43, 48);
            Color front = Color.FromArgb(92, 103, 132);
            Color selectedBackColor = Color.FromArgb(92, 94, 104);
            Color cellForeColor = Color.FromArgb(176, 179, 184);
            Color textInputColor = Color.FromArgb(66, 69, 73);

            Color dark1 = Color.FromArgb(66, 69, 73);
            Color dark2 = Color.FromArgb(54, 57, 62);
            Color dark3 = Color.FromArgb(40, 43, 48);
            Color dark4 = Color.FromArgb(30, 33, 36);

            BackColor = dark3;
            HeaderNotes.BackgroundColor = dark2;
            ChildNotes.BackgroundColor = dark2;
            HeaderNotes.GridColor = dark2;
            ChildNotes.GridColor = dark2;
            HeaderNotes.DefaultCellStyle.BackColor = dark2;
            ChildNotes.DefaultCellStyle.BackColor = dark2;
            HeaderNotes.DefaultCellStyle.ForeColor = cellForeColor;
            ChildNotes.DefaultCellStyle.ForeColor = cellForeColor;
            HeaderNotes.DefaultCellStyle.SelectionBackColor = selectedBackColor;
            ChildNotes.DefaultCellStyle.SelectionBackColor = selectedBackColor;
            HeaderNotes.DefaultCellStyle.SelectionForeColor = Color.White;
            ChildNotes.DefaultCellStyle.SelectionForeColor = Color.White;
            NoteInput.BackColor = textInputColor;
            NoteInput.ForeColor = Color.White;
            NoteInput.BorderStyle = BorderStyle.None; 
            addNoteTitle.BackColor = dark;
            addNoteTitle.ForeColor = front;
            topPanel.BackColor = Color.FromArgb(30, 33, 36);
            backToHeaderBtn.BackColor = dark1;
            backToHeaderBtn.ForeColor = Color.White;
            backToHeaderBtn.FlatStyle = FlatStyle.Flat;
            backToHeaderBtn.FlatAppearance.BorderColor = dark1;
            backToHeaderBtn.AutoSize = true;
            AddNoteBtn.BackColor = dark1;
            AddNoteBtn.ForeColor = Color.White;
            AddNoteBtn.FlatStyle = FlatStyle.Flat;
            AddNoteBtn.FlatAppearance.BorderColor = dark1;
            AddNoteBtn.AutoSize = true;
            settingsBtn.BackColor = dark1;
            settingsBtn.ForeColor = Color.White;
            settingsBtn.FlatStyle = FlatStyle.Flat;
            settingsBtn.FlatAppearance.BorderColor = dark1;
            settingsBtn.AutoSize = true;
            addNoteTitle.BackColor = dark1;
            addNoteTitle.ForeColor = Color.White;
            openedNote.ForeColor = Color.White;
        }


        private void ChangeToBrightTheme()
        {
            BackColor = SystemColors.Control;
            HeaderNotes.BackgroundColor = SystemColors.Control;
            ChildNotes.BackgroundColor = SystemColors.Control;
            HeaderNotes.GridColor = SystemColors.Control;
            ChildNotes.GridColor = SystemColors.Control;
            HeaderNotes.DefaultCellStyle.BackColor = SystemColors.Control;
            ChildNotes.DefaultCellStyle.BackColor = SystemColors.Control;
            HeaderNotes.DefaultCellStyle.ForeColor = SystemColors.ControlDarkDark;
            ChildNotes.DefaultCellStyle.ForeColor = SystemColors.ControlDarkDark;
            HeaderNotes.DefaultCellStyle.SelectionBackColor = SystemColors.ControlLightLight;
            ChildNotes.DefaultCellStyle.SelectionBackColor = SystemColors.ControlLightLight;
            HeaderNotes.DefaultCellStyle.SelectionForeColor = SystemColors.ControlDarkDark;
            ChildNotes.DefaultCellStyle.SelectionForeColor = SystemColors.ControlDarkDark;
            NoteInput.BackColor = SystemColors.Window;
            NoteInput.ForeColor = Color.Black;
            NoteInput.BorderStyle = BorderStyle.None;
            addNoteTitle.BackColor = SystemColors.Window;
            addNoteTitle.ForeColor = SystemColors.WindowText;
            topPanel.BackColor = Color.FromArgb(30, 33, 36);
            backToHeaderBtn.BackColor = Color.White;
            backToHeaderBtn.ForeColor = SystemColors.ControlText;
            backToHeaderBtn.FlatStyle = FlatStyle.Flat;
            backToHeaderBtn.FlatAppearance.BorderColor = SystemColors.Control;
            backToHeaderBtn.AutoSize = true;
            AddNoteBtn.BackColor = Color.White;
            AddNoteBtn.ForeColor = SystemColors.ControlText;
            AddNoteBtn.FlatStyle = FlatStyle.Flat;
            AddNoteBtn.FlatAppearance.BorderColor = SystemColors.Control;
            AddNoteBtn.AutoSize = true;
            settingsBtn.BackColor = Color.White;
            settingsBtn.ForeColor = SystemColors.ControlText;
            settingsBtn.FlatStyle = FlatStyle.Flat;
            settingsBtn.FlatAppearance.BorderColor = SystemColors.Control;
            settingsBtn.AutoSize = true;
            openedNote.ForeColor = SystemColors.ControlText;
        }
        #endregion

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            SettingsPage settingsPage = new SettingsPage();
            settingsPage.Show();
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
                    await dataAccess.InsertData(query, new { title = addNoteTitle.Text, orderid = GetMaxOrderId(true) + 1});

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
                        await dataAccess.InsertData(query, new { headerID = currentHeaderNoteSelected, title = addNoteTitle.Text, content = "", orderid = nextChildOrderId });
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
                orderid = Convert.ToInt32(dataAccess.LoadSingularDataValue($"SELECT MAX(orderid) AS value FROM HeaderNotes", new { }));
            }
            else
            {
                orderid = Convert.ToInt32(dataAccess.LoadSingularDataValue($"SELECT MAX(orderid) AS value FROM ChildNotes WHERE headerID=@headerID", new {headerID = currentHeaderNoteSelected}));
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveCurrentNote();
        }

        private void SaveCurrentNote()
        {
            string query = $"UPDATE ChildNotes SET content=@content WHERE headerID=@headerID AND orderid=@orderid";
            dataAccess.UpdateData<dynamic>(query, new { content = NoteInput.Text, headerID = currentHeaderNoteSelected, orderid = currentChildNoteSelected });

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

            string query = $"SELECT * FROM ChildNotes WHERE headerID = @headerID;";
            List<ChildNotes> currentChildNotes = await dataAccess.LoadDataAsync<ChildNotes, dynamic>(query, new { headerID = currentHeaderNoteSelected });

            headerNotesAreDisplayed = false;
            HeaderNotes.Visible = false;
            ChildNotes.Visible = true;
            backToHeaderBtn.Enabled = true;
            openedNote.Text = headerNotesMenu.Rows[e.RowIndex]["Title"].ToString();
            openedNote.Visible = true;
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

            query = "DELETE FROM ChildNotes;";
            dataAccess.UpdateData<dynamic>(query, new { });

            query = "DELETE FROM HeaderNotes;";
            dataAccess.UpdateData<dynamic>(query, new { });

            query = "ALTER TABLE HeaderNotes AUTO_INCREMENT = 1;";
            dataAccess.UpdateData<dynamic>(query, new { });

            query = "ALTER TABLE ChildNotes AUTO_INCREMENT = 1;";
            dataAccess.UpdateData<dynamic>(query, new { });
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
            string query = isHeaderNoteCell ? "UPDATE HeaderNotes SET title='{newCellName}' WHERE id=@id;"
                                            : "UPDATE ChildNotes SET title='{newCellName}' WHERE id=@id;";
            dataAccess.UpdateData<dynamic>(query, new { id = id });
        }

        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            string query = "UPDATE Settings SET AppSizeX = @AppSizeX, AppSizeY = @AppSizeY;";
            dataAccess.UpdateData<dynamic>(query, new { AppSizeX = this.Width, AppSizeY = this.Height });

            if(NoteInput.Text != String.Empty)
            {
                query = "UPDATE ChildNotes SET content=@content WHERE headerID=@headerID AND orderid=@orderid";
                dataAccess.UpdateData<dynamic>(query, new { content = NoteInput.Text, headerID = currentHeaderNoteSelected, orderid = currentChildNoteSelected });
            }
        }

        private void NoteInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}