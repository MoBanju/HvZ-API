using HvZWebAPI.Data;
using HvZWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HvZWebAPI.Repositories;

public class PlayerRepository : IPlayerRepository
{
    public HvZDbContext _context;

    public PlayerRepository(HvZDbContext context)
    {
        _context = context;
    }


    public async Task<Player?> Add(Player player)
    {
        var savedUser = await _context.Users.FindAsync(player.User.Id);
        var playerWithoutUser = new Player();
        playerWithoutUser.BiteCode = player.BiteCode;
        playerWithoutUser.GameId = player.GameId;
        playerWithoutUser.IsHuman = player.IsHuman;
        playerWithoutUser.IsPatientZero = player.IsPatientZero;

        if (savedUser == null)
        {
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
        catch(DbUpdateConcurrencyException ex)
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


    public async Task<bool> Delete(Player entity)
    {
        int rowsChanged = 0;
        _context.Players.Remove(entity);
        try
        {
            rowsChanged = await _context.SaveChangesAsync();
        }
        catch(Exception e)
        {
            throw;
        }
        Console.WriteLine("rows changed in Delete " + rowsChanged);


        return rowsChanged >0;
    }

    public async Task<IEnumerable<Player>> GetAll()
    {
        return await _context.Players.Include(p => p.User).ToListAsync();
    }

    public async Task<Player?> GetById(int id)
    {
        return await _context.Players.Include(p => p.User).Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    //PUT
    public async Task<bool> Update(Player player)
    {
        var toBeUpdated = await _context.Players.FindAsync(player.Id);
        if (toBeUpdated == null)
            return false;

        toBeUpdated.IsHuman = player.IsHuman;
        toBeUpdated.IsPatientZero = player.IsPatientZero;
        toBeUpdated.BiteCode = player.BiteCode;


        _context.Entry(toBeUpdated).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            if (!PlayerExists(player.Id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }
        return true;
    }

    private bool PlayerExists(int id)
    {
        return _context.Players.Any(e => e.Id == id);
    }
}
