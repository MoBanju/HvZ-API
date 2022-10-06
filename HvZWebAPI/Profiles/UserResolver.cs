using AutoMapper;
using HvZWebAPI.DTOs.Player;
using HvZWebAPI.DTOs.User;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles;

public class UserResolver : IValueResolver<PlayerCreateDTO, Player, User>
{

    public User Resolve(PlayerCreateDTO source, Player destination, User destMember, ResolutionContext context)
    {
        User tempuser = new User();
        tempuser.FirstName = source.user.FirstName;
        tempuser.LastName = source.user.LastName;
        tempuser.Id = source.user.Id;


        return tempuser;

    }
    
}
