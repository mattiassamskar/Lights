using Nancy.Hosting.Self;
using System;
using System.Configuration;

namespace Lights
{
    public class Program
    {
        static void Main(string[] args)
        {
            var port = ConfigurationManager.AppSettings["port"];

            using (var host = new NancyHost(new Uri("http://localhost:" + port)))
            {
                Console.WriteLine("Host listening on port " + port);
                host.Start();
                Console.ReadLine();
            }
        }
    }
}
