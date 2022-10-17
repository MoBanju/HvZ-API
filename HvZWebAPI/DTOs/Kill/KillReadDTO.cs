using HvZWebAPI.DTOs.PlayerKill;

namespace HvZWebAPI.DTOs.Kill;

public class KillReadDTO
{
    public int Id { get; set; }
    public DateTime TimeDeath { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Description { get; set; }

    public ICollection<PlayerKillReadDTO> PlayerKills { get; set; }
}