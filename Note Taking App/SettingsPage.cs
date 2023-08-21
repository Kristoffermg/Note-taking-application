using Note_Taking_App.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Note_Taking_App.SqlData;


namespace Note_Taking_App
{
    public partial class SettingsPage : Form
    {
        IDataAccess dataAccess = new DataAccess();
        public SettingsPage()
        {
            InitializeComponent();

            LoadPreviousSettings();
            fontDropdown.SelectedItem = "Segoe UI";
        }

        private async void LoadPreviousSettings()
        {
            string query = "SELECT * FROM Settings";
            List<Settings> settingsList = await dataAccess.LoadDataAsync<Settings, dynamic>(query, new { });
            Settings settings = settingsList.FirstOrDefault();
            if(settings == null)
            {
                MessageBox.Show("An error happened (No settings values found in DB");
                return;
            }
            fontDropdown.SelectedItem = settings.FontStyle;
            fontSizeNumeric.Value = settings.FontSize;
            ThemeDropdown.SelectedItem = settings.Theme;

        }

        private void applySettingsBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
