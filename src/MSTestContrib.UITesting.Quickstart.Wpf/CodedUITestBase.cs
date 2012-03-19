using MSTestContrib.UITesting;
using Quickstart.Wpf.Screens;

namespace Quickstart.Wpf
{
    public class CodedUiTestBase : CodedUITestBase<ApplicationUnderTest>
    {
        protected MainScreen MainScreen()
        {
            return new MainScreen(Application, Application.MainWindow);
        }

        protected void WaitWhileBusy()
        {
            // Put logic in here to detect if the application is busy.

            // Suggestions for this is using Automation help text to hint that the shell is busy.
            // i.e in your busy code:

            // AutomationProperties.SetHelpText(shell, "Busy");
            //when not busy
            // AutomationProperties.SetHelpText(shell, string.Empty);

            //Then in this method:

            //Block while window is busy
            //Retry.For(() => Application.MainWindow.HelpText, shouldRetry: helpText => helpText == "Busy", retryForSeconds: 10);
        }
    }
}