using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace HvZWebAPI.DTOs.Squad;

public class SquadUpdateDTO
{
    public int Id { get; set; }

    [Required]
    [MaxLength(FValid.SQUAD_NAME_MAXLENGTH), MinLength(FValid.SQUAD_NAME_MINLENGTH)]
    public string Name { get; set; }

    public bool Is_human { get; set; }
}
