using MSTestContrib.UITesting.Wpf;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace MSTestContrib.UITesting.Quickstart.Wpf.Screens
{
    /// <summary>
    /// Contains methods and properties which interact with the MainWindow of your application.
    /// 
    /// The screen pattern is used to encapsulate all UI Automation logic inside a class dedicated to representing each screen/window in your application.
    /// The methods and properties should represent USER ACTIONS. This way your tests represent user scenario's, and are free from implementation details.
    /// </summary>
    public class MainScreen : WpfScreen
    {
        public MainScreen(WpfApplicationBase application, WpfWindow window) : 
            base(application, window)
        {
        }

        /// <summary>
        /// Example of an action. An action which causes a navigation or new window should return a new screen
        /// which represents that window (enabling reuse of common screens!)
        /// </summary>
        /// <returns></returns>
        public AnotherScreen OpenSomething()
        {
            //Click to open the window
            Window.Get<WpfButton>("SomeButton").Click();

            return AnotherScreen(Application, Window.GetWindow("Another Window"));
        }

        /// <summary>
        /// Example of exposing state
        /// </summary>
        public string SomeValue
        {
            get { return Window.Get<WpfText>("SomeLabel").DisplayText; }
        }
    }
}