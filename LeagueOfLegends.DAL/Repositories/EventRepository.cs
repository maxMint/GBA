using System.Linq;
using LeagueOfLegends.Common.List;
using LeagueOfLegends.DAL.Model;
using LeagueOfLegends.DAL.Repositories.Base;
using LeagueOfLegends.DAL.Repositories.Sorting;
using LeagueOfLegends.Domain;
using LeagueOfLegends.Domain.Filters;

namespace LeagueOfLegends.DAL.Repositories
{
    public class EventRepository : BaseRepository<Event, EventDisplay, EventDetails>, IEventRepository
    {
        protected override Sorter<Event> Sorter => new EventSorter();

        public EventRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        protected override IQueryable<Event> ApplyFilter(IQueryable<Event> query, object filterObj)
        {
            var filter = filterObj as EventFilter;
            if (filter != null)
            {
                return
                    query.Where(
                        c => (string.IsNullOrEmpty(filter.SearchText) || c.Name.Contains(filter.SearchText)));
            }
            return query;
        }

        public ListResult<ApplicationUserDisplay> GetUserEvents(ListCriteria criteria, EventUserFilter filter)
        {
            var query = DbContext.Events.First(x => x.Id == filter.EventId).Users.AsQueryable()
                .Where(x => (string.IsNullOrEmpty(filter.SearchText) || x.FirstName.Contains(filter.SearchText) || x.LastName.Contains(filter.SearchText)));
            return query.ApplyListCriteria<ApplicationUser, ApplicationUserDisplay>(criteria, new UserSorter());
        }
    }
}