using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HapiWifi.Web.Startup))]
namespace HapiWifi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
