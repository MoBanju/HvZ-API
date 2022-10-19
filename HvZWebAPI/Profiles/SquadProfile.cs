using AutoMapper;
using HvZWebAPI.DTOs.Squad;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles;

public class SquadProfile : Profile
{
    public SquadProfile()
    {
        CreateMap<SquadCreateDTO, Squad>().ReverseMap();
        CreateMap<Squad, SquadReadDTO>();
        CreateMap<SquadUpdateDTO, Squad>();
        CreateMap<SquadDeleteDTO, Squad>();
    }


}
