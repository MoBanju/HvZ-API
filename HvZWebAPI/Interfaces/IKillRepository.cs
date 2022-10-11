using HvZWebAPI.Models;

namespace HvZWebAPI.Interfaces;

public interface IKillRepository
{
    /// <summary>
    /// Returns all the kills from specific game
    /// </summary>
    /// <param name="gameId">Specific Game</param>
    /// <returns>All kills</returns>
    public Task<IEnumerable<Kill>> GetAllByGameId(int gameId);

    /// <summary>
    /// Returns specific kill from specific game
    /// </summary>
    /// <param name="gameId">Specific Game</param>
    /// <param name="killId">Specific Kill</param>
    /// <returns>Kill</returns>
    public Task<Kill> GetById(int gameId, int killId);

    /// <summary>
    /// Returns all the kills from all games
    /// </summary>
    /// <returns>Kills</returns>
    public Task<IEnumerable<Kill>> GetAll();

    /// <summary>
    /// It adds a kill in  database
    /// </summary>
    /// <param name="gameId">Specific Game</param>
    /// <param name="kill">new Kill</param>
    /// <returns>Kill that was created</returns>
    public Task<Kill?> Add(int gameId, Kill kill);

    /// <summary>
    /// Updates the kill
    /// </summary>
    /// <param name="gameId">Specific Game</param>
    /// <param name="kill">Kill in update</param>
    /// <returns>Either the changes are saved or the error is throwed</returns>
    public Task Update(int gameId, Kill kill);

    /// <summary>
    /// Deletes the kill
    /// </summary>
    /// <param name="gameId">Specific Game</param>
    /// <param name="killId">Kill Id</param>
    /// <returns>Either the changes are saved or the error is throwed</returns>
    public Task Delete(int gameId, int killId);
}