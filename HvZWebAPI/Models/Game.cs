namespace HvZWebAPI.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        // Navigation properties

        public ICollection<Kill> Kills { get; set; }

        public ICollection<Player> Players { get; set; }

        public ICollection<Chat> Chats { get; set; }

    }
}
