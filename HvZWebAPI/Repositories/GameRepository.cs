using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HvZWebAPI.Repositories;


public class GameRepository : IGameRepository
{
    private readonly HvZDbContext _context;

    public GameRepository(HvZDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Update(Game entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<IEnumerable<Game>> GetAll()
    {
        return await _context.Games.ToListAsync();
    }
    public async Task<Game?> GetById(int id)
    {
        return await _context.Games
            .FirstOrDefaultAsync(game => game.Id == id);
    }
    public async Task<bool> Delete(int id)
    {
        Game? game = await _context.Games.Where(g => g.Id == id)
            .Include(g => g.Players)
            .FirstOrDefaultAsync();

        if(game is null)
            return false;

        _context.RemoveRange(game.Players);
        _context.Remove(game);
        return await _context.SaveChangesAsync() > 0;
    }

    async Task<Game?>  IRepository<Game>.Add(Game entity)
    {
        _context.Games.Add(entity);
        int rowsAffected = await _context.SaveChangesAsync();

        if (rowsAffected == 0) return null;
        
        return entity;
    }
}