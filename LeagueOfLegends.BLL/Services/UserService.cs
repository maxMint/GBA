using LeagueOfLegends.Common.List;
using LeagueOfLegends.DAL.Repositories;
using LeagueOfLegends.Domain;
using LeagueOfLegends.Domain.Filters;
using LeagueOfLegends.Helpers;

namespace LeagueOfLegends.BLL.Services
{
    public class UserService : IUserService
    {
        public UserRepository UserRepository { get; set; }

        public UserService(UserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public ApplicationUserDetails GetUser()
        {
            return UserRepository.GetUser();
        }

        public ApplicationUserDetails GetUserByEmail(string email)
        {
            return UserRepository.GetUserByEmail(email);
        }

        public ListResult<ApplicationUserDisplay> GetUsers(ListCriteria criteria, UserFilter filter)
        {
            return UserRepository.GetList(criteria, filter);
        }

        public ApplicationUserDetails Get(long id)
        {
            return UserRepository.Get(id);
        }

        public void AddEvent(long userId, long eventId)
        {
            UserRepository.AddEvent(userId, eventId);
        }

        public void AddEvent(long userId)
        {
            var eventId = SessionHelper.GetValue(SessionHelper.Event) as long?;
            if (eventId.HasValue)
            {
                UserRepository.AddEvent(userId, eventId.Value);
                SessionHelper.Clear(SessionHelper.Event);
            }
        }

        public ListResult<EventDisplay> GetUserEvents(ListCriteria criteria, UserEventFilter filter)
        {
            return UserRepository.GetUserEvents(criteria, filter);
        }
    }
}