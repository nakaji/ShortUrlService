using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShortUrlWebApp.Startup))]
namespace ShortUrlWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
