using System;
using System.Data.Entity.Migrations;
using System.Linq;
using LeagueOfLegends.DAL.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeagueOfLegends.BLL.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                CreateUsers(context);
                CreateEvent(context);
                base.Seed(context);
                context.SaveChanges();
            }
        }

        private void CreateEvent(ApplicationDbContext context)
        {
            context.Events.Add(new Event
            {
                Name = "League of Legends",
                Date = DateTime.Today,
                Address = "Address",
                City = "City",
                State = "State",
                Description = "DESCRIPTION"
            });
        }

        private void CreateUsers(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser, CustomRole, long,
                CustomUserLogin, CustomUserRole, CustomUserClaim>(context));
            var adminRole = new CustomRole("Admin");
            var userRole = new CustomRole("User");
            context.Roles.Add(adminRole);
            context.Roles.Add(userRole);
            CreateAdmin(userManager, adminRole);
            CreateUsers(userManager, userRole);
        }

        private void CreateAdmin(ApplicationUserManager userManager, CustomRole adminRole)
        {
            var admin = new ApplicationUser
            {
                Email = "admin@bga.com",
                FirstName = "Bo",
                LastName = "Falk",
                UserName = "admin@bga.com"
            };
            var result = userManager.Create(admin, "admin123");
            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
            }
        }

        private void CreateUsers(ApplicationUserManager userManager, CustomRole userRole)
        {
            const int userCount = 20;
            for (var i = 0; i < userCount; i++)
            {
                var user = new ApplicationUser
                {
                    Email = "user" + i + "@bga.com",
                    FirstName = "User" + i,
                    LastName = "User" + i,
                    UserName = "user" + i + "@bga.com",
                    TagName = "Tag" + i,
                    TeamName = "Team Name" + i,
                    Address = "Address" + i,
                    PhoneNumber = "Phone" + i
                };
                var result = userManager.Create(user, "userbga1");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, userRole.Name);
                }
            }
        }
    }
}