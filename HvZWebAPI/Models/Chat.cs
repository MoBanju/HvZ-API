namespace HvZWebAPI.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public DateTime ChatTime { get; set; }

        public bool IsHumanGlobal { get; set; }
        public bool IsZombieGlobal { get; set; }

        // Navigation Properties

        public Game Game { get; set; }
        public int GameId { get; set; }
        

        public Player Player { get; set; }
        public int PlayerId { get; set; }


        public Squad? Squad { get; set; }
        public int? SquadId { get; set; }
    }
}
