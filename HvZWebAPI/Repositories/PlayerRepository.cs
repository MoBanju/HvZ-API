using HvZWebAPI.Data;
using HvZWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HvZWebAPI.Repositories;

public class PlayerRepository : IPlayerRepository
{
    public HvZDbContext _context;

    public PlayerRepository(HvZDbContext context)
    {
        _context = context;
    }


    public async Task<bool> Add(Player entity)
    {
        _context.Players.Add(entity);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        return true;

    }

    public Task<Task> Delete(Player entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Player>> GetAll()
    {
       return await _context.Players.ToListAsync();
    }

    public Task<Player> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Player entity)
    {
        throw new NotImplementedException();
    }
}
