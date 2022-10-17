namespace HvZWebAPI.DTOs.Kill;

public class KillDeleteDTO
{
    public int Id { get; set; }
    public DateTime TimeDeath { get; set; }
    public int PlayerId { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Description { get; set; }
}