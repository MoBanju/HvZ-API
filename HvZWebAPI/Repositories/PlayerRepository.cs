﻿using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace HvZWebAPI.Repositories;

public class PlayerRepository : IPlayerRepository
{
    public HvZDbContext _context;

    public PlayerRepository(HvZDbContext context)
    {
        _context = context;
    }


    public async Task<bool> Add(Player entity)
    {
        _context.Players.Add(entity);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        return true;

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
       return await _context.Players.ToListAsync();
    }

    public async Task<Player?> GetById(int id)
    {
        return await _context.Players.FindAsync(id);
    }

    public Task<bool> Update(Player entity)
    {
        throw new NotImplementedException();
    }
}
