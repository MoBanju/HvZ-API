using HvZWebAPI.Models;

namespace HvZWebAPI.Interfaces;

public interface IKillRepository //: IRepository<Kill>
{

    public Task<IEnumerable<Kill>> GetAllByGameId(int gameId);
    public Task<Kill> GetById(int gameId, int killId);
    public Task<IEnumerable<Kill>> GetAll();
    public Task<Kill?> Add(int gameId, Kill entity);
    public Task Update(int gameId, Kill entity);
    public Task Delete(int gameId, int killId);


    // public Task<Kill> GetByGameId(int killId, int gameId);
}