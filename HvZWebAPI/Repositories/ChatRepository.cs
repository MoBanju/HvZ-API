using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HvZWebAPI.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly HvZDbContext _context;

    public ChatRepository(HvZDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Chat>> GetChat(int gameId)
    {
        return await _context.Chats.Where(chat => chat.GameId == gameId).ToListAsync();
    }

    public async Task<bool> PostChat(int gameId, Chat chat)
    {
        Game? game = await _context.Games
            .Include(game => game.Players
                .Where(player => player.GameId == gameId))
            .FirstOrDefaultAsync(game => game.Id == gameId);
        
        // Game has to exist
        if(game is null)
            throw new ArgumentException($"No game with id {gameId} found");

        // Player has to be apart of given game.
        if(!game.Players.Any(player => player.Id == chat.PlayerId))
            throw new ArgumentException($"No player with player id {chat.PlayerId} is participating in a game with game id {gameId}");

        chat.GameId = gameId;
        await _context.Chats.AddAsync(chat);

        return await _context.SaveChangesAsync() > 0;
    }
}