namespace HvZWebAPI.DTOs.Kill;

public class KillCreateDTO
{
    public DateTime TimeDeath { get; set; }
    public int KillerId { get; set; }
    public string BiteCode { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Description { get; set; }


}