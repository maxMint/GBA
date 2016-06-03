using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LeagueOfLegends.DAL.Model;
using LeagueOfLegends.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace LeagueOfLegends.BLL.Services
{
    public class IdentityService : IIdentityService
    {
        public ApplicationSignInManager SignInManager { get; set; }

        public ApplicationUserManager UserManager { get; set; }

        public IdentityService(ApplicationUserManager userManager, IOwinContext context)
        {
            UserManager = userManager;
            SignInManager = new ApplicationSignInManager(UserManager, context.Authentication);
        }

        public static IIdentityService Create(IdentityFactoryOptions<IIdentityService> options, IOwinContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser, CustomRole, long,
                CustomUserLogin, CustomUserRole, CustomUserClaim>(new ApplicationDbContext()));
            return new IdentityService(userManager, context);
        }

        public static void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator
                    .OnValidateIdentity<ApplicationUserManager, ApplicationUser, long>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentityCallback: (manager, user) =>
                        user.GenerateUserIdentityAsync(manager),
                        getUserIdCallback: (id) => (id.GetUserId<int>()))
                }
            });
        }

        public async Task<IdentityResult> Register(RegisterModel model)
        {
            var user = Mapper.Map<ApplicationUser>(model);
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                UserManager.AddToRole(user.Id, Role.User);
                await SignInManager.SignInAsync(user, false, false);
            }
            return result;
        }

        public Task<SignInStatus> PasswordSignInAsync(string email, string password, bool rememberMe, bool shouldLockout)
        {
            return SignInManager.PasswordSignInAsync(email, password, rememberMe, shouldLockout);
        }

        public async Task<IList<string>> GetRolesAsync(string email, string passsword)
        {
            var user = await UserManager.FindAsync(email, passsword);
            return await UserManager.GetRolesAsync(user.Id);
        }

        public async Task<bool> SignInAsync(string email, string password, bool rememberMe)
        {
            var user = await UserManager.FindAsync(email, password);
            if (user != null)
            {
                await SignInManager.SignInAsync(user, rememberMe, false);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            if (SignInManager != null)
            {
                SignInManager.Dispose();
                SignInManager = null;
            }
            if (UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
        }
    }
}