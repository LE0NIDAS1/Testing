using Microsoft.Owin;
using Owin;
using Shared.JuegoEntities;

[assembly: OwinStartupAttribute(typeof(PresentationLayer.Startup))]
namespace PresentationLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
