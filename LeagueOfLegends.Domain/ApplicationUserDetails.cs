

using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegends.Domain
{
    public class ApplicationUserDetails : EntityBaseDomain
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        [Display(Name = "Tag Name")]
        public string TagName { get; set; }

        public string Name => FirstName + " " + LastName;
    }
}