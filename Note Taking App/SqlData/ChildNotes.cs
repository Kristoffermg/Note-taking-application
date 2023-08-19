using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Taking_App.Data
{
    public class ChildNotes
    {
        public int id;
        public int headerID;
        public string title;
        public string content;
        public int orderid;

        public ChildNotes(int id, int headerID, string title, string content, int orderid)
        {
            this.id = id;
            this.headerID = headerID;
            this.title = title;
            this.content = content;
            this.orderid = orderid;
        }
    }
}
