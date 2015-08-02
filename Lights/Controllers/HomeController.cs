using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lights.Controllers
{
    public class HomeController : Controller
    {
        static readonly RemoteDeviceHandler RemoteDeviceHandler = new RemoteDeviceHandler();
        static readonly ServiceHandler ServiceHandler = new ServiceHandler();

        public ActionResult Index()
        {
            try
            {
                if (!ServiceHandler.IsStarted())
                    throw new Exception("The Telldus service is not running.");

                var test = RemoteDeviceHandler.GetRemoteDevices();

                ViewBag.Devices = test;
                return View();
            }
            catch (Exception exception)
            {
                ViewBag.ErrorMessage = exception.Message;
                return View("Error");
            }
        }

        public void TurnOn(int id)
        {
            RemoteDeviceHandler.TurnOn(id);
        }

        public void TurnOff(int id)
        {
            RemoteDeviceHandler.TurnOff(id);
        }

        public void TurnAllOn()
        {
            RemoteDeviceHandler.TurnAllOn();
        }

        public void TurnAllOff()
        {
            RemoteDeviceHandler.TurnAllOff();
        }
    }
}