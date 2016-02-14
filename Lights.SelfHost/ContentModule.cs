using Nancy;

namespace Lights.SelfHost
{
    public class ContentModule : NancyModule
    {
        public ContentModule()
        {
            Get["/"] = _ => Response.AsFile("Content/index.html");
        }
    }
}
