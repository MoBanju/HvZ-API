namespace HvZWebAPI.Models;

public class SquadMember
{
    public int Id { get; set; }
    public string Rank { get; set; }

    //nav properties
    public Game Game { get; set; }
    public int GameId { get; set; }

    public Player Player { get; set; }
    public int PlayerId { get; set; }

    public Squad Squad { get; set; }
    public int SquadId { get; set; }

    public ICollection<SquadCheckin> Squad_Checkins { get; set; }

}
