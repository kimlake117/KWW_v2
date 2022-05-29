using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KimsWoodworking_v2.Startup))]
namespace KimsWoodworking_v2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
