using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.DTOs.User;

public class UserCreateDTO
{
    [MaxLength(FValid.USER_KEYCLOAK_ID_MAXLENGTH), MinLength(FValid.USER_KEYCLOAK_ID_MINLENGTH)]
    [Required]
    public string KeyCloakId { get; set; }
    [MaxLength(FValid.USER_FIRSTNAME_MAXLENGTH), MinLength(FValid.USER_FIRSTNAME_MINLENGTH)]
    public string? FirstName { get; set; }
    [MaxLength(FValid.USER_LASTNAME_MAXLENGTH), MinLength(FValid.USER_LASTNAME_MINLENGTH)]
    public string? LastName { get; set; }


}
