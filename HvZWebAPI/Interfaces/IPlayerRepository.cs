using HvZWebAPI.Models;

namespace HvZWebAPI.Interfaces;

public interface IPlayerRepository
{

    /// <summary>
    /// Add a player to the database, and also it's associated user if it's not allready in the database.
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Thrown when the game_id provided does not exist</exception>
    public Task<Player?> Add(int game_id, Player player);

    /// <summary>
    /// Returns a list of all the players with a given game_id
    /// </summary>
    /// <param name="game_id"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Thrown when the game_id provided does not exist</exception>
    public Task<IEnumerable<Player>> GetAll(int game_id);

    /// <summary>
    /// Returns a given player by id in a given game
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="player_id"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">When there are problems with the player_id, game_id or the combination of them</exception>
    public Task<Player> GetById(int game_id, int player_id);

    /// <summary>
    /// Returns a given player by bitecode in a given game
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="biteCode"></param>
    /// <returns></returns>
    public Task<Player> GetByBiteCode(int game_id, string biteCode);
    
    /// <summary>
    /// Updates a player object
    /// NB: does not update the associated user object
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">When there are problems with the player_id, game_id or the combination of them</exception>
    public Task<bool> Update(int game_id, Player player);

    /// <summary>
    /// Deletes only the playerobject from the database
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="player_id"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">When there are problems with the player_id, game_id or the combination of them</exception>
    public Task<bool> Delete(int game_id, int player_id);

}
