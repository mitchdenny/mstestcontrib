using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Web;
using ThreadState = System.Threading.ThreadState;

namespace MSTestContrib.UITesting.Silverlight.WebServer
{
    public static class SimpleWebServer
    {
        const int PortNumber = 9999;
        private static HttpListener _listener;
        private static readonly Thread ListeningThread;

        private static readonly SimpleWebHost Host;
        private static bool _webServerRunning = true;
        private static readonly string LocalPath;

        static SimpleWebServer()
        {
            AppDomain.CurrentDomain.DomainUnload += CurrentDomainDomainUnload;

            LocalPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Host = SimpleWebHost.InitialiseHost(LocalPath);

            InitialiseListener();

            ListeningThread = new Thread(CreateListeningThread);
            ListeningThread.Start();
        }

        private static void CreateListeningThread()
        {
            while (_webServerRunning)
            {
                var context = _listener.GetContext();

                var page = context.Request.Url.LocalPath.Replace("/", "");
                var query = context.Request.Url.Query.Replace("?", "");
                Debug.WriteLine("Received request for {0}?{1}", page, query);

                if (page.EndsWith(".xap"))
                {
                    context.Response.ContentType = "application/x-silverlight-app";
                    var fileName = Path.GetFileName(page);
                    using (var fileStream = File.OpenRead(Path.Combine(LocalPath, fileName)))
                    {
                        fileStream.CopyTo(context.Response.OutputStream);
                    }
                }
                else
                {
                    using (var sw = new StreamWriter(context.Response.OutputStream))
                    {
                        Host.ProcessRequest(page, query, sw);
                        sw.Flush();
                    }
                }
                context.Response.Close();
            }
        }

        /// <summary>
        /// Initialise our http listener 
        /// </summary>
        private static void InitialiseListener()
        {
            _listener = new HttpListener();

            HostUrl = string.Format("http://localhost:{0}/", PortNumber);
            _listener.Prefixes.Add(HostUrl);

            _listener.Start();
        }

        public static string HostUrl { get; private set; }

        private static void Shutdown()
        {
            _webServerRunning = false;
            if (_listener.IsListening)
                _listener.Stop();
            if (ListeningThread.ThreadState == ThreadState.Running)
                ListeningThread.Abort();
        }

        private static void CurrentDomainDomainUnload(object sender, EventArgs e)
        {
            Shutdown();
        }

        public static void Initialise()
        {
            //Does nothing, just ensures that the static ctor has been hit
            //We only want a single web server per test run
        }
    }
}