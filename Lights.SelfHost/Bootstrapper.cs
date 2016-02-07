using Nancy;
using Nancy.TinyIoc;
namespace Lights.SelfHost
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            //container.Register<IRemoteDeviceHandler, RemoteDeviceHandler>().AsSingleton();
            container.Register<IRemoteDeviceService, FakeDeviceService>().AsSingleton();
        }
    }
}
