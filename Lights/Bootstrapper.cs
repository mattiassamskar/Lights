using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
namespace Lights
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
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            pipelines.AfterRequest.AddItemToStartOfPipeline((ctx) =>
            {
                ctx.CheckForIfNonMatch();
                ctx.CheckForIfModifiedSince();
            });

            base.ApplicationStartup(container, pipelines);
        }
    }
}
