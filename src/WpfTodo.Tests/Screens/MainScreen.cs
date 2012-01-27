using System;
using System.Collections.Generic;
using System.Linq;
using MSTestContrib.UITesting.Wpf;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using WpfTodo.Model;

namespace WpfTodo.Tests.Screens
{
    public class MainScreen : WpfScreen
    {
        public MainScreen(WpfApplicationBase application, WpfWindow window) : base(application, window)
        {
        }

        public IEnumerable<Task> Tasks
        {
            get
            {
                var tasks = Window.Get<WpfList>("TasksList");
                return from WpfListItem item in tasks.Items
                        select new Task
                                    {
                                        Title = item.Get<WpfText>("Title").DisplayText,
                                        Description = item.Get<WpfText>("Description").DisplayText,
                                        DueDate = DateTime.Parse(item.Get<WpfText>("DueDate").DisplayText)
                                    };
            }
        }

        public NewTaskScreen NewTask()
        {
            var addTaskButton = Window.Get<WpfButton>("AddTaskButton");
            addTaskButton.Click();

            return new NewTaskScreen(Application, Window.GetWindow("New Task"));
        }
    }
}