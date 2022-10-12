namespace HvZWebAPI.DTOs.User;

public class UserCreateDTO
{
    public int Id { get; set; }
    public string KeyCloakId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }


}
