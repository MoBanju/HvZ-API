using HvZWebAPI.DTOs.SquadMember;

namespace HvZWebAPI.DTOs.Squad;

public class SquadReadDTO
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool Is_human { get; set; }

    public int DeseasedPlayers { get; set; }


    public ICollection<SquadMemberReadDTO> Squad_Members { get; set; }

}
