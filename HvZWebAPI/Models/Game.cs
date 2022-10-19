namespace HvZWebAPI.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
        public double Ne_lat { get; set; }
        public double Ne_lng { get; set; }
        public double Sw_lat { get; set; }
        public double Sw_lng { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // Navigation properties
        public ICollection<Kill> Kills { get; set; }

        public ICollection<Player>? Players { get; set; }

        public ICollection<Chat> Chats { get; set; }

        public ICollection<Mission>? Missions { get; set; }
    }

    public enum State
    {
        Registration,
        Progress,
        Complete
    }
}
