namespace HvZWebAPI.Models;

public class Squad
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool Is_human { get; set; }

    //Nav properties
    public Game Game { get; set; }
    public int GameId { get; set; }

    public ICollection<SquadMember> Squad_Members{ get; set; }

    public ICollection<SquadCheckin>? Squad_Checkins { get; set; }

    public ICollection<Chat>? Chats { get; set; }
}
