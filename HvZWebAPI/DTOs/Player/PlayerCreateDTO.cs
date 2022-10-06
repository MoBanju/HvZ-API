using HvZWebAPI.DTOs.User;
using HvZWebAPI.Models;

namespace HvZWebAPI.DTOs.Player;
public class PlayerCreateDTO
{
    public bool IsPatientZero { get; set; }
    public bool IsHuman { get; set; }
    public string BiteCode { get; set; }
    public UserCreateDTO user { get; set; }


}
