using HvZWebAPI.Models;

namespace HvZWebAPI.Interfaces;

public interface IKillRepository
{
    /// <summary>
    /// Returns all the kills from specific game
    /// </summary>
    /// <param name="game_id">Specific Game</param>
    /// <returns>All kills</returns>
    public Task<IEnumerable<Kill>> GetAllByGameId(int game_id);

    /// <summary>
    /// Returns specific kill from specific game
    /// </summary>
    /// <param name="game_id">Specific Game</param>
    /// <param name="kill_id">Specific Kill</param>
    /// <returns>Kill</returns>
    public Task<Kill> GetById(int game_id, int kill_id);

    /// <summary>
    /// Returns all the kills from all games
    /// </summary>
    /// <returns>Kills</returns>
    public Task<IEnumerable<Kill>> GetAll();

    /// <summary>
    /// It adds a kill in  database
    /// </summary>
    /// <param name="game_id">Specific Game</param>
    /// <param name="kill">new Kill</param>
    /// <returns>Kill that was created</returns>
    public Task<Kill?> Add(int game_id, Kill kill);

    /// <summary>
    /// Updates the kill
    /// </summary>
    /// <param name="game_id">Specific Game</param>
    /// <param name="kill">Kill in update</param>
    /// <returns>Either the changes are saved or the error is throwed</returns>
    public Task Update(int game_id, Kill kill);

    /// <summary>
    /// Deletes the kill
    /// </summary>
    /// <param name="game_id">Specific Game</param>
    /// <param name="kill_id">Kill Id</param>
    /// <returns>Either the changes are saved or the error is throwed</returns>
    public Task Delete(int game_id, int kill_id);
}