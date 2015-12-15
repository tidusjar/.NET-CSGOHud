using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSGOHub.Core;

using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;

using Newtonsoft.Json;

using Owin;

namespace CSGOHub.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx 
            // for more information.
            var serverUrl = "http://localhost:8080/";
            var listenUrl = "http://localhost:8081/";

            using (WebApp.Start(serverUrl))
            {
                System.Console.WriteLine("Server running on {0}", serverUrl);
                System.Console.WriteLine("Started Listener {0}", listenUrl);
                
                var server = new CsgoServer(listenUrl);
                server.Start();

                //Let's keep the application running
                while (true)
                {
                    var jsonData = server.Listen();
                    IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<CsgoHub>();

                    var ser = new Serializer();
                    var json = ser.Deserialize(jsonData);
                    // Notify clients in the group
                    hubContext.Clients.All.update(json);
                }

            }
        }
    }
}
class Startup
{
    public void Configuration(IAppBuilder app)
    {
        app.UseCors(CorsOptions.AllowAll);
        app.MapSignalR();
    }
}

