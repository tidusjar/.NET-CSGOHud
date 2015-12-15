using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Owin.Hosting;

namespace CSGOHub.MVC
{
    public static class Start
    {
        public static void StartWebServer()
        {
            var url = "http://localhost:8081";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
}