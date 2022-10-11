using AutoMapper;
using HvZWebAPI.DTOs.Kill;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles;

public class KillProfile : Profile
{
    public KillProfile()
    {
        CreateMap<Kill, KillCreateDTO>().ReverseMap();
        CreateMap<KillUpdateDeleteDTO, Kill>();
        CreateMap<KillCreateDTO, Kill>();
    }


}