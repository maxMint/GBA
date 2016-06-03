using System;
using System.Collections.Generic;
using LeagueOfLegends.DAL.Model;

namespace LeagueOfLegends.DAL.Repositories.Sorting
{
    public class UserSorter : Sorter<ApplicationUser>
    {
        private readonly Dictionary<String, IEntitySorter<ApplicationUser>> _sorters = new Dictionary<string, IEntitySorter<ApplicationUser>>
            {
                { "Id_ASC", EntitySorter<ApplicationUser>.OrderBy(item => item.Id) },
                { "Id_DESC", EntitySorter<ApplicationUser>.OrderByDescending(item => item.Id) },
                { "Name_ASC", EntitySorter<ApplicationUser>.OrderBy(item => item.FirstName).ThenBy(item => item.LastName) },
                { "Name_DESC", EntitySorter<ApplicationUser>.OrderByDescending(item => item.FirstName).ThenByDescending(item => item.LastName) },
                { "Email_ASC", EntitySorter<ApplicationUser>.OrderBy(item => item.Email) },
                { "Email_DESC", EntitySorter<ApplicationUser>.OrderByDescending(item => item.Email) },
                { "Phone_ASC", EntitySorter<ApplicationUser>.OrderBy(item => item.PhoneNumber) },
                { "Phone_DESC", EntitySorter<ApplicationUser>.OrderByDescending(item => item.PhoneNumber) },
                { "TeamNamer_ASC", EntitySorter<ApplicationUser>.OrderBy(item => item.TeamName) },
                { "TeamName_DESC", EntitySorter<ApplicationUser>.OrderByDescending(item => item.TeamName) },
                { "TagNamer_ASC", EntitySorter<ApplicationUser>.OrderBy(item => item.TagName) },
                { "TagName_DESC", EntitySorter<ApplicationUser>.OrderByDescending(item => item.TagName) },
                { "Address_ASC", EntitySorter<ApplicationUser>.OrderBy(item => item.Address) },
                { "Address_DESC", EntitySorter<ApplicationUser>.OrderByDescending(item => item.Address) },

            };

        protected override Dictionary<string, IEntitySorter<ApplicationUser>> Sorters
        {
            get { return _sorters; }
        }

        protected override IEntitySorter<ApplicationUser> DefaultSorter
        {
            get { return EntitySorter<ApplicationUser>.OrderBy(item => item.Id); }
        }
    }
}