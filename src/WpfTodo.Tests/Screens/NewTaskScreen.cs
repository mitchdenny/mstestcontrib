using System;
using MSTestContrib.UITesting.Wpf;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace WpfTodo.Tests.Screens
{
    public class NewTaskScreen : WpfScreen
    {
        public NewTaskScreen(WpfApplicationBase application, WpfWindow window) : base(application, window)
        {
        }

        public string Title
        {
            get { return Window.Get<WpfEdit>("Title").Text; }
            set { Window.Get<WpfEdit>("Title").Text = value; }
        }

        public string Description
        {
            get { return Window.Get<WpfEdit>("Description").Text; }
            set { Window.Get<WpfEdit>("Description").Text = value; }
        }

        public DateTime DueDate
        {
            get { return Window.Get<WpfDatePicker>("DueDate").Date; }
            set { Window.Get<WpfDatePicker>("DueDate").Date = value; }
        }

        public void Create()
        {
            Window.Get<WpfButton>("CreateButton").Click();
        }
    }
}