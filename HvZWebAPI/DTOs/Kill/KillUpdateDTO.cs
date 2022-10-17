using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.Kill;

public class KillUpdateDTO
{
    public int Id { get; set; }
    public DateTime TimeDeath { get; set; }
    [MaxLength(FValid.PLAYER_BITECODE_MAXLENGTH)]
    public string Bitecode { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    [MaxLength(FValid.KILL_DESCRIPTION_MAXLENGTH)]
    [MinLength(FValid.KILL_DESCRIPTION_MINLENGTH)]
    public string? Description { get; set; }
}