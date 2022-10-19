using HvZWebAPI.Models;
using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.Game;

public class GameUpdateDeleteDTO
{
    [Required(ErrorMessage = "Game Id is required")]
    public int? Id { get; set; }

    [Required(ErrorMessage = "Game name is required")]
    [MaxLength(FValid.GAME_NAME_MAXLENGTH), MinLength(FValid.GAME_NAME_MINLENGTH)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Game description is required")]
    [MaxLength(FValid.GAME_DESCRIPTION_MAXLENGTH)]
    public string Description { get; set; }
    
    public State State { get; set; }

    public double Ne_lat { get; set; }
    public double Ne_lng { get; set; }
    public double Sw_lat { get; set; }
    public double Sw_lng { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}