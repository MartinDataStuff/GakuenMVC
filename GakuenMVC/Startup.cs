using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GakuenMVC.Startup))]
namespace GakuenMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
