using System.Collections.Generic;

namespace Lights.SelfHost
{
    public interface IRemoteDeviceService
    {
        List<RemoteDevice> GetRemoteDevices();
        void TurnOn(int id);
        void TurnOff(int id);
        void TurnAllOn();
        void TurnAllOff();
    }
}