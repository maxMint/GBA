namespace LeagueOfLegends.Domain
{
    public class ApplicationUserDisplay
    {
        public long Id { get; set; }

        public string TagName { get; set; }

        public string TeamName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name => FirstName + " " + LastName;
    }
}