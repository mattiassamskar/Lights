using Nancy;
using Nancy.TinyIoc;
namespace Lights.SelfHost
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IRemoteDeviceHandler, FakeDeviceHandler>().AsSingleton();
            base.ConfigureApplicationContainer(container);
        }
    }
}
