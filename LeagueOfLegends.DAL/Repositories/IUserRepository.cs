using LeagueOfLegends.Common.List;
using LeagueOfLegends.DAL.Repositories.Base;
using LeagueOfLegends.Domain;
using LeagueOfLegends.Domain.Filters;

namespace LeagueOfLegends.DAL.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUserDisplay, ApplicationUserDetails>
    {
        ApplicationUserDetails GetUserByEmail(string email);

        ApplicationUserDetails GetUser();

        void AddEvent(long userId, long eventId);

        ListResult<EventDisplay> GetUserEvents(ListCriteria criteria, UserEventFilter filter);
    }
}
