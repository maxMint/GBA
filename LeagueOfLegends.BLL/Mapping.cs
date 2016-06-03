using System.ComponentModel;
using AutoMapper;
using LeagueOfLegends.DAL.Model;
using LeagueOfLegends.Domain;

namespace LeagueOfLegends.BLL
{
    public static class Mapping
    {
        public static void Init(IMapperConfiguration config)
        {
            config.CreateMap<ApplicationUserDetails, ApplicationUser>().ReverseMap();
            config.CreateMap<RegisterModel, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
            config.CreateMap<ApplicationUserDisplay, ApplicationUser>().ReverseMap();
            config.CreateMap<Event, EventDisplay>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToShortDateString()))
                .ReverseMap();
            config.CreateMap<Event, EventDetails>()
                .ForMember(dest => dest.DateText, opt => opt.MapFrom(src => src.Date.ToLongDateString()))
                .ReverseMap();
        }
    }
}