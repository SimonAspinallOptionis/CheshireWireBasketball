using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Website.CheshireWire.Startup))]
namespace Website.CheshireWire
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
