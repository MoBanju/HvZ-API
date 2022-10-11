using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HvZWebAPI.Repositories;

public class KillRepository : IKillRepository
{
    private readonly HvZDbContext _context;

    public KillRepository(HvZDbContext context)
    {
        _context = context;
    }
    public async Task<Kill?> Add(int gameId, Kill kill)
    {
        if (!GameExists(gameId)) throw new ArgumentException("Game by that id does not exsist");
        _context.Kills.Add(kill);
        int rowsAffected = await _context.SaveChangesAsync();
        if(rowsAffected == 0)
            return null;
        return kill;
    }

    public async Task Delete(int gameId, int killId)
    {
        int rowsChanged = 0;
        try
        {
            var kill = await FindKillInGame(gameId, killId);

            _context.Kills.Remove(kill);

            rowsChanged = await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw;
        }

    }

    public async Task<IEnumerable<Kill>> GetAll()
    {
        return await _context.Kills.Include(g => g.Game).ToListAsync();
    }

    public async Task<IEnumerable<Kill>> GetAllByGameId(int gameId)
    {
        if (!GameExists(gameId)) throw new ArgumentException("Game by that id does not exsist");

        return await _context.Kills.Include(k => k.Game).Where(k => k.GameId == gameId).ToListAsync();
    }

    public async Task<Kill> GetById(int gameId, int killId)
    {
        Kill kill = await FindKillInGame(gameId, killId);
        return kill;
    }

    public async Task Update(int gameId, Kill kill)
    {
        try
        {
            var exsistingKill = await FindKillInGame(gameId, kill.Id);
            if (exsistingKill != null)
            {
                //This sets the foreign keys
                _context.Entry(exsistingKill).State = EntityState.Detached;
                kill.KillerId = exsistingKill.KillerId;
                kill.VictimId = exsistingKill.VictimId;
                kill.GameId = exsistingKill.GameId;
            }

            _context.Update(kill);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

    }

    private async Task<Kill> FindKillInGame(int gameId, int killId)
    {
        if (!GameExists(gameId)) throw new ArgumentException("There is no game with that id");

        Kill? kill = await _context.Kills.Include(k => k.Game).FirstOrDefaultAsync(k => k.Id == killId);
        if (kill == null)
        {
            throw new ArgumentException("There is no kill with that id");
        }

        if (kill.GameId != gameId)
        {
            throw new ArgumentException("The kill-id you sent in is not in the game you sent in");
        }

        return kill;
    }


    /// <summary>
    /// Checks if the game is tracked in the context
    /// </summary>
    /// <param name="gameId"></param>
    /// <returns></returns>
    private bool GameExists(int gameId)
    {
        return _context.Games.Any(e => e.Id == gameId);
    }

    /// <summary>
    /// Checks if the player is tracked in context
    /// </summary>
    /// <param name="killId"></param>
    /// <returns></returns>
    private bool KillExists(int killId)
    {
        return _context.Kills.Any(e => e.Id == killId);
    }


}
