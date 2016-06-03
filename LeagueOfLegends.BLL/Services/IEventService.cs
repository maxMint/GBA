using LeagueOfLegends.Common.List;
using LeagueOfLegends.Domain;
using LeagueOfLegends.Domain.Filters;

namespace LeagueOfLegends.BLL.Services
{
    public interface IEventService
    {
        EventDetails Get(long id);

        ListResult<EventDisplay> GetList(ListCriteria criteria, EventFilter filter);

        ListResult<ApplicationUserDisplay> GetUserEvents(ListCriteria criteria, EventUserFilter filter);
    }
}
