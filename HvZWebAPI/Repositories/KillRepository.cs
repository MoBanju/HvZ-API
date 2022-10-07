using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;

namespace HvZWebAPI.Repositories;

public class KillRepository : IKillRepository
{
    private readonly HvZDbContext _context;

    public KillRepository(HvZDbContext context)
    {
        _context = context;
    }
    public async Task<Kill?> Add(Kill kill)
    {
        _context.Kills.Add(kill);
        int rowsAffected = await _context.SaveChangesAsync();
        if(rowsAffected == 0)
            return null;
        return kill;
    }

    public async Task<bool> Delete(Kill kill)
    {
        _context.Kills.Remove(kill);
        int rowsAffected = await _context.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public Task<IEnumerable<Kill>> GetAll()
    {
    }

    public Task<Kill> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Kill kill)
    {
        throw new NotImplementedException();
    }
}
