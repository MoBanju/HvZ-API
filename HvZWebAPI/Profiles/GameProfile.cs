using AutoMapper;
using HvZWebAPI.DTOs.Game;
using HvZWebAPI.DTOs.Player;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<Game, GameReadDTO>().ReverseMap();
        CreateMap<GameUpdateDeleteDTO, Game>();
        CreateMap<GameCreateDTO, Game>();
    }


}