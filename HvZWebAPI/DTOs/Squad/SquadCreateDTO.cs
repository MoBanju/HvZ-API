using HvZWebAPI.DTOs.SquadMember;

namespace HvZWebAPI.DTOs.Squad;

public class SquadCreateDTO
{

    public string Name { get; set; }

    public bool Is_human { get; set; }

    public SquadMemberCreateDTO SquadMember { get; set; }
}
