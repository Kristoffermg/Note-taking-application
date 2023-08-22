using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Note_Taking_App.SqlData;
using Note_Taking_App.SQL;

namespace Note_Taking_App
{
    internal static class Program
    {

        public static MainApp _MainApp;
        public static IDataAccess dataAccess = new DataAccess();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string query = "SELECT * FROM Settings;";
            Settings settings = dataAccess.LoadData<Settings, dynamic>(query, new { }).FirstOrDefault();

            _MainApp = new MainApp();
            _MainApp.Width = settings.AppSizeX;
            _MainApp.Height = settings.AppSizeY;

            _MainApp.ChangeFormLayout(settings.Theme, settings.FontStyle, settings.FontSize);

            Application.Run(_MainApp);
        }
    }
}
