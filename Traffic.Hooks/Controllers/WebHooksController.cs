using System;
using System.IO;
using System.Threading;
using System.Web.Http;

namespace Traffic.Hooks.Controllers
{
    public class WebHooksController : ApiController
    {
        public string[] Get()
        {
            BackgroundTaskManager.Run(() => DoSomethingLater());
            return new[] { "Hello", "World" };
        }

        private static void DoSomethingLater()
        {
            var whenItStarted = DateTime.Now;
            Thread.Sleep(5000);
            File.AppendAllText(TemporaryFile, Message(whenItStarted, DateTime.Now));
        }

        protected static string TemporaryFile
        {
            get { return Path.GetTempPath() + "AsyncWebApiTest.txt"; }
        }

        private static string Message(DateTime startTime, DateTime endTime)
        {
            return string.Format("Started at {0} and ended at {1}{2}", startTime, endTime, Environment.NewLine);
        }
    }
}
