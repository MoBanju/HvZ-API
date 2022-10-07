using HvZWebAPI.Models;

namespace HvZWebAPI.DTOs.Chat;

public class ChatCreateDTO
{
        public string Message { get; set; }
        public DateTime ChatTime { get; set; }
        public bool IsHumanGlobal { get; set; }
        public bool IsZombieGlobal { get; set; }
        public int PlayerId { get; set; }

}