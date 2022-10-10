using HvZWebAPI.DTOs.User;

namespace HvZWebAPI.DTOs.Player;

public class PlayerReadAdminDTO
{
    public int Id { get; set; }

    public Boolean? IsPatientZero { get; set; }
    public bool IsHuman { get; set; }
    public string BiteCode { get; set; }
    public UserCreateDTO User { get; set; }

}
