using System.Data.Entity;
using Microsoft.Owin;
using Owin;
using ShortUrlWebApp.Migrations;
using ShortUrlWebApp.Models;

[assembly: OwinStartupAttribute(typeof(ShortUrlWebApp.Startup))]
namespace ShortUrlWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());
        }
    }
}
