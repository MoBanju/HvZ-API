using AutoMapper;
using HvZWebAPI.DTOs.User;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDTO, User>();
            CreateMap<User, UserReadAdminDTO>();
        }
    }
}
