using AutoMapper;
using HvZWebAPI.DTOs.Kill;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles;

public class KillProfile : Profile
{
    public KillProfile()
    {
        CreateMap<Kill, KillReadDTO>().ReverseMap();
        CreateMap<KillDeleteDTO, Kill>();
        CreateMap<KillUpdateDTO, Kill>();
        CreateMap<KillCreateDTO, Kill>();
    }


}