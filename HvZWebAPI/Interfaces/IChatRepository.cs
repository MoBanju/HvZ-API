using HvZWebAPI.Models;

namespace HvZWebAPI.Interfaces;

public interface IChatRepository
{
    /// <summary>
    /// Gets a list of chat messages for a given game.
    /// </summary>
    /// <param name="gameId">Id of game you want to get message from</param>
    /// <returns>A list of Chat messages beloning to given game</returns>
    public Task<IEnumerable<Chat>> GetChats(int gameId);
    /// <summary>
    /// Adds a chat message to the given game.
    /// </summary>
    /// <param name="gameId"></param>
    /// <param name="chat"></param>
    /// <exception cref="ArgumentException">When game is not found or player id is not part of game.</exception>
    /// <returns>A boolean indicating success</returns>
    public Task<Chat> PostChat(int gameId, Chat chat);

    public Task<Chat?> GetChat(int gameId, int chat_id);
}