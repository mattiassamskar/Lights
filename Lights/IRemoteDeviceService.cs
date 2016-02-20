using System.Collections.Generic;

namespace Lights
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