using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.Game;

public class GameCreateDTO
{
    [Required]
    [MaxLength(FValid.GAME_NAME_MAXLENGTH), MinLength(FValid.GAME_NAME_MINLENGTH)]
    public string Name { get; set; }

    [Required]
    [MaxLength(FValid.GAME_DESCRIPTION_MAXLENGTH), MinLength(FValid.GAME_DESCRIPTION_MINLENGTH)]
    public string Description { get; set; }

    public double Ne_lat { get; set; }
    public double Ne_lng { get; set; }
    public double Sw_lat { get; set; }
    public double Sw_lng { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}