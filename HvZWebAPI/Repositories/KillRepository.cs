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
    public async Task<Kill?> Add(int game_id, Kill kill, string bitecode, int killer_id)
    {
        if (!GameExists(game_id)) throw new ArgumentException("Game by that id does not exsist");


        // Victim and Killer in the same game

        Player victim = await _playerRepository.GetByBiteCode(game_id, bitecode);
        victim.IsHuman = false;

        _context.Entry(victim).State = EntityState.Modified;

        var pk1 = new PlayerKill() { KillId = kill.Id, PlayerId = victim.Id, IsVictim = true };
        var pk2 = new PlayerKill() { KillId = kill.Id, PlayerId = killer_id, IsVictim = false };

        kill.PlayerKills = new List<PlayerKill>();
        kill.PlayerKills.Add(pk1);
        kill.PlayerKills.Add(pk2);

        _context.Kills.Add(kill);


        int rowsAffected = await _context.SaveChangesAsync();
        if (rowsAffected == 0)
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



        return await _context.Kills.Where(k => k.GameId == game_id).Include(k=>k.PlayerKills).ToListAsync();
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
                PlayerKill epkVictim = exsistingKill.PlayerKills.Where(pk => pk.IsVictim == true).FirstOrDefault();
                //Player existingVictim = ;
                int exVictimId = _playerRepository.GetById(game_id, epkVictim.PlayerId).Id;/*existingVictim.Id*/;

                //This sets the foreign keys
                _context.Entry(exsistingKill).State = EntityState.Detached;

                kill.GameId = exsistingKill.GameId;
                kill.PlayerKills = exsistingKill.PlayerKills;
                kill.TimeDeath = exsistingKill.TimeDeath;

                if(exsistingKill.PlayerKills.FirstOrDefault().PlayerId != exVictimId )
                {
                    Player oldVictim = await _playerRepository.GetById(game_id, exVictimId);
                    Player newVictim = await _playerRepository.GetById(game_id, exsistingKill.PlayerKills.FirstOrDefault().PlayerId);


                    oldVictim.IsHuman = true;
                    newVictim.IsHuman = false;
                }


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

        Kill? kill = await _context.Kills/*.Where(k => k.Id == kill_id)*/.Include(k => k.Game).Include(k => k.PlayerKills).ThenInclude(pk => pk.PlayerId).FirstOrDefaultAsync(k => k.Id == kill_id/**/);
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

    /*
    private async Task<PlayerKill> FindVictimInGame(int game_id, int kill_id)
    {
        if (!GameExists(game_id)) throw new ArgumentException("There is no game with that id");

        Kill? kill = await _context.Kills.Include(k => k.PlayerKills).Include(k => k.Game).FirstOrDefaultAsync(k => k.Id == kill_id);
        if (kill == null)
        {
            throw new ArgumentException("There is no kill with that id");
        }

        if (kill.GameId != game_id)
        {
            throw new ArgumentException("The kill-id you sent in is not in the game you sent in");
        }

        foreach (var pk in kill.PlayerKills)
        {
            if(pk.IsVictim == true)
            {
                PlayerKill victim = pk;
            }
        }
        //return kill.PlayerKills.Where(pk => pk.IsVictim = false);
    }
    */

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
