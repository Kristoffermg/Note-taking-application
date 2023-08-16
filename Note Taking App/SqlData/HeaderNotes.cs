using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note_Taking_App.Data
{
    internal class HeaderNotes : IComparable<HeaderNotes>
    {
        public int id;
        public int orderid;
        public string title;

        public int CompareTo(HeaderNotes other)
        {
            return title.CompareTo(other.title);
        }
    }
}
