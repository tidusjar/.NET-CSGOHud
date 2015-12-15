using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CSGOHub.Console
{
    public class CsgoServer
    {
        private HttpListener Listener { get; set; }
        private string Address { get; set; }
        public CsgoServer(string addressToListen)
        {
            Address = addressToListen;
        }

        public void Start()
        {
            Listener = new HttpListener { Prefixes = { Address } };

            Listener.Start();
        }

        public string Listen()
        {

            //https://bitbucket.org/master117/csgogameobserversdk/src/4fa70286673e8add56f6c93e301305a26a4c60f6/CSGOGameObserverSDK/CSGOGameObserverServer.cs?at=master&fileviewer=file-view-default

            var context = Listener.GetContext();
            try
            {
                var request = context.Request;
                string text;
                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    text = reader.ReadToEnd();
                }

                context.Response.StatusCode = 200;
                context.Response.StatusDescription = "OK";
                context.Response.Close();

                return text;

            }
            catch (Exception)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = "ERROR";
                context.Response.Close();
            }
            return null;

        }
    }
}
