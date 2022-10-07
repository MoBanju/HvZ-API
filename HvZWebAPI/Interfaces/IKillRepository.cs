using HvZWebAPI.Models;

namespace HvZWebAPI.Interfaces;

public interface IKillRepository
{
    public Task<Kill> GetById(int id);
    public Task<IEnumerable<Kill>> GetAll();
    public Task<Kill?> Add(Kill kill);
    public Task<bool> Update(Kill kill);
    public Task<bool> Delete(Kill kill);
}