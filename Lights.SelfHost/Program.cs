using Nancy;
using Nancy.Hosting.Self;
using System;

namespace Lights.SelfHost
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:8180")))
            {
                host.Start();
                Console.ReadLine();
            }
        }
    }

    public class LightsModule : NancyModule
    {
        public LightsModule() : base("/")
        {
            Get["/"] = _ => { return "hello world!"; };
        }
    }
}
