using AutoMapper;
using HvZWebAPI.DTOs.Player;

namespace HvZWebAPI.DTOs.User;

public class UserToPlayerReadResolver : IValueResolver<Models.Player, PlayerReadAdminDTO, UserCreateDTO>
{
    

    public UserCreateDTO Resolve(Models.Player source, PlayerReadAdminDTO destination, UserCreateDTO destMember, ResolutionContext context)
    {
        var userDTO = new UserCreateDTO();
        userDTO.FirstName = source.User.FirstName;
        userDTO.LastName = source.User.LastName;
        userDTO.Id = source.User.Id;
        return userDTO;
    }
}
