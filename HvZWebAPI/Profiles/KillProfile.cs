using AutoMapper;
using HvZWebAPI.DTOs.Kill;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles;

public class KillProfile : Profile
{
    public KillProfile()
    {
        CreateMap<Kill, KillReadDTO>().ReverseMap();
        CreateMap<KillUpdateDeleteDTO, Kill>();
        CreateMap<KillCreateDTO, Kill>();
    }


}