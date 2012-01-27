using System.IO;
using System.Linq;
using System.Web;

namespace MSTestContrib.UITesting.Silverlight
{
    public class XapResolver
    {
        public static string XapFile()
        {
            var directoryName = HttpContext.Current.Request.PhysicalApplicationPath;
            return Path.GetFileName(Directory.GetFiles(directoryName, "*.xap").First());
        }
    }
}