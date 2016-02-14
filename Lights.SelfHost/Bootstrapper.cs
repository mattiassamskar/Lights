using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;
namespace Lights.SelfHost
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            //container.Register<IRemoteDeviceService, RemoteDeviceService>().AsSingleton();
            container.Register<IRemoteDeviceService, FakeDeviceService>().AsSingleton();
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory(@"/", @"/Content"));
        }
    }
}
