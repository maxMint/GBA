using LeagueOfLegends.Common.List;
using LeagueOfLegends.Domain;
using LeagueOfLegends.Domain.Filters;

namespace LeagueOfLegends.BLL.Services
{
    public interface IUserService
    {
        ApplicationUserDetails Get(long id);

        ApplicationUserDetails GetUserByEmail(string email);

        ListResult<ApplicationUserDisplay> GetUsers(ListCriteria criteria, UserFilter filter);

        void AddEvent(long userId, long eventId);

        ListResult<EventDisplay> GetUserEvents(ListCriteria criteria, UserEventFilter filter);

        void AddEvent(long userId);
    }
}
