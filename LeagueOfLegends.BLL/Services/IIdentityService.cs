using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueOfLegends.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace LeagueOfLegends.BLL.Services
{
    public interface IIdentityService : IDisposable
    {
        Task<IdentityResult> Register(RegisterModel model);

        Task<SignInStatus> PasswordSignInAsync(string email, string password, bool rememberMe, bool shouldLockout);

        Task<bool> SignInAsync(string email, string password, bool rememberMe);

        Task<IList<string>> GetRolesAsync(string email, string password);
    }
}