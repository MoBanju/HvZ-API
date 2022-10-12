namespace HvZWebAPI.Models
{
    public class Kill
    {
        public int Id { get; set; }
        public DateTime TimeDeath { get; set; }

        // Navigation Properties
        public Game Game { get; set; }
        public int GameId { get; set; }

        public ICollection<PlayerKill> PlayerKills { get; set; }
    }
}
