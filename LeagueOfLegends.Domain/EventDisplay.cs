using System;

namespace LeagueOfLegends.Domain
{
    public class EventDisplay : EntityBaseDomain
    {
        public string Name { get; set; }

        public string Date { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Description { get; set; }

        public long CompetitorTicketLimit { get; set; }

        public long SpectatorTicketLimit { get; set; }

        public TimeSpan CompetitorSignUpCutOffPeriod { get; set; }

        public TimeSpan SpectatorCutOffPeriod { get; set; }
    }
}