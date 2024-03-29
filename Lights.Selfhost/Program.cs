﻿using Nancy.Hosting.Self;
using System;
using System.Configuration;

namespace Lights
{
    public class Program
    {
        static void Main(string[] args)
        {
            LoadAssemblySoThatNancyFindsIt();

            var port = ConfigurationManager.AppSettings["port"];

            using (var host = new NancyHost(new HostConfiguration { UrlReservations = new UrlReservations { CreateAutomatically = true } }, new Uri("http://localhost:" + port)))
            {
                Console.WriteLine("Host listening on port " + port);
                host.Start();
                Console.ReadLine();
            }
        }

        private static void LoadAssemblySoThatNancyFindsIt()
        {
            new LightsModule(new RemoteDeviceService());
        }
    }
}
