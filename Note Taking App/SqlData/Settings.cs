using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Taking_App.SqlData
{
    public class Settings
    {
        public string Theme;
        public string FontStyle;
        public int FontSize;
        public int AppSizeX;
        public int AppSizeY;

        public Settings(string theme, string fontStyle, int fontSize, int appSizeX, int appSizeY)
        {
            Theme = theme;
            FontStyle = fontStyle;
            FontSize = fontSize;
            AppSizeX = appSizeX;
            AppSizeY = appSizeY;
        }

        public Settings(int appSizeX, int appSizeY)
        {
            AppSizeX = appSizeX;
            AppSizeY = appSizeY;
        }
    }
}
