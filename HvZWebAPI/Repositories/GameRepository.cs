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

    public async Task<bool> Add(Game entity)
    {
        _context.Games.Add(entity);
        return await _context.SaveChangesAsync() > 0;
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
        Game? game = await _context.Games.FindAsync(id);

        if(game is null)
            return false;

        _context.Remove(game);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Game entity)
    {
        Game? game = await _context.Games.FindAsync(entity.Id);
        
        if(game is null)
            return false;
        
        int rowsAffected = await _context.SaveChangesAsync();

        return rowsAffected > 0;
    }
}