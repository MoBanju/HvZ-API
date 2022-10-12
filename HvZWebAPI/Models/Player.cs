namespace HvZWebAPI.Models
{
    public class Player
    {
        public int Id { get; set; }

        public bool IsPatientZero { get; set; }
        public bool IsHuman { get; set; }
        public string BiteCode { get; set; }
        
        // Navigation Properties
        public User User { get; set; }
        public int UserId { get; set; }

        public Game Game{ get; set; }
        public int GameId { get; set; }
        public ICollection<Chat> Chats { get; set; }

        public ICollection<PlayerKill> PlayerKills { get; set; }



    }
}
