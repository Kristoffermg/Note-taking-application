using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Taking_App.SqlData
{
    public class HeaderNotes
    {
        public string title;
        public int orderid;

        // This parameterless constructor is necessary for Dapper to materialize HeaderNotes with LoadData() calls
        public HeaderNotes()
        {

        }

        public HeaderNotes(string title, int orderid)
        {
            this.title = title;
            this.orderid = orderid;
        }
    }
}
