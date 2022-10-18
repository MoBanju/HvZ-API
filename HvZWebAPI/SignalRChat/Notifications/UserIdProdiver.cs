using Microsoft.AspNetCore.SignalR;

namespace HvZWebAPI.SignalRChat.Notifications;

/// <summary>
/// Inbuilt signalR class
/// </summary>
public class UserIdProvider : IUserIdProvider
{
    public string? GetUserId(HubConnectionContext connection)
    {
        return connection.User.Identity.Name;
    }
}
