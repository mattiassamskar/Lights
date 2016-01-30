using Nancy;

namespace Lights.SelfHost
{
    public class LightsModule : NancyModule
    {
        private IRemoteDeviceHandler _remoteDeviceHandler = new FakeDeviceHandler();

        public LightsModule() : base("/lights")
        {
            Get["/"] = _ => { return _remoteDeviceHandler.GetRemoteDevices(); };
        }
    }
}
