using LeagueOfLegends.Common.List;
using LeagueOfLegends.DAL.Repositories.Base;
using LeagueOfLegends.Domain;
using LeagueOfLegends.Domain.Filters;

namespace LeagueOfLegends.DAL.Repositories
{
    public interface IEventRepository : IRepository<EventDisplay, EventDetails>
    {
        ListResult<ApplicationUserDisplay> GetUserEvents(ListCriteria criteria, EventUserFilter filter);
    }
}
