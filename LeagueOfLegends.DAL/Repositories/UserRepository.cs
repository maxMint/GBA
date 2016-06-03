using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;
using LeagueOfLegends.DAL.Model;
using LeagueOfLegends.Domain;
using AutoMapper;
using LeagueOfLegends.Common.List;
using LeagueOfLegends.DAL.Repositories.Base;
using LeagueOfLegends.DAL.Repositories.Sorting;
using LeagueOfLegends.Domain.Filters;

namespace LeagueOfLegends.DAL.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser, ApplicationUserDisplay, ApplicationUserDetails>,
        IUserRepository
    {
        protected override Sorter<ApplicationUser> Sorter => new UserSorter();

        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        protected override IQueryable<ApplicationUser> ApplyFilter(IQueryable<ApplicationUser> query, object filterObj)
        {
            var filter = filterObj as UserFilter;
            var userRole = DbContext.Roles.First(x => x.Name == Role.User);
            if (filter != null)
            {
                return
                    query.Where(
                        c => (string.IsNullOrEmpty(filter.SearchText) || c.FirstName.Contains(filter.SearchText))
                             && (c.Roles.Select(x => x.RoleId).Contains(userRole.Id)));
            }
            return query;
        }

        public ApplicationUserDetails GetUser()
        {
            var users = DbContext.Roles.Include(m => m.Users).Where(x => x.Name == Role.User.ToString()).ToList();
            return Mapper.Map<ApplicationUserDetails>(DbContext.Users.FirstOrDefault());
        }

        public ApplicationUserDetails GetUserByEmail(string email)
        {
            return
                Mapper.Map<ApplicationUserDetails>(DbContext.Set<ApplicationUser>()
                    .FirstOrDefault(x => x.Email == email));
        }

        public void AddEvent(long userId, long eventId)
        {
            var user = DbContext.Users.First(x => x.Id == userId);
            if (!user.Events.Select(x => x.Id).Contains(eventId))
            {
                user.Events.Add(DbContext.Events.First(x => x.Id == eventId));
                DbContext.SaveChanges();
            }
        }

        public ListResult<EventDisplay> GetUserEvents(ListCriteria criteria, UserEventFilter filter)
        {
            var query = DbContext.Users.First(x => x.Id == filter.Userid).Events.AsQueryable()
                .Where(x => (string.IsNullOrEmpty(filter.SearchText) || x.Name.Contains(filter.SearchText)));
            return query.ApplyListCriteria<Event, EventDisplay>(criteria, new EventSorter());
        }

    }
}