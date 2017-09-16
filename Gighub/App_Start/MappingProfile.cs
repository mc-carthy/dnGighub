using AutoMapper;
using Gighub.Models;
using Gighub.Models.Dtos;

namespace Gighub.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}