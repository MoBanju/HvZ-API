namespace HvZWebAPI.DTOs.Game;

public class GameCreateDTO
{
    public string Name { get; set; }
    public string Description { get; set; }

    public double Ne_lat { get; set; }
    public double Ne_lng { get; set; }
    public double Sw_lat { get; set; }
    public double Sw_lng { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}