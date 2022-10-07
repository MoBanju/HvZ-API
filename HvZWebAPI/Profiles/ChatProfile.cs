
using AutoMapper;
using HvZWebAPI.DTOs.Chat;
using HvZWebAPI.Models;

namespace HvZWebAPI.Profiles;

public class ChatProfile : Profile
{
    public ChatProfile()
    {
        CreateMap<Chat, ChatReadDTO>();
        CreateMap<ChatCreateDTO, Chat>();
    }


}