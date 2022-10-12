using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
using HvZWebAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HvZWebAPI.Repositories;

public class PlayerRepository : IPlayerRepository
{
    public HvZDbContext _context;
    public IUserRepository _userRepository;

    public PlayerRepository(HvZDbContext context, IUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }

    public async Task<Player?> Add(int game_id, Player player)
    {
        try
        {
            await ValidateUniquePlayer(game_id, player.UserId);

            player.GameId = game_id;
            var exsistingUser = _context.Users.SingleOrDefault(u => u.Id == player.User.Id);
            if (exsistingUser != null)
            {
                //If the user is allready in the context then it should not be updated
                _context.Entry(exsistingUser).State = EntityState.Unchanged;
                player.User = exsistingUser;
            }
            else
            {
                //This user.id reset is required as it will only be flagged as entitystate added if it has the default id of 0
                player.User.Id = 0;
                player.User = await _userRepository.Add(player.User) ?? new();

            }

            await _context.Players.AddAsync(player);


            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            if (!PlayerExists(player.Id))
            {
                return null;
            }
            else
            {
                throw;
            }
        }
        return player;

    }

    private async Task ValidateUniquePlayer(int game_id, int user_id)
    {
        var list = await GetAll(game_id);
        if (list.Any(p => p.UserId == user_id))
            throw new ArgumentException(ErrorCategory.UNIQUE_PLAYER(user_id));
    }

    public async Task<IEnumerable<Player>> GetAll(int game_id)
    {
        if (!GameExists(game_id)) throw new ArgumentException(ErrorCategory.GAME_NOT_FOUND(game_id));

        return await _context.Players.Include(p => p.User).Where(p => p.GameId == game_id).ToListAsync();
    }

    public async Task<Player> GetById(int game_id, int player_id)
    {
        var player = await FindPlayerInGame(game_id, player_id);
        return player;
    }

    public async Task<bool> Update(int game_id, Player player)
    {

        var exsistingPlayer = await FindPlayerInGame(game_id, player.Id);
        if (exsistingPlayer != null)
        {
            //This sets the foreign keys
            _context.Entry(exsistingPlayer).State = EntityState.Detached;
            player.UserId = exsistingPlayer.UserId;
            player.GameId = exsistingPlayer.GameId;
        }

        _context.Update(player);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int game_id, int player_id)
    {
        int rowsChanged = 0;

        var player = await FindPlayerInGame(game_id, player_id);



        _context.Players.Remove(player);

        return await _context.SaveChangesAsync() > 0;
    }
    

    /// <summary>
    /// Used to retrieve the player that fits the combination of game id and player id
    /// This is the main validation method, returning argument exceptions
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="player_id"></param>
    /// <returns>A player from the context or database</returns>
    /// <exception cref="ArgumentException"></exception>
    private async Task<Player> FindPlayerInGame(int game_id, int player_id, bool getuser = true)
    {
        if (!GameExists(game_id)) throw new ArgumentException(ErrorCategory.GAME_NOT_FOUND(game_id));


        Player? player = await _context.Players.Include(p => p.User).FirstOrDefaultAsync(p => p.Id == player_id);
        
        
        if (player == null)
        {
            throw new ArgumentException(ErrorCategory.PLAYER_NOT_FOUND(player_id));
        }

        if (player.GameId != game_id)
        {
            throw new ArgumentException(ErrorCategory.PLAYER_NOT_IN_GAME(game_id, player_id));
        }

        return player;
    }

    /// <summary>
    /// Checks if the game is tracked in the context
    /// </summary>
    /// <param name="game_id"></param>
    /// <returns></returns>
    private bool GameExists(int game_id)
    {
        return _context.Games.Any(e => e.Id == game_id);
    }

    /// <summary>
    /// Checks if the player is tracked in context
    /// </summary>
    /// <param name="player_id"></param>
    /// <returns></returns>
    private bool PlayerExists(int player_id)
    {
        return _context.Players.Any(e => e.Id == player_id);
    }

}
