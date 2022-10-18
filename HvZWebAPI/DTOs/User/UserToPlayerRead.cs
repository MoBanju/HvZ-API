using AutoMapper;
using HvZWebAPI.DTOs.Player;

namespace HvZWebAPI.DTOs.User;

public class UserToPlayerReadResolver : IValueResolver<Models.Player, PlayerReadAdminDTO, UserReadAdminDTO>
{
    

    public UserReadAdminDTO Resolve(Models.Player source, PlayerReadAdminDTO destination, UserReadAdminDTO destMember, ResolutionContext context)
    {
        var userDTO = new UserReadAdminDTO();
        userDTO.FirstName = (source.User.FirstName)??"";
        userDTO.LastName = (source.User.LastName)??"";
        userDTO.KeyCloakId = source.User.KeyCloakId;
        return userDTO;
    }

 
}
