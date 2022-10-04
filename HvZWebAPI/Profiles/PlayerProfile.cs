using AutoMapper;
using HvZWebAPI.DTOs.Player;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles;

public class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        CreateMap<Player, PlayeReadNonAdminDTO>();
        CreateMap<Player, PlayerReadAdminDTO>();
        CreateMap<PlayerUpdateDeleteDTO, Player>();
        CreateMap<PlayerCreateDTO, Player>();
    }


}
