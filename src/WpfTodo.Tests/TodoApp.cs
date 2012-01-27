using System.IO;
using System.Reflection;
using MSTestContrib.UITesting.Wpf;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace WpfTodo.Tests
{
    public class TodoApp : WpfApplicationBase
    {
        protected override WpfWindow GetMainWindow()
        {
            return new WpfWindow
                        {
                            SearchProperties =
                                {
                                    {UITestControl.PropertyNames.Name, "Wpf Todo List"}
                                },
                            TechnologyName = "UIA"
                        };
        }

        protected override string ApplicationExeLocation
        {
            get { return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "WpfTodo.exe"); }
        }
    }
}