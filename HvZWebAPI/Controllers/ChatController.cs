using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HvZWebAPI.DTOs.Chat;
using HvZWebAPI.Models;
using HvZWebAPI.Interfaces;
using HvZWebAPI.DTOs.Player;
using HvZWebAPI.Utils;
using Microsoft.AspNetCore.Authorization;

namespace HvZWebAPI.Controllers;

[Authorize]
[Route("game")]
[Produces("application/json")]
[Consumes("application/json")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly IChatRepository _repo;
    private readonly IMapper _mapper;

    public ChatController(IChatRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Creates a new gamechat for a given game
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="chatAsDTO"></param>
    /// <returns></returns>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("{game_id}/chat")]
    public async Task<ActionResult<ChatReadDTO>> PostGameChat(int game_id, ChatCreateDTO chatAsDTO)
    {
        try
        {
            Chat chat = _mapper.Map<Chat>(chatAsDTO);
            var chatDTO = _mapper.Map<Chat, ChatReadDTO>(await _repo.PostChat(game_id, chat));


            if (chatDTO == null)
                return BadRequest(ErrorCategory.FAILED_TO_CREATE("Chat"));

            return CreatedAtAction("GetGameChat", new { game_id = game_id, chat_id = chat.Id }, chatDTO);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }

    /// <summary>
    /// Gets all the chats for a given game 
    /// </summary>
    /// <param name="game_id"></param>
    /// <returns></returns>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("{game_id}/chat")]
    public async Task<ActionResult<ChatReadDTO[]>> GetGameChats(int game_id)
    {
        try
        {
            var chat = await _repo.GetChats(game_id);
            var chatAsDTO = chat.Select(chat => _mapper.Map<ChatReadDTO>(chat));
            return Ok(chatAsDTO);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }

    /// <summary>
    /// Gets a chat for a given game
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="chat_id"></param>
    /// <returns></returns>
    [Authorize]
    [HttpGet("{game_id}/chat/{chat_id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ChatReadDTO[]>> GetGameChat(int game_id, int chat_id)
    {
        try
        {
            var chat = await _repo.GetChat(game_id, chat_id);

            if (chat == null) return NotFound(ErrorCategory.CHAT_NOT_FOUND(chat_id, game_id));
            var chatAsDTO = _mapper.Map<ChatReadDTO>(chat);
            return Ok(chatAsDTO);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }

}