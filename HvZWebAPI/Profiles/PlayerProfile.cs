using AutoMapper;
using HvZWebAPI.DTOs.Player;
using HvZWebAPI.DTOs.User;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles;

public class PlayerProfile : Profile
{
    public PlayerProfile()
    {
        CreateMap<Player, PlayeReadNonAdminDTO>();
        CreateMap<Player, PlayerReadAdminDTO>().ForMember(p=>p.UserDTO, opt => opt.MapFrom(new UserToPlayerReadResolver()));
        CreateMap<PlayerUpdateDeleteDTO, Player>();
        CreateMap<PlayerCreateDTO, Player>().ForMember(p => p.User, opt => opt.MapFrom(new UserResolver())); //opt => opt.Ignore()
        //CreateMap<PlayerCreateDTO, Player>().ForMember(p => p.User, opt => opt.MapFrom(new UserResolver())); //opt => opt.Ignore()
    }


}
