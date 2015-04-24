using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Hosting;
using Microsoft.Owin.Hosting;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var ass = Assembly.Load("WebApis");

            using (var server = WebApp.Start<Startup>("http://+:9876"))
            {
                Console.WriteLine("Web API Server läuft...");
                Console.ReadLine();
            }
        }
    }
}
