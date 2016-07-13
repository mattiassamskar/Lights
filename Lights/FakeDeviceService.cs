using System;
using System.Collections.Generic;

namespace Lights
{
    public class FakeDeviceService : IRemoteDeviceService
    {
        public List<RemoteDevice> GetRemoteDevices()
        {
            return new List<RemoteDevice>
            {
                new RemoteDevice {Id = 1, Name = "device 1", On = true},
                new RemoteDevice {Id = 2, Name = "device 2", On = true},
                new RemoteDevice {Id = 3, Name = "device 3", On = true}
            };
        }

        public void TurnAllOff()
        {
            Console.WriteLine("All off");
        }

        public void TurnAllOn()
        {
            Console.WriteLine("All on");
        }

        public void TurnOff(int id)
        {
            Console.WriteLine(string.Format("Id {0} off", id));
        }

        public void TurnOn(int id)
        {
            Console.WriteLine(string.Format("Id {0} on", id));
        }
    }
}
