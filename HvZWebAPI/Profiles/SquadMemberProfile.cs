using AutoMapper;
using HvZWebAPI.DTOs.SquadMember;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles;

public class SquadMemberProfile : Profile
{

    public SquadMemberProfile()
    {
        CreateMap<SquadMemberCreateDTO, SquadMember>().ReverseMap();
    }

}
