namespace HvZWebAPI.DTOs.SquadCheckin;

public class SquadCheckinReadDTO
{
    public int Id { get; set; }
    public DateTime Start_time { get; set; }
    public DateTime End_time { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

}
