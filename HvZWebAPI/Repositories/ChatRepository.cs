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
    
    public async Task<Chat> PostChat(int gameId, Chat chat)
    {
        Game? game = await _context.Games
            .Include(game => game.Players
                .Where(player => player.GameId == gameId))
            .FirstOrDefaultAsync(game => game.Id == gameId);
        
        // Game has to exist, more like game with player not found
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