namespace HvZWebAPI.Models;


/// <summary>
/// Is in a game
/// Represents a member meetup point on the map for people of that squad
/// The meeting point is made for a squad, each squad can make many of these meetpoints
/// There is going to be one living squad member that made the checkpoint 
/// </summary>
public class SquadCheckin
{
    public int Id { get; set; }
    public DateTime Start_time { get; set; }
    public DateTime End_time { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    //Nav properties
    public Game Game { get; set; }
    public int GameId { get; set; }

    public Squad Squad { get; set; }
    public int SquadId { get; set; }

    public SquadMember Squad_Member { get; set; }
    public int Squad_MemberId { get; set; }

}
