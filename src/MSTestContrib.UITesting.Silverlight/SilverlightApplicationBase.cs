using System;
using System.Diagnostics;
using MSTestContrib.UITesting.Silverlight.WebServer;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.SilverlightControls;

namespace MSTestContrib.UITesting.Silverlight
{
    public abstract class SilverlightApplicationBase : ICodedUIApplication
    {
        public virtual void Start()
        {
            try
            {
                Trace.WriteLine("Opening Internet Explorer");
                var fileName = new Uri(new Uri(SimpleWebServer.HostUrl, UriKind.Absolute), "Default.aspx");
                BrowserWindow = BrowserWindow.Launch(fileName);
                var document = new HtmlDocument(BrowserWindow)
                                   {
                                       FilterProperties =
                                           {
                                               {HtmlControl.PropertyNames.Title, "ApplicationUnderTest"}
                                           },
                                       WindowTitles =
                                           {
                                               "ApplicationUnderTest"
                                           }
                                   };
                var controlHostDiv = new HtmlDiv(document)
                                      {
                                          SearchProperties =
                                              {
                                                  {HtmlControl.PropertyNames.Id, "silverlightControlHost"}
                                              },
                                          FilterProperties =
                                              {
                                                  {
                                                      HtmlControl.PropertyNames.ControlDefinition,
                                                      "id=silverlightControlHost"
                                                      }
                                              },
                                          WindowTitles =
                                              {
                                                  "ApplicationUnderTest"
                                              }
                                      };
                var controlHost = new HtmlCustom(controlHostDiv)
                                      {
                                          SearchProperties =
                                              {
                                                  {"TagName", "OBJECT"}
                                              }
                                      };

                MainPage = new SilverlightControl(controlHost)
                               {
                                   SearchProperties =
                                       {
                                           {UITestControl.PropertyNames.ControlType, MainPageTypeName}
                                       }
                               };
                MainPage.Find();
                MainPage.WaitForControlReady();
            }
            catch (Exception)
            {
                Close();
                throw;
            }
        }

        public abstract string MainPageTypeName { get; }

        public SilverlightControl MainPage { get; private set; }

        public BrowserWindow BrowserWindow { get; private set; }

        public virtual void Close()
        {
            Trace.WriteLine("Closing Application");
            if (BrowserWindow.Process.HasExited)
            {
                Trace.WriteLine("Application Process has already exited (crashed?)");
                BrowserWindow.Process.Dispose();
                return;
            }
            BrowserWindow.Process.CloseMainWindow();
            BrowserWindow.Process.WaitForExit(5000);
            if (!BrowserWindow.Process.HasExited)
            {
                Trace.WriteLine("Application Failed to exit (modal window open?), killing process");
                BrowserWindow.Process.Kill();
            }
            BrowserWindow.Process.Dispose();
            BrowserWindow = null;
        }
    }
}