using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Taking_App.SqlData
{
    public class ChildNotes
    {
        public int id;
        public int headerID;
        public string title;
        public string content;
        public int orderid;

        // This parameterless constructor is necessary for Dapper to materialize HeaderNotes with LoadData() calls
        public ChildNotes()
        {

        }

        public ChildNotes(int headerID, string title, string content, int orderid)
        {
            this.headerID = headerID;
            this.title = title;
            this.content = content;
            this.orderid = orderid;
        }
    }
}
