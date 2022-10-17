using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.Player;

public class PlayerUpdateDeleteDTO
{
    [Required]
    public int? Id { get; set; }
    [Required]
    public bool? IsHuman { get; set; }
    
    [Required, MaxLength(FValid.PLAYER_BITECODE_MAXLENGTH), MinLength(FValid.PLAYER_BITECODE_MINLENGTH)]
    public string BiteCode { get; set; }
    [Required]
    public Boolean? IsPatientZero { get; set; }
}
