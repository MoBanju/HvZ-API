﻿using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Migrations;
using HvZWebAPI.Models;
using HvZWebAPI.Utils;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Security.Cryptography;

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
        if (squad.Is_human != human) throw new ArgumentException(ErrorCategory.ILLEGAL_SQUAD_TYPE());

        bool IsUnique = !_context.Squad_Members.Where(sm => sm.GameId == game_id).Any(sm => sm.PlayerId == player_id);
        if (!IsUnique) throw new ArgumentException(ErrorCategory.UNIQUE_PLAYER_SQUAD(game_id));

        //Should automatically try to register a member
        squad.GameId = game_id;
        SquadMember sm = new SquadMember() { PlayerId = player_id, GameId = game_id, Rank = ErrorCategory.TOPRANK };
        squad.Squad_Members = new List<SquadMember>();
        squad.Squad_Members.Add(sm);


        _context.Squads.Add(squad);

        await _context.SaveChangesAsync();

        return squad;
    }
    public async Task<SquadMember> AddMember(int game_id, SquadMember squadMember, int squad_id)
    {
        if (squadMember.Rank == ErrorCategory.TOPRANK) throw new ArgumentException(ErrorCategory.TOPRANK_IS_RESERVED);

        //Only join squads of your faction
        var squad = await SquadExistsInGame(game_id, squad_id);
        bool human = await PlayerInGame(squadMember.PlayerId, game_id);
        if (squad.Is_human != human) throw new ArgumentException(ErrorCategory.ILLEGAL_SQUAD_TYPE());

        //Only allowed to join one squad in a game
        bool IsUnique = !_context.Squad_Members.Where(sm => sm.GameId == game_id).Any(sm => sm.PlayerId == squadMember.PlayerId);
        if (!IsUnique) throw new ArgumentException(ErrorCategory.UNIQUE_PLAYER_SQUAD(game_id));



        squadMember.SquadId = squad_id;
        squadMember.PlayerId = squadMember.PlayerId;
        squadMember.GameId = game_id;

        _context.Squad_Members.Add(squadMember);
        await _context.SaveChangesAsync();

        return squadMember;
    }

/*    public async Task<SquadMember> DeleteMember(int game_id, int squad_id, int squadMember_id)
    {


    }*/


    public async Task<SquadCheckin> AddCheckin(int game_id, SquadCheckin squadCheckin, int squad_id)
    {
        await SquadExistsInGame(game_id, squad_id);

        squadCheckin.SquadId = squad_id;
        squadCheckin.GameId = game_id;

        _context.Squad_Checkins.Add(squadCheckin);
        await _context.SaveChangesAsync();

        return squadCheckin;
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
        var game = await _context.Games.Where(g => g.Id == game_id).Include(g => g.Squads).FirstOrDefaultAsync();
        if (game == null) throw new ArgumentException(ErrorCategory.GAME_NOT_FOUND(game_id));
        else
            _context.Entry(game).State = EntityState.Detached;

        if (game.Squads == null) throw new ArgumentException(ErrorCategory.SQUAD_NOT_FOUND(game_id, squad_id));
        Squad? squad = game.Squads.FirstOrDefault(s => s.Id == squad_id);
        if (squad == null) throw new ArgumentException(ErrorCategory.SQUAD_NOT_FOUND(game_id, squad_id));
        _context.Entry(squad).State = EntityState.Detached;
        return squad;
    }



    public async Task<IEnumerable<Squad>> GetAll(int game_id)
    {
        await GameExists(game_id);

        return await _context.Squads.Include(s => s.Squad_Members).ThenInclude(sm => sm.Player).Where(s => s.GameId == game_id).ToListAsync();

    }

    public async Task<IEnumerable<SquadCheckin>> GetAllCheckins(int game_id, int squad_id)
    {
        await SquadExistsInGame(game_id, squad_id);
        return await _context.Squad_Checkins.Where(sc => sc.SquadId == squad_id).ToListAsync();
    }

    public async Task<Squad?> GetById(int game_id, int squad_id)
    {
        await SquadExistsInGame(game_id, squad_id);


        return await _context.Squads.Include(s => s.Squad_Members).FirstOrDefaultAsync(s => s.Id == squad_id);
    }

    public async Task<SquadMember?> GetMemberById(int game_id, int squad_id, int squadMember_id)
    {
        await SquadExistsInGame(game_id, squad_id);
        //Use squad id to check if squadmember has same
        var squadmember = await _context.Squad_Members.FindAsync(squadMember_id);
        if (squadmember == null) throw new ArgumentException(ErrorCategory.SQUADMEMBER_NOT_FOUND(squadMember_id));
        if (squadmember.SquadId != squad_id) throw new ArgumentException(ErrorCategory.NOT_MEMBER_OF_SQUAD(squadMember_id, squad_id));

        return squadmember;
    }

    /// Should only find markers of the same faction
    public async Task<SquadCheckin> GetCheckinById(int game_id, int squad_id, int squadCheckin_id)
    {
        await SquadExistsInGame(game_id, squad_id);

        var squadCheckin = await _context.Squad_Checkins.FindAsync(squadCheckin_id);
        if (squadCheckin == null) throw new ArgumentException(ErrorCategory.SQUADMEMBER_NOT_FOUND(squadCheckin_id));
        if (squadCheckin.SquadId != squad_id) throw new ArgumentException(ErrorCategory.NOT_MEMBER_OF_SQUAD(squadCheckin_id, squad_id));

        return squadCheckin;
    }



    public async Task<bool> Update(int game_id, Squad squad)
    {
        await SquadExistsInGame(game_id, squad.Id);

        squad.GameId = game_id;

        _context.Update(squad);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int game_id, int squad_id)
    {
        await SquadExistsInGame(game_id, squad_id);

        var squad = _context.Squads.Include(s => s.Squad_Checkins).Include(s=> s.Squad_Members).First(s => s.Id == squad_id);

        if (squad.Squad_Checkins != null)
            _context.RemoveRange(squad.Squad_Checkins);
        _context.RemoveRange(squad.Squad_Members);


        _context.Squads.Remove(squad);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteMember(int game_id, int squad_id, int player_id)
    {

        await SquadExistsInGame(game_id, squad_id);

        SquadMember? squadMember = await _context.Squad_Members.Include(sm => sm.Squad_Checkins).FirstAsync(sm => sm.SquadId == squad_id && sm.PlayerId == player_id);

        if(squadMember.Squad_Checkins != null)
            _context.Squad_Checkins.RemoveRange(squadMember.Squad_Checkins);

        if(squadMember != null)
            _context.Squad_Members.Remove(squadMember);
        return await _context.SaveChangesAsync() > 0;

    }

}
