using Owin;
using LeagueOfLegends.BLL.Services;

namespace LeagueOfLegends
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext<IIdentityService>(IdentityService.Create);
            IdentityService.ConfigureAuth(app);
        }

    }
}