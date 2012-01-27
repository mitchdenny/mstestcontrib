using System;
using MSTestContrib.UITesting.Silverlight;
using Microsoft.VisualStudio.TestTools.UITesting.SilverlightControls;

namespace SilverlightTodo.Tests.Screens
{
    public class NewTaskScreen : SilverlightScreen
    {
        public NewTaskScreen(SilverlightApplicationBase application, SilverlightControl window) : 
            base(application, window)
        {
        }

        public string Title
        {
            get { return Page.Get<SilverlightEdit>("Title").Text; }
            set { Page.Get<SilverlightEdit>("Title").Text = value; }
        }

        public string Description
        {
            get { return Page.Get<SilverlightEdit>("Description").Text; }
            set { Page.Get<SilverlightEdit>("Description").Text = value; }
        }

        public DateTime DueDate
        {
            get { return Page.Get<SilverlightDatePicker>("DueDate").SelectedDate; }
            set { Page.Get<SilverlightDatePicker>("DueDate").SelectedDate = value; }
        }

        public void Create()
        {
            Page.Get<SilverlightButton>("CreateButton").Click();
        }
    }
}