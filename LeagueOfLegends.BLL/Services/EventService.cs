using LeagueOfLegends.Common.List;
using Microsoft.Practices.Unity;
using LeagueOfLegends.DAL.Repositories;
using LeagueOfLegends.Domain;
using LeagueOfLegends.Domain.Filters;

namespace LeagueOfLegends.BLL.Services
{
    public class EventService : IEventService
    {
        [Dependency]
        public IEventRepository EventRepository { get; set; }

        public EventDetails Get(long id)
        {
            return EventRepository.Get(id);
        }

        public ListResult<EventDisplay> GetList(ListCriteria criteria, EventFilter filter)
        {
            return EventRepository.GetList(criteria, filter);
        }

        public ListResult<ApplicationUserDisplay> GetUserEvents(ListCriteria criteria, EventUserFilter filter)
        {
            return EventRepository.GetUserEvents(criteria, filter);
        }
    }
}