using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.Game;

public class GameCreateDTO
{
    [MaxLength(FValid.GAME_NAME_MAXLENGTH)]
    public string Name { get; set; }

    [MaxLength(FValid.GAME_DESCRIPTION_MAXLENGTH)]
    public string Description { get; set; }

    public double Ne_lat { get; set; }
    public double Ne_lng { get; set; }
    public double Sw_lat { get; set; }
    public double Sw_lng { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}