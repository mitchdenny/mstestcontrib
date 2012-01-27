using MSTestContrib.UITesting.Silverlight.WebServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestContrib.UITesting.Silverlight
{
    [DeploymentItem("Default.aspx")]
    [DeploymentItem("Silverlight.js")]
    [DeploymentItem(".\\ClientBin\\")]
    public class SilverlightCodedUITestBase<T> : CodedUITestBase<T> where T : SilverlightApplicationBase, new()
    {
        static SilverlightCodedUITestBase()
        {
            SimpleWebServer.Initialise();
        }
    }
}