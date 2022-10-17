using HvZWebAPI.Models;
using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.Chat;

public class ChatCreateDTO
{
    [MaxLength(FValid.CHAT_MESSAGE_MAXLENGTH)]
    [Required]
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