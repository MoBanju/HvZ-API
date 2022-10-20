using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.Mission;

public class MissionCreateDTO
{
    [Required]
    [MinLength(FValid.MISSION_NAME_MINLENGTH), MaxLength(FValid.MISSION_NAME_MAXLENGTH)]
    public string Name { get; set; }
    [Required]
    public bool? Is_human_visible { get; set; }
    [Required]
    public bool? Is_zombie_visible { get; set; }

    [MinLength(FValid.MISSION_DESCRIPTION_MINLENGTH), MaxLength(FValid.MISSION_DESCRIPTION_MAXLENGTH)]
    public string? Description { get; set; }

    [Required]
    public DateTime Start_time { get; set; }
    [Required]
    public DateTime End_time { get; set; }
    
    [Required]
    public double? Latitude { get; set; }
    [Required]
    public double? Longitude { get; set; }

}
