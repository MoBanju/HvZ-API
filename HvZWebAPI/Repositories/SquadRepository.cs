using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Migrations;
using HvZWebAPI.Models;
using HvZWebAPI.Utils;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HvZWebAPI.Repositories;

public class SquadRepository : ISquadRepository
{
    private readonly HvZDbContext _context;
    private readonly ISquadMemberRepository _smrepo;


    public SquadRepository(HvZDbContext context)
    {
        _context = context;
    }

    public async Task<Squad> Add(int game_id, Squad squad, int player_id)
    {
        await GameExists(game_id);
        bool human = await PlayerInGame(player_id, game_id);
        if(squad.Is_human != human) throw new ArgumentException(ErrorCategory.ILLEGAL_SQUAD_TYPE());


        //Should automatically try to register a member
        squad.GameId = game_id;
        SquadMember sm = new SquadMember() { PlayerId = player_id, GameId = game_id, Rank = "Boss"};
        squad.Squad_Members = new List<SquadMember>();
        squad.Squad_Members.Add(sm);

        _context.Squads.Add(squad);

        await _context.SaveChangesAsync();

        return squad;
    }

    /// <summary>
    /// Returns if is human
    /// </summary>
    /// <param name="player_id"></param>
    /// <param name="game_id"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private async Task<bool> PlayerInGame(int player_id, int game_id)
    {
        Player? player = await _context.Players.FirstOrDefaultAsync(p => p.Id == player_id);

        if (player == null)
        {
            throw new ArgumentException(ErrorCategory.PLAYER_NOT_FOUND(player_id));
        }

        if (player.GameId != game_id)
        {
            throw new ArgumentException(ErrorCategory.PLAYER_NOT_IN_GAME(game_id, player_id));
        }
        _context.Entry(player).State = EntityState.Detached;
        return player.IsHuman;
    }

    private async Task GameExists(int game_id)
    {
        var game = await _context.Games.FindAsync(game_id);
        if (game == null) throw new ArgumentException(ErrorCategory.GAME_NOT_FOUND(game_id));
        else
            _context.Entry(game).State = EntityState.Detached;
    }

    private async Task<Squad> SquadExistsInGame(int game_id, int squad_id)
    {
        var game = await _context.Games.Where(g => g.Id == game_id).Include(g=>g.Squads).FirstAsync();
        if (game == null) throw new ArgumentException(ErrorCategory.GAME_NOT_FOUND(game_id));
        else
            _context.Entry(game).State = EntityState.Detached;

        if(game.Squads == null) throw new ArgumentException(ErrorCategory.SQUAD_NOT_FOUND(game_id, squad_id));
        Squad? squad = game.Squads.FirstOrDefault(s => s.Id == squad_id);
        if (squad == null) throw new ArgumentException(ErrorCategory.SQUAD_NOT_FOUND(game_id, squad_id));
        _context.Entry(squad).State = EntityState.Detached;
        return squad;
    }

    public async Task<IEnumerable<Squad>> GetAll(int game_id)
    {
        await GameExists(game_id);

        return await _context.Squads.ToListAsync();

    }

    public async Task<Squad?> GetById(int game_id, int squad_id)
    {
        await SquadExistsInGame(game_id, squad_id);

        return  await _context.Squads.FindAsync(squad_id);
    }
    public async Task<bool> Update(int game_id, Squad squad)
    {
        await SquadExistsInGame(game_id, squad.Id);

        _context.Entry(squad).State = EntityState.Modified;

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int game_id, int squad_id)
    {
        await SquadExistsInGame(game_id, squad_id);

        var squad = _context.Squads.Include(s => s.Squad_Members).First(s => s.Id == squad_id);

        foreach(var s in squad.Squad_Members) { 
            _context.Squad_Members.Remove(s);
        }

        _context.Squads.Remove(squad);

        return await _context.SaveChangesAsync() > 0;
    }
}
