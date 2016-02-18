using System.ServiceProcess;

namespace Lights.Service
{
    public class Program
    {
        static void Main(string[] args)
        {
            LoadAssemblySoThatNancyFindsIt();
            ServiceBase.Run(new LightsService());
        }

        private static void LoadAssemblySoThatNancyFindsIt()
        {
            new LightsModule(new RemoteDeviceService());
        }
    }
}
