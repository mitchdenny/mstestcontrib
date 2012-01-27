using System;
using System.Collections.Generic;
using System.Linq;
using MSTestContrib.UITesting.Silverlight;
using Microsoft.VisualStudio.TestTools.UITesting.SilverlightControls;
using SilverlightTodo.Tests.Model;

namespace SilverlightTodo.Tests.Screens
{
    public class MainScreen : SilverlightScreen
    {
        public MainScreen(SilverlightApplicationBase application, SilverlightControl page) : base(application, page)
        {
        }

        public IEnumerable<Task> Tasks
        {
            get
            {
                var tasks = Page.Get<SilverlightList>("TasksList");
                return from SilverlightListItem item in tasks.Items
                       let dueDate = item.Get<SilverlightText>("DueDate").Text
                       select new Task
                                    {
                                        Title = item.Get<SilverlightText>("Title").Text,
                                        Description = item.Get<SilverlightText>("Description").Text,
                                        DueDate = DateTime.Parse(dueDate)
                                    };
            }
        }

        public NewTaskScreen NewTask()
        {
            var addTaskButton = Page.Get<SilverlightButton>("AddTaskButton");
            addTaskButton.Click();

            return new NewTaskScreen(Application, Page.Get<SilverlightControl>("NewTaskWindow"));
        }
    }
}