using AutoMapper;
using HvZWebAPI.DTOs.PlayerKill;
using HvZWebAPI.Models;
namespace HvZWebAPI.Profiles
{
    public class PlayerKillProfile : Profile
    {
        public PlayerKillProfile()
        {
            CreateMap<PlayerKill, PlayerKillReadDTO>();
        }
    }
}
