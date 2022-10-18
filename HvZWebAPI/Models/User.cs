using HvZWebAPI.Utils;
using System.ComponentModel.DataAnnotations;

namespace HvZWebAPI.Models;

public class User
{
    public int Id { get; set; }
    public string KeyCloakId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Navigation Properties
    public ICollection<Player>? Players { get; set; }
}
