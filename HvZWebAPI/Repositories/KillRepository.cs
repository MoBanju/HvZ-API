using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HvZWebAPI.Repositories;

public class KillRepository : IKillRepository
{
    private readonly HvZDbContext _context;
    private readonly IPlayerRepository _playerRepository;

    public KillRepository(HvZDbContext context, IPlayerRepository playerRepository)
    {
        _context = context;
        _playerRepository = playerRepository;
    }
    public async Task<Kill?> Add(int game_id, Kill kill, string bitecode)
    {
        if (!GameExists(game_id)) throw new ArgumentException("Game by that id does not exsist");


        _context.Kills.Add(kill);
        int rowsAffected = await _context.SaveChangesAsync();
        if(rowsAffected == 0)
            return null;
        return kill;
    }

    public async Task Delete(int game_id, int kill_id)
    {
        int rowsChanged = 0;
        try
        {
            var kill = await FindKillInGame(game_id, kill_id);

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

    public async Task<IEnumerable<Kill>> GetAllByGameId(int game_id)
    {
        if (!GameExists(game_id)) throw new ArgumentException("Game by that id does not exsist");

        return await _context.Kills.Include(k => k.Game).Where(k => k.GameId == game_id).ToListAsync();
    }

    public async Task<Kill> GetById(int game_id, int kill_id)
    {
        Kill kill = await FindKillInGame(game_id, kill_id);
        return kill;
    }

    public async Task Update(int game_id, Kill kill)
    {
        try
        {
            var exsistingKill = await FindKillInGame(game_id, kill.Id);
            if (exsistingKill != null)
            {
                //This sets the foreign keys
                _context.Entry(exsistingKill).State = EntityState.Detached;
                //kill.KillerId = exsistingKill.KillerId;
                //kill.VictimId = exsistingKill.VictimId;
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

    /// <summary>
    /// Used to retrieve the player that fits the combination of game id and player id
    /// This is the main validation method, returning argument exceptions
    /// </summary>
    /// <param name="game_id">Specific Game</param>
    /// <param name="kill_id">Specific Kill</param>
    /// <returns>A Kill from the context or database</returns>
    /// <exception cref="ArgumentException">When the game or kill does not exist, or the game id from kill is different from the param game_id</exception>

    private async Task<Kill> FindKillInGame(int game_id, int kill_id)
    {
        if (!GameExists(game_id)) throw new ArgumentException("There is no game with that id");

        Kill? kill = await _context.Kills.Include(k => k.Game).FirstOrDefaultAsync(k => k.Id == kill_id);
        if (kill == null)
        {
            throw new ArgumentException("There is no kill with that id");
        }

        if (kill.GameId != game_id)
        {
            throw new ArgumentException("The kill-id you sent in is not in the game you sent in");
        }

        return kill;
    }


    /// <summary>
    /// Checks if the game is tracked in the context
    /// </summary>
    /// <param name="game_id">Specific Game</param>
    /// <returns>Existent game</returns>
    private bool GameExists(int game_id)
    {
        return _context.Games.Any(e => e.Id == game_id);
    }

    /// <summary>
    /// Checks if the kill is tracked in context
    /// </summary>
    /// <param name="kill_id">Kill Id</param>
    /// <returns>Returns the existent kill</returns>
    private bool KillExists(int kill_id)
    {
        return _context.Kills.Any(e => e.Id == kill_id);
    }


}
