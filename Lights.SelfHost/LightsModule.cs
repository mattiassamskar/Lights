using Nancy;

namespace Lights.SelfHost
{
    public class LightsModule : NancyModule
    {
        private IRemoteDeviceHandler _remoteDeviceHandler = new FakeDeviceHandler();

        public LightsModule() : base("/lights")
        {
            Get["/"] = _ => { return _remoteDeviceHandler.GetRemoteDevices(); };
            Put["/on"] = _ => { return TurnAllDevicesOn(); };
            Put["/off"] = _ => { return TurnAllDevicesOff(); };
            Put["/{id}/on"] = _ => { return TurnDeviceOn(_.id); };
            Put["/{id}/off"] = _ => { return TurnDeviceOff(_.id); };
        }

        private dynamic TurnAllDevicesOn()
        {
            _remoteDeviceHandler.TurnAllOn();
            return Negotiate.WithStatusCode(200);
        }

        private dynamic TurnAllDevicesOff()
        {
            _remoteDeviceHandler.TurnAllOff();
            return Negotiate.WithStatusCode(200);
        }

        private dynamic TurnDeviceOn(int id)
        {
            _remoteDeviceHandler.TurnOn(id);
            return Negotiate.WithStatusCode(200);
        }

        private dynamic TurnDeviceOff(int id)
        {
            _remoteDeviceHandler.TurnOff(id);
            return Negotiate.WithStatusCode(200);
        }
    }
}
