namespace HvZWebAPI.DTOs.Kill;

public class KillUpdateDTO
{
    public int Id { get; set; }
    public DateTime TimeDeath { get; set; }
    public string Bitecode { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Description { get; set; }
}