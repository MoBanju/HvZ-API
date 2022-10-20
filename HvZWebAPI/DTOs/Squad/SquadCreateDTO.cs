using HvZWebAPI.DTOs.SquadMember;
using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.Squad;

public class SquadCreateDTO
{

    [Required]
    [MaxLength(FValid.SQUAD_NAME_MAXLENGTH), MinLength(FValid.SQUAD_NAME_MINLENGTH)]
    public string Name { get; set; }

    public bool Is_human { get; set; }

    public SquadMemberCreateDTO SquadMember { get; set; }
}
