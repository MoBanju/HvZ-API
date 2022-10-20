using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.SquadMember;

public class SquadMemberCreateDTO
{
    [MaxLength(FValid.SQUADMEMBER_RANK_MAXLENGTH), MinLength(FValid.SQUADMEMBER_RANK_MINLENGTH)]
    public string Rank { get; set; }

    public int PlayerId { get; set; }
}
