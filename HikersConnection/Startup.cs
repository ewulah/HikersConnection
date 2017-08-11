using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HikersConnection.Startup))]
namespace HikersConnection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
