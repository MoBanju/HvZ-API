using HvZWebAPI.Models;

namespace HvZWebAPI.Interfaces;

public interface IKillRepository : IRepository<Kill>
{

    public Task<IEnumerable<Kill>> GetAllByGameId(int gameId);
}