using NUnit.Framework;
using System.Collections.Generic;
using Note_Taking_App.Data;

namespace Note_Taking_App.nUnitTests
{
    public class Form1Tests
    {
        private MainApp _form1;

        private List<ChildNotes> childNotes1 = new List<ChildNotes>()
        {
            new ChildNotes(1, 1, "Title1", "Content", 1),
            new ChildNotes(2, 1, "Title2", "Content", 2),
            new ChildNotes(3, 1, "Title3", "Content", 3)
        };

        [SetUp]
        public void Setup()
        {
            _form1 = new MainApp();
        }

        [Test]
        public void GetOrderId_EqualTest()
        {
            
        }
    }
}