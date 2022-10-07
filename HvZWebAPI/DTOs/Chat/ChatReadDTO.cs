namespace HvZWebAPI.DTOs.Chat;

public class ChatReadDTO
{
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime ChatTime { get; set; }
        public bool IsHumanGlobal { get; set; }
        public bool IsZombieGlobal { get; set; }
        public int PlayerId { get; set; }

}