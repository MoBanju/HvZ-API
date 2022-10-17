using HvZWebAPI.Models;
using Microsoft.Build.Framework;

namespace HvZWebAPI.DTOs.Chat;

public class ChatCreateDTO
{
    public string Message { get; set; }
    [Required]
    public DateTime? ChatTime { get; set; }
    [Required]
    public bool? IsHumanGlobal { get; set; }
    [Required]
    public bool? IsZombieGlobal { get; set; }
    [Required]
    public int? PlayerId { get; set; }

}