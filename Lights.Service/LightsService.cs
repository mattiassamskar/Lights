using System.ServiceProcess;

namespace Lights.Service
{
    public class LightsService : ServiceBase
    {
        public LightsService()
        {
            ServiceName = "LightsService";
            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {

        }
    }
}
