using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Web;

namespace Lights.Controllers
{
    public class ServiceHandler
    {
        private readonly ServiceController _service;

        public ServiceHandler()
        {
            _service = new ServiceController("Telldus Service");
        }

        public bool IsStarted()
        {
            _service.Refresh();
            return _service.Status == ServiceControllerStatus.Running;
        }

        //public void StartService()
        //{
        //    if (_service.Status == ServiceControllerStatus.Running)
        //        return;

        //    _service.Start();
        //    _service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 30));
        //}

        //public void StopService()
        //{
        //    if (_service.Status == ServiceControllerStatus.Stopped)
        //        return;

        //    _service.Stop();
        //    _service.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 30));
        //}
    }
}