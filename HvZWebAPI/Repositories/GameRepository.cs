using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
using HvZWebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace HvZWebAPI.Repositories;


public class GameRepository : IGameRepository
{
    private readonly HvZDbContext _context;
    private readonly ISquadRepository _squadRepository;

    public GameRepository(HvZDbContext context, ISquadRepository squadRepository)
    {
        _context = context;
        _squadRepository = squadRepository;
    }

    public async Task<bool> Update(Game entity)
    {
        if (CheckCoord(entity)) throw new ArgumentException(ErrorCategory.COORDINATES());
        _context.Entry(entity).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<IEnumerable<Game>> GetAll()
    {
        return await _context.Games.Include(g=>g.Players).ToListAsync();
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
            .Include(g => g.Squads)
            .FirstOrDefaultAsync();

        if(game is null)
            return false;


        foreach(var squad in game.Squads) {
            await _squadRepository.Delete(game.Id, squad.Id);
        }

        _context.RemoveRange(game.Players);

        _context.Remove(game);
        return await _context.SaveChangesAsync() > 0;
    }

    async Task<Game?>  IRepository<Game>.Add(Game entity)
    {
        if (CheckCoord(entity)) throw new ArgumentException(ErrorCategory.COORDINATES());
        _context.Games.Add(entity);
        int rowsAffected = await _context.SaveChangesAsync();

        if (rowsAffected == 0) return null;
        
        return entity;
    }

    public async Task<IEnumerable<Game>> GetByState(State state)
    {
        return await _context.Games.Include(g => g.Players).Where(g => g.State == state).ToListAsync();
    }

    private bool CheckCoord(Game entity)
    {
        return entity.Ne_lat <= entity.Sw_lat || entity.Ne_lng <= entity.Sw_lng;
    }
}