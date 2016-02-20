using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TellCore;

namespace Lights.Controllers
{
    public class RemoteDeviceHandler
    {
        readonly object _lockObject = new object();
        private const int Timeout = 300;
        private readonly List<RemoteDevice> _remoteDevices = new List<RemoteDevice>();

        public List<RemoteDevice> GetRemoteDevices()
        {
            //return new List<RemoteDevice>
            //{
            //    new RemoteDevice {Id = 1, Name = "lampa", On = true},
            //    new RemoteDevice {Id = 2, Name = "soffa", On = true},
            //    new RemoteDevice {Id = 3, Name = "lamino", On = true}
            //};

            if (_remoteDevices.Any())
                return _remoteDevices;

            lock (_lockObject)
            {
                for (var index = 0; index < GetNumberOfRemoteDevices(); index++)
                {
                    _remoteDevices.Add(GetRemoteDevice(index));
                }
            }
            return _remoteDevices;
        }

        public void TurnOn(int id)
        {
            lock (_lockObject)
            {
                using (var client = new TellCoreClient())
                {
                    client.TurnOn(id);
                }
            }
        }

        public void TurnOff(int id)
        {
            lock (_lockObject)
            {
                using (var client = new TellCoreClient())
                {
                    client.TurnOff(id);
                }
            }
        }

        public void TurnAllOn()
        {
            GetRemoteDevices().ForEach(device =>
            {
                TurnOn(device.Id);
                Thread.Sleep(Timeout);
            });
        }

        public void TurnAllOff()
        {
            GetRemoteDevices().ForEach(device =>
            {
                TurnOff(device.Id);
                Thread.Sleep(Timeout);
            });
        }

        private int GetNumberOfRemoteDevices()
        {
            int numberOfdevices;

            using (var client = new TellCoreClient())
            {
                numberOfdevices = client.GetNumberOfDevices();
            }

            if (numberOfdevices < 0)
                throw new Exception("Something went wrong when listing devices.");

            return numberOfdevices;
        }

        private RemoteDevice GetRemoteDevice(int index)
        {
            using (var client = new TellCoreClient())
            {
                var id = client.GetDeviceId(index);

                return new RemoteDevice
                {
                    Id = id,
                    Name = client.GetName(id),
                    On = client.GetLastSentCommand(id, DeviceMethod.TurnOn | DeviceMethod.TurnOff) == DeviceMethod.TurnOn
                };
            }
        }
    }
}