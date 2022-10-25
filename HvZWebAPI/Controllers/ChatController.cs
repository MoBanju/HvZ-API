using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HvZWebAPI.DTOs.Chat;
using HvZWebAPI.Models;
using HvZWebAPI.Interfaces;
using HvZWebAPI.DTOs.Player;
using HvZWebAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    /// Creates a new chat object for a given game
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="chatAsDTO"></param>
    /// <returns></returns>
    /// <response code="201">Succuess, new chat created</response>
    /// <response code="400">Input validation error</response>
    /// <response code="403">Illegal chats in squads you are not a member of, or that you don't have the correct faction for</response>
    /// <response code="500"> Catches all other internal errors</response>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost("{game_id}/[controller]")]
    public async Task<ActionResult<ChatReadDTO>> PostGameChat(int game_id, ChatCreateDTO chatAsDTO)
    {
        try
        {
            Chat chat = _mapper.Map<Chat>(chatAsDTO);
            var chatDTO = _mapper.Map<Chat, ChatReadDTO>(await _repo.PostChat(game_id, chat));

            if (chatDTO == null)
                return BadRequest(ErrorCategory.FAILED_TO_CREATE("Chat"));

            //Set null as default

            var nullIgnorer = JsonConvert.SerializeObject(chatDTO, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            });
            JObject nullIgnoredObject = JObject.Parse(nullIgnorer);

            return CreatedAtAction("GetGameChat", new { game_id = game_id, chat_id = chat.Id }, nullIgnoredObject);
        }
        catch (AccessViolationException e)
        {
            return StatusCode(StatusCodes.Status403Forbidden, e.Message);
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
    /// <response code="200">Succuess, returns a lists of chats</response>
    /// <response code="400">Input validation error</response>
    /// <response code="500"> Catches all other internal errors</response>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("{game_id}/[controller]")]
    public async Task<ActionResult<ChatReadDTO[]>> GetGameChats(int game_id)
    {
        try
        {
            var chat = await _repo.GetChats(game_id);
            var chatAsDTO = chat.Select(chat => _mapper.Map<ChatReadDTO>(chat));

            return new JsonResult(chatAsDTO, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }

    /// <summary>
    /// Gets a specific chat for a given game
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="chat_id"></param>
    /// <returns></returns>
    /// <response code="200">Succuess, returns a specific chat</response>
    /// <response code="404">The chat was not found</response>
    /// <response code="500"> Catches all other internal errors</response>
    [Authorize]
    [HttpGet("{game_id}/[controller]/{chat_id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ChatReadDTO[]>> GetGameChat(int game_id, int chat_id)
    {
        try
        {
            var chat = await _repo.GetChat(game_id, chat_id);

            if (chat == null) return NotFound(ErrorCategory.CHAT_NOT_FOUND(chat_id, game_id));
            var chatAsDTO = _mapper.Map<ChatReadDTO>(chat);
            return new JsonResult(chatAsDTO, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }

}