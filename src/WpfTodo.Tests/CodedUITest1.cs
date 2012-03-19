using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WpfTodo.Tests
{
    [CodedUITest]
    public class CanAddTaskTest : CodedUiTestBase
    {
        [TestMethod]
        public void CodedUITestMethod1()
        {
            var mainScreen = MainScreen();
            var newTaskScreen = mainScreen.NewTask();

            const string title = "Write some tests";
            newTaskScreen.Title = title;
            newTaskScreen.Description = "for MSTestContrib";
            newTaskScreen.DueDate = DateTime.Now.AddDays(3);

            newTaskScreen.Create();

            var tasks = mainScreen.Tasks.ToList();
            Assert.AreEqual(1, tasks.Count);
            Assert.AreEqual(title, tasks[0].Title);
        }
    }
}
