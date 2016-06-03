using System.Data.Entity;
using LeagueOfLegends.DAL.Model;

namespace LeagueOfLegends.BLL.Migrations
{
    public static class DatabaseMigrator
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }
    }
}