using HvZWebAPI.Models;

namespace HvZWebAPI.Interfaces;

public interface IPlayerRepository
{

    public Task<Player> GetById(int game_id, int player_id);
    public Task<IEnumerable<Player>> GetAll(int game_id);
    public Task<Player?> Add(int game_id, Player entity);
    public Task Update(int game_id, Player entity);
    public Task Delete(int game_id, int player_id);


}
