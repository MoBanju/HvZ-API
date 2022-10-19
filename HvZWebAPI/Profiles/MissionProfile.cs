using AutoMapper;
using HvZWebAPI.DTOs.Game;
using HvZWebAPI.DTOs.Mission;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles;

public class MissionProfile : Profile
{


    public MissionProfile()
    {
        CreateMap<MissionCreateDTO, Mission>();
        CreateMap<Mission, MissionReadDTO>().ReverseMap();


    }



}
