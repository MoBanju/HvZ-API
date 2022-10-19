using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;

namespace HvZWebAPI.Interfaces;

public interface IGameRepository : IRepository<Game>
{

    public Task<IEnumerable<Game>> GetByState(State state);
}