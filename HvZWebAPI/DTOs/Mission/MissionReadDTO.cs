namespace HvZWebAPI.DTOs.Mission;

public class MissionReadDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Is_human_visible { get; set; }
    public bool Is_zombie_visible { get; set; }
    public string Description { get; set; }
    public DateTime Start_time { get; set; }
    public DateTime End_time { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
