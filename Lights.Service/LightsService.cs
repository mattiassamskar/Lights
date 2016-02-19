using Nancy.Hosting.Self;
using System;
using System.Configuration;
using System.ServiceProcess;

namespace Lights.Service
{
    public class LightsService : ServiceBase
    {
        private NancyHost host;

        public LightsService()
        {
            ServiceName = "LightsService";
            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            var port = ConfigurationManager.AppSettings["port"];
            host = new NancyHost(new Uri("http://localhost:" + port));
            host.Start();
        }

        protected override void OnStop()
        {
            host.Stop();
        }

        protected override void OnShutdown()
        {
            host.Stop();
        }
    }
}
