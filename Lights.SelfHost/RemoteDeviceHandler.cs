using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TelldusWrapper;

namespace Lights.SelfHost
{
    public class FakeDeviceHandler : IRemoteDeviceHandler
    {
        public List<RemoteDevice> GetRemoteDevices()
        {
            return new List<RemoteDevice>
            {
                new RemoteDevice {Id = 1, Name = "lampa", On = true},
                new RemoteDevice {Id = 2, Name = "soffa", On = true},
                new RemoteDevice {Id = 3, Name = "lamino", On = true}
            };
        }

        public void TurnAllOff()
        {
        }

        public void TurnAllOn()
        {
        }

        public void TurnOff(int id)
        {
        }

        public void TurnOn(int id)
        {
        }
    }

    public class RemoteDeviceHandler : IRemoteDeviceHandler
    {
        readonly object _lockObject = new object();
        private const int Timeout = 300;
        private readonly List<RemoteDevice> _remoteDevices = new List<RemoteDevice>();

        public List<RemoteDevice> GetRemoteDevices()
        {
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
                TelldusNETWrapper.tdTurnOn(id);
            }
        }

        public void TurnOff(int id)
        {
            lock (_lockObject)
            {
                TelldusNETWrapper.tdTurnOff(id);
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
            var numberOfdevices = TelldusNETWrapper.tdGetNumberOfDevices();

            if (numberOfdevices < 0)
                throw new Exception("Something went wrong when listing devices.");

            return numberOfdevices;
        }

        private RemoteDevice GetRemoteDevice(int index)
        {
            var id = TelldusNETWrapper.tdGetDeviceId(index);

            var remoteDevice = new RemoteDevice
            {
                Id = id,
                Name = TelldusNETWrapper.tdGetName(id),
                On = TelldusNETWrapper.tdLastSentCommand(id, TelldusNETWrapper.TELLSTICK_TURNON | TelldusNETWrapper.TELLSTICK_TURNOFF) == TelldusNETWrapper.TELLSTICK_TURNON
            };

            return remoteDevice;
        }
    }
}