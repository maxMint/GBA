using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeagueOfLegends.DAL.Model
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext()  : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<LogEntry> LogEntries { get; set; }
    }
}