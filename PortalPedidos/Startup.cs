using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PortalPedidos.Startup))]
namespace PortalPedidos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
