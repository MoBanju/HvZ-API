using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.Models;

public class User
{
    public int Id { get; set; }
    [MaxLength(FValid.USER_KEYCLOAK_ID_MAXLENGTH)]
    public string KeyCloakId { get; set; }
    [MaxLength(FValid.USER_FIRSTNAME_MAXLENGTH)]
    public string FirstName { get; set; }
    [MaxLength(FValid.USER_LASTNAME_MAXLENGTH)]
    public string LastName { get; set; }

    // Navigation Properties
    public ICollection<Player>? Players { get; set; }
}
