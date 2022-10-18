using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.Kill;

public class KillUpdateDTO
{
    [Required]
    public int? Id { get; set; }
    [Required]
    public DateTime? TimeDeath { get; set; }
    [Required]
    [MaxLength(FValid.PLAYER_BITECODE_MAXLENGTH), MinLength(FValid.PLAYER_BITECODE_MINLENGTH)]
    public string Bitecode { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    [MaxLength(FValid.KILL_DESCRIPTION_MAXLENGTH)]
    [MinLength(FValid.KILL_DESCRIPTION_MINLENGTH)]
    public string? Description { get; set; }
}