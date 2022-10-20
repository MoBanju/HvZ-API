using AutoMapper;
using HvZWebAPI.DTOs.SquadCheckin;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles;

public class SquadCheckinProfile : Profile
{

    public SquadCheckinProfile()
    {
        CreateMap<SquadCheckin, SquadCheckinReadDTO>();
        CreateMap<SquadCheckinCreateDTO, SquadCheckin>();


    }

}
