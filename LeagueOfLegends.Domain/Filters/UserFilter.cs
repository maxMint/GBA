
namespace LeagueOfLegends.Domain.Filters
{
    public class UserFilter : BaseFilter
    {
        public string UserRole
        {
            get { return Role.User; }
        }
    }
}