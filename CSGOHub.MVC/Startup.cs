using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSGOHub.MVC.Startup))]
namespace CSGOHub.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
