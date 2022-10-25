using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
using HvZWebAPI.Utils;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System;

namespace HvZWebAPI.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly HvZDbContext _context;

    public ChatRepository(HvZDbContext context)
    {
        _context = context;
    }

    public async Task<Chat> PostChat(int gameId, Chat chat)
    {
        Game? game = await _context.Games
            .Include(game => game.Players
                .Where(player => player.GameId == gameId))
            .FirstOrDefaultAsync(game => game.Id == gameId);

        // Game has to exist, more like game with player not found
        if (game is null)
            throw new ArgumentException(ErrorCategory.GAME_NOT_FOUND(gameId));

        Player? sender = game.Players.FirstOrDefault(player => player.Id == chat.PlayerId);
        // Player has to be apart of given game.
        if (sender is null)
            throw new ArgumentException(ErrorCategory.PLAYER_NOT_IN_GAME(gameId, chat.PlayerId));

        // Invalid case .. Global chat is IsHumanGlobal equals false and IsZombieGlobal equals false
        if (chat.IsHumanGlobal && chat.IsZombieGlobal && (chat.SquadId == 0 || chat.SquadId == null))
            throw new ArgumentException(ErrorCategory.INVALID_CHAT_SCOPE);

        // Sender of chat message is a zombie, but tries to post in the human chat.
        if (chat.IsHumanGlobal && !chat.IsZombieGlobal && !sender.IsHuman)
            throw new ArgumentException(ErrorCategory.ONLY_A_HUMAN_CAN_POST_TO_HUMAN_CHAT(game.Id, sender.Id));

        // Sender of chat message is human, but tries to post in zombie chat
        if (chat.IsZombieGlobal && !chat.IsHumanGlobal && sender.IsHuman)
            throw new ArgumentException(ErrorCategory.ONLY_A_ZOMBIE_CAN_POST_TO_ZOMBIE_CHAT(game.Id, sender.Id));

        int squadId = chat.SquadId ?? 0;
        if (chat.SquadId == 0)
            chat.SquadId = null;
        else
            await IsPlayerPostingToHumansquadAsAZombie(squadId, sender, gameId);


        chat.GameId = gameId;
        await _context.Chats.AddAsync(chat);

        await _context.SaveChangesAsync();

        return chat;
    }

    private async Task IsPlayerPostingToHumansquadAsAZombie(int squad_id, Player sender, int game_id)
    {
        var squad = await _context.Squads.FindAsync(squad_id);
        if (squad != null)
        {
            _context.Entry(squad).State = EntityState.Detached;
            if (squad.Is_human)
            {
                if (!sender.IsHuman)
                {
                    throw new AccessViolationException(ErrorCategory.ONLY_A_HUMAN_CAN_POST_TO_HUMAN_CHAT(game_id, sender.Id));
                }
            }
        }
    }

    public async Task<IEnumerable<Chat>> GetChats(int gameId)
    {
        return await _context.Chats.Where(chat => chat.GameId == gameId).ToListAsync();
    }

    public async Task<Chat?> GetChat(int game_id, int chat_id)
    {
        Game? game = await _context.Games
            .Include(game => game.Chats)
            .FirstOrDefaultAsync(game => game.Id == game_id);
        if (game is null)
            throw new ArgumentException(ErrorCategory.GAME_NOT_FOUND(game_id));

        Chat? chat = game.Chats.FirstOrDefault(chat => chat.Id == chat_id);

        return chat;
    }


}