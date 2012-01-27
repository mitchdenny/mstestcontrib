using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Hosting;

namespace MSTestContrib.UITesting.Silverlight.WebServer
{
    public class SimpleWebHost : MarshalByRefObject
    {
        public void ProcessRequest(string p, string q, TextWriter tw)
        {
            var swr = new SimpleWorkerRequest(p, q, tw);
            HttpRuntime.ProcessRequest(swr);
        }

        public static SimpleWebHost InitialiseHost(string localPath)
        {
            if (!(localPath.EndsWith("\\")))
                localPath = localPath + "\\";

            // *** Copy this hosting DLL into the /bin directory of the application
            var fileName = Assembly.GetExecutingAssembly().Location;
            try
            {
                if (!Directory.Exists(localPath + "bin\\"))
                    Directory.CreateDirectory(localPath + "bin\\");

                var justFname = Path.GetFileName(fileName);
                File.Copy(fileName, localPath + "bin\\" + justFname, true);
            }
            catch { ;}

            var theHost = (SimpleWebHost)ApplicationHost.CreateApplicationHost(typeof(SimpleWebHost), "/", localPath);

            return theHost;
        }
    }
}