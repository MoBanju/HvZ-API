using HvZWebAPI.Models;

namespace HvZWebAPI.Interfaces;

public interface IChatRepository
{
    /// <summary>
    /// Adds a chat message to the given game.
    /// </summary>
    /// <param name="gameId"></param>
    /// <param name="chat"></param>
    /// <exception cref="ArgumentException">When game is not found or the player sending the message is not in the game</exception>
    /// <returns>A boolean indicating success</returns>
    public Task<Chat> PostChat(int gameId, Chat chat);

    /// <summary>
    /// Gets a list of chat messages for a given game.
    /// </summary>
    /// <param name="gameId">Id of game you want to get message from</param>
    /// <exception cref="ArgumentException">When game is not found</exception>
    /// <returns>A list of Chat messages beloning to given game</returns>
    public Task<IEnumerable<Chat>> GetChats(int gameId);

   
    /// <summary>
    /// Gets a chat in the given game with the given chat id
    /// </summary>
    /// <param name="gameId"></param>
    /// <param name="chat_id"></param>
    /// <exception cref="ArgumentException">When game is not found</exception>
    /// <returns>chat object or null if the chat was not in the game specified</returns>
    public Task<Chat?> GetChat(int gameId, int chat_id);


}