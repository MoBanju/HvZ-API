using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
using HvZWebAPI.Utils;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HvZWebAPI.Repositories;

public class KillRepository : IKillRepository
{
    private readonly HvZDbContext _context;
    private readonly IPlayerRepository _playerRepository;
    private readonly IGameRepository _gameRepository;

    public KillRepository(HvZDbContext context, IPlayerRepository playerRepository, IGameRepository gameRepository)
    {
        _context = context;
        _playerRepository = playerRepository;
        _gameRepository = gameRepository;
    }
    public async Task<Kill?> Add(int game_id, Kill kill, string bitecode, int killer_id)
    {
        if (!GameExists(game_id)) throw new ArgumentException("Game by that id does not exist");

        if (await KillerVictimSameGame(game_id, killer_id, bitecode) is false) throw new ArgumentException(ErrorCategory.KILLER_VICTIM_NOT_SAME_GAME(game_id, killer_id, bitecode));

        if (await AlreadyZombie(game_id, bitecode) is true) throw new ArgumentException(ErrorCategory.ALREADY_ZOMBIE(bitecode));

        if (await KillerHuman(game_id, killer_id) is true) throw new ArgumentException(ErrorCategory.KILLER_HUMAN(killer_id));

        if (await InAreaGame(kill.Latitude, kill.Longitude, game_id) is false) throw new ArgumentException(ErrorCategory.KILL_OUT_GAME_AREA());

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
            //Includesplayerkills
            var kill = await FindKillInGame(game_id, kill_id);
            var playerKillVictim = kill.PlayerKills.Where(pk => pk.IsVictim == true).First();

            //Revert the death of the old victim
            Player exVictim = await _playerRepository.GetById(game_id, playerKillVictim.PlayerId);/*existingVictim.Id*/;
            exVictim.IsHuman = true;

            _context.Players.Update(exVictim);

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
        return await _context.Kills.Where(k => k.GameId == game_id).Include(k => k.PlayerKills).ToListAsync();
    }

    public async Task<Kill> GetById(int game_id, int kill_id)
    {
        Kill kill = await FindKillInGame(game_id, kill_id);
        return kill;
    }

    public async Task Update(int game_id, Kill kill, string? bitecode)
    {
        //If the bitecode didn't change

        if(!GameExists(game_id)) throw new ArgumentException(ErrorCategory.GAME_NOT_FOUND(game_id));
        if (!KillExists(kill.Id, game_id)) throw new ArgumentException(ErrorCategory.KILL_NOT_FOUND(kill.Id, game_id));
        if(await InAreaGame(kill.Latitude, kill.Longitude, game_id) is false) throw new ArgumentException(ErrorCategory.KILL_OUT_GAME_AREA());


        //If they input a new bitecode checks must be made
        if (bitecode != null)
        {
            if (await VictimSameGame(bitecode, game_id) is false) throw new ArgumentException(ErrorCategory.VICTIM_NOT_FOUND_IN_GAME(game_id, bitecode));
            if (await AlreadyZombie(game_id, bitecode) is true) throw new ArgumentException(ErrorCategory.ALREADY_ZOMBIE(bitecode));

            var onlyKill = await _context.Kills.FindAsync(kill.Id);
            if (onlyKill != null)
            {
                onlyKill.GameId = game_id;
                onlyKill.TimeDeath = kill.TimeDeath;

                //To be killed
                Player newVictim = await _playerRepository.GetByBiteCode(game_id, bitecode); //Should be human at this point
                newVictim.IsHuman = false;

                //Old PlayerKill
                PlayerKill pkVictim = await _context.PlayerKills.Where(pk => pk.KillId == kill.Id && pk.IsVictim == true).FirstAsync(); //Should be Zombie at this point


                //Revert the death of the old victim
                Player exVictim = await _playerRepository.GetById(game_id, pkVictim.PlayerId);/*existingVictim.Id*/;
                exVictim.IsHuman = true;

                //New PK
                PlayerKill newPK = new PlayerKill();
                newPK.Player = newVictim;
                newPK.PlayerId = newVictim.Id;
                newPK.KillId = onlyKill.Id;
                newPK.Kill = onlyKill;
                newPK.IsVictim = true;

                _context.Entry(newVictim).State = EntityState.Modified;
                _context.Remove(pkVictim);
                _context.Add(newPK);
                _context.Entry(onlyKill).State = EntityState.Modified;
                _context.Entry(exVictim).State = EntityState.Modified;

                await _context.SaveChangesAsync();

            }
        }
        else
        {
            var onlyKill = await _context.Kills.FindAsync(kill.Id);
            if (onlyKill != null)
            {
                //This sets the foreign keys
                _context.Entry(onlyKill).State = EntityState.Detached;
                kill.GameId = onlyKill.GameId;

            }
            _context.Update(kill);
            await _context.SaveChangesAsync();
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

        Kill? kill = await _context.Kills/*.Where(k => k.Id == kill_id)*/.Include(k => k.Game).Include(k => k.PlayerKills).FirstOrDefaultAsync(k => k.Id == kill_id/**/);
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
    /// Checks if the victim is alrady a zombie
    /// </summary>
    /// <param name="game_id">Game Id</param>
    /// <param name="bitecode">Bitecode to the player</param>
    /// <returns>Either a zombie or a human</returns>
    private async Task<bool> AlreadyZombie(int game_id, string bitecode)
    {
        Player victim = await _playerRepository.GetByBiteCode(game_id, bitecode);
        return !victim.IsHuman;

    }

    /// <summary>
    /// Checks if the killer is human
    /// </summary>
    /// <param name="game_id">Gme Id</param>
    /// <param name="killer_id">Killer Id</param>
    /// <returns>Either it is human or zombie</returns>
    private async Task<bool> KillerHuman(int game_id, int killer_id)
    {
        Player killer = await _playerRepository.GetById(game_id, killer_id);
        return killer.IsHuman;
    }


    /// <summary>
    /// Checks if the player is in the same game
    /// </summary>
    /// <param name="killer_id">Killer Id</param>
    /// <param name="game_id">Game Id</param>
    /// <returns>Same game or different game</returns>
    private async Task<bool> KillerSameGame(int killer_id, int game_id)
    {
        Player killer = await _playerRepository.GetById(game_id, killer_id);
        return killer.GameId == game_id;

    }

    /// <summary>
    /// Checks if the player is in the same game
    /// </summary>
    /// <param name="bitecode">Bitecode</param>
    /// <param name="game_id">Game Id</param>
    /// <returns>Same game or different game</returns>
    private async Task<bool> VictimSameGame(string bitecode, int game_id)
    {
        Player victim = await _playerRepository.GetByBiteCode(game_id, bitecode);
        return victim.GameId == game_id;

    }



    /// <summary>
    /// Checks if the killer is in the same game as the victim
    /// </summary>
    /// <param name="game_id">Game Id</param>
    /// <param name="killer_id">Killer</param>
    /// <param name="bitecode">Victim</param>
    /// <returns>Either both re in the same game or diferent game</returns>
    private async Task<bool> KillerVictimSameGame(int game_id, int killer_id, string bitecode)
    {
        Player killer = await _playerRepository.GetById(game_id, killer_id);
        Player victim = await _playerRepository.GetByBiteCode(game_id, bitecode);

        return killer.GameId == victim.GameId;

    }

    /// <summary>
    /// Checks if the kill happened inside the area
    /// </summary>
    /// <param name="kill_lat">Kill Latitude</param>
    /// <param name="kill_long">Kill Longitude</param>
    /// <param name="game_id">Game Id</param>
    /// <returns>Either inside or outside of the area</returns>
    /// <exception cref="ArgumentException"></exception>
    private async Task<bool> InAreaGame(double? kill_lat, double? kill_long, int game_id)
    {
        if (!GameExists(game_id)) throw new ArgumentException("There is no game with that id");
        Game? game = await _gameRepository.GetById(game_id);
        if (kill_lat < game.Sw_lat || kill_lat > game.Ne_lat || kill_long < game.Sw_lng || kill_long > game.Ne_lng)
            return false;
        return true;
    }

    /// <summary>
    /// Checks if the kill is tracked in context
    /// </summary>
    /// <param name="kill_id">Kill Id</param>
    /// <returns>Returns a boolean telling if kill exsists</returns>
    private bool KillExists(int kill_id, int game_id)
    {
        var kill = _context.Kills.FirstOrDefault(e => e.Id == kill_id);

        if (kill == null)
        {
            return false;
        }
        if(kill.GameId != game_id)
        {
            return false;
        }

        return true;
    }


}
