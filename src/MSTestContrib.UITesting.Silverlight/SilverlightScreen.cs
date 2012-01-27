using Microsoft.VisualStudio.TestTools.UITesting.SilverlightControls;

namespace MSTestContrib.UITesting.Silverlight
{
    public class SilverlightScreen
    {
        public SilverlightApplicationBase Application { get; set; }
        public SilverlightControl Page { get; set; }

        public SilverlightScreen(SilverlightApplicationBase application, SilverlightControl page)
        {
            Application = application;
            Page = page;
        }
    }
}