using HvZWebAPI.DTOs.User;
using HvZWebAPI.Models;
using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.Player;
public class PlayerCreateDTO
{
    [Required(ErrorMessage = "PatientZero has to be set")]
    public bool? IsPatientZero { get; set; }
    [Required]
    public bool? IsHuman { get; set; }
    [Required]
    [MaxLength(FValid.PLAYER_BITECODE_MAXLENGTH)]
    [MinLength(FValid.PLAYER_BITECODE_MINLENGTH)]
    public string BiteCode { get; set; }
    public UserCreateDTO user { get; set; }


}
