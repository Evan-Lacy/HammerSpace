using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HammerSpace.WebMVC.Startup))]
namespace HammerSpace.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
