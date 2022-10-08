using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
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
        if (!GameExists(game_id)) throw new ArgumentException("There is no game with that id");


        var savedUser = await _context.Users.FindAsync(player.User.Id);
        var playerWithoutUser = new Player();
        playerWithoutUser.BiteCode = player.BiteCode;
        playerWithoutUser.GameId = game_id;
        playerWithoutUser.IsHuman = player.IsHuman;
        playerWithoutUser.IsPatientZero = player.IsPatientZero;



        if (savedUser == null)
        {
            //TODO: use userRepository
            var user = await createUser(player.User.FirstName, player.User.LastName);
            playerWithoutUser.UserId = user.Id;
        }
        else
        {
            playerWithoutUser.UserId = player.User.Id;
        }

        _context.Players.Add(playerWithoutUser);

        try
        {
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
        return playerWithoutUser;

    }

    private async Task<User> createUser(string firstname, string lastname)
    {
        var user = new User();
        user.FirstName = firstname;
        user.LastName = lastname;
        _context.Users.Add(user);

        await _context.SaveChangesAsync();
        return user;
    }


    public async Task Delete(int game_id, int player_id)
    {
        int rowsChanged = 0;
        try
        {
            //Validation, throws ArgumentException
            var player = await FindPlayerInGame(game_id, player_id);

            _context.Players.Remove(player);

            rowsChanged = await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(" _This exception is thrown on missing: " + e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Player>> GetAll(int game_id)
    {
        if (!GameExists(game_id)) throw new ArgumentException("Game by that id does not exsist");

        return await _context.Players.Include(p => p.User).Where(p=>p.GameId==game_id).ToListAsync();
    }

    public async Task<Player> GetById(int game_id, int player_id)
    {
       var player = await FindPlayerInGame(game_id, player_id);
        return player;

        //return await _context.Players.Include(p => p.User).Where(p => p.Id == player_id).FirstOrDefaultAsync();
    }

    //PUT
    public async Task Update(int game_id, Player player)
    {
        try
        {
            var checkPlayer = await FindPlayerInGame(game_id, player.Id);
            checkPlayer.IsHuman = player.IsHuman;
            checkPlayer.IsPatientZero = player.IsPatientZero;
            checkPlayer.BiteCode = player.BiteCode;

            _context.Entry(checkPlayer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        { 
            throw; 
        }
    }



    private async Task<Player> FindPlayerInGame(int game_id, int player_id)
    {
        if (!GameExists(game_id)) throw new ArgumentException("There is no game with that id");

        Player? player = await _context.Players.Include(p => p.User).SingleOrDefaultAsync(p=>p.Id == player_id);
        if(player == null)
        {
          throw new ArgumentException("There is no player with that id");
        }

        if(player.GameId != game_id)
        {
            throw new ArgumentException("The player-id you sent in is not in the game you sent in");
        }

        return player;
    }

    private bool GameExists(int game_id)
    {
        return _context.Games.Any(e => e.Id == game_id);
    }

    private bool PlayerExists(int player_id)
    {
        return _context.Players.Any(e => e.Id == player_id);
    }

}
