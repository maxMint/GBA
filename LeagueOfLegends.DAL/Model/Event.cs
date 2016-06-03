using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegends.DAL.Model
{
    public class Event : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Description { get; set; }

        public long CompetitorTicketLimit { get; set; }

        public long SpectatorTicketLimit { get; set; }

        public TimeSpan CompetitorSignUpCutOffPeriod { get; set; }

        public TimeSpan SpectatorCutOffPeriod { get; set; }

        public virtual List<ApplicationUser> Users { get; set; } 
    }
}