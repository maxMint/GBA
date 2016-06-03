using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeagueOfLegends.Startup))]
namespace LeagueOfLegends
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
