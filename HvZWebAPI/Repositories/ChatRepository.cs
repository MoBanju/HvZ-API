using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
using HvZWebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace HvZWebAPI.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly HvZDbContext _context;

    public ChatRepository(HvZDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Chat>> GetChats(int gameId)
    {
        return await _context.Chats.Where(chat => chat.GameId == gameId).ToListAsync();
    }

    public async Task<Chat?> GetChat(int gameId, int chat_id)
    {
        return await _context.Chats.FirstOrDefaultAsync(chat => chat.GameId == gameId && chat.Id == chat_id);
    }

    public async Task<Chat> PostChat(int gameId, Chat chat)
    {
        Game? game = await _context.Games
            .Include(game => game.Players
                .Where(player => player.GameId == gameId))
            .FirstOrDefaultAsync(game => game.Id == gameId);
        
        // Game has to exist
        if(game is null)
            throw new ArgumentException(ErrorCategory.GAME_NOT_FOUND(gameId));

        // Player has to be apart of given game.
        if(!game.Players.Any(player => player.Id == chat.PlayerId))
            throw new ArgumentException(ErrorCategory.PLAYER_NOT_IN_GAME(gameId, chat.PlayerId));

        chat.GameId = gameId;
        await _context.Chats.AddAsync(chat);

        await _context.SaveChangesAsync();

        return chat;
    }
}