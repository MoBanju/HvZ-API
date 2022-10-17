using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.User;

public class UserCreateDTO
{
    [MaxLength(FValid.USER_KEYCLOAK_ID_MAXLENGTH)]
    [Required]
    public string KeyCloakId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }


}
