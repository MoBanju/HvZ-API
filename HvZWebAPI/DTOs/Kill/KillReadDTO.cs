using HvZWebAPI.DTOs.PlayerKill;
using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.Kill;

public class KillReadDTO
{
    public int Id { get; set; }
    public DateTime TimeDeath { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    [MaxLength(FValid.KILL_DESCRIPTION_MAXLENGTH)]
    public string? Description { get; set; }

    public ICollection<PlayerKillReadDTO> PlayerKills { get; set; }
}