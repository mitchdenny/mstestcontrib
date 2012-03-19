using System.IO;
using System.Reflection;
using MSTestContrib.UITesting.Wpf;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace MSTestContrib.UITesting.Quickstart.Wpf
{
    /// <summary>
    /// This class contains all the information and logic required to start your application and get hold of the main window
    /// </summary>
    public class ApplicationUnderTest : WpfApplicationBase
    {
        protected override WpfWindow GetMainWindow()
        {
            return new WpfWindow
            {
                // You have to use the title of your MainWindow to find it..

                SearchProperties =
                                {
                                    {UITestControl.PropertyNames.Name, MAINWINDOWTITLE}
                                },
                TechnologyName = "UIA"
            };
        }

        protected override string ApplicationExeLocation
        {
            get
            {
                // To get started with a simple executable, just add a reference to your application, then put the exe name here.
                // For more complex examples I suggest setting environmental variables
                // Example batch script (called InstallSmokeTest.cmd):
                //
                /*

                @echo off
                
                SETX MyAppExe "%~dp0..\MyApp\build\MyApp.exe"
                pause
                
                */

                // Then use the following code:

                // string myAppExeLocation;
                //
                // public static string FindMyAppExe()
                // {
                //     if (myAppExeLocation == null)
                //     {
                //         myAppExeLocation = Environment.GetEnvironmentVariable("MyAppExe", EnvironmentVariableTarget.User);
                //         if (string.IsNullOrEmpty(myAppExeLocation))
                //             throw new InvalidOperationException(@"Run InstallSmokeTest.cmd for your environment");
                //         myAppExeLocation = Path.GetFullPath(myAppExeLocation);
                //         Trace.WriteLine(string.Format("My App Exe is {0}", myAppExeLocation));
                //     }
                   
                //     return myAppExeLocation;
                // }
                

                return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), MYAPPEXE);
            }
        }
    }
}