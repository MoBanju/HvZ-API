
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.Game;

public class GameCreateDTO
{
    public string Name { get; set; }
    
    public string Description { get; set; }

    [Required]
    public double? Ne_lat { get; set; }
    [Required]
    public double? Ne_lng { get; set; }
    [Required]
    public double? Sw_lat { get; set; }
    [Required]
    public double? Sw_lng { get; set; }

    [Required]
    public DateTime? StartTime { get; set; }

    [Required]
    public DateTime? EndTime { get; set; }
}