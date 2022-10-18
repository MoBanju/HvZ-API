using Microsoft.AspNetCore.SignalR;

namespace HvZWebAPI.SignalRChat.Hubs;

/// <summary>
/// Manages connections groups and messaging
/// </summary>
public class ChatHub : Hub
{

    /// <summary>
    /// Can be called by a connected client to send a message to all clients
    /// setClientMessage is the part that the client listens to
    /// </summary>
    /// <param name="user"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task SendConnectionId(string cool) =>
            await Clients.All.SendAsync("setClientMessage", "A connection with ID '" + cool + "' has just connected");




}
