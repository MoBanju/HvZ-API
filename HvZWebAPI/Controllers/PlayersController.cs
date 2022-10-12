using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HvZWebAPI.Data;
using HvZWebAPI.Models;
using AutoMapper;
using System.Xml.Linq;
using Newtonsoft.Json;
using HvZWebAPI.DTOs.Player;
using HvZWebAPI.Interfaces;
using HvZWebAPI.DTOs.Player;
using Newtonsoft.Json.Serialization;
using HvZWebAPI.Utils;
using Microsoft.AspNetCore.Authorization;

namespace HvZWebAPI.Controllers;

[Route("game/")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public class PlayersController : ControllerBase
{
    private readonly IPlayerRepository _repo;
    private readonly IMapper _mapper;

    public PlayersController(IPlayerRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    /// <summary>
    /// Registers a new user for the game if there is no or unused user id is provided i player object.
    ///  Adds a player object to the user, each user only has one player in each game. 
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="playerDTO"></param>
    /// <returns></returns>
    //[Authorize]
    [HttpPost("{game_id}/[controller]")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Player>> PostPlayer(int game_id, PlayerCreateDTO playerDTO)
    {
        Player player = _mapper.Map<PlayerCreateDTO, Player>(playerDTO);

        player.GameId = game_id;
        try
        {

            Player? savedPlayer = await _repo.Add(game_id, player);

            if (savedPlayer == null)
                return BadRequest(ErrorCategory.FAILED_TO_CREATE("Player"));
            
            PlayerReadAdminDTO mapped = _mapper.Map<Player, PlayerReadAdminDTO>(savedPlayer);

            return CreatedAtAction("GetPlayer", new { game_id = game_id, player_id = savedPlayer.Id }, mapped);

        }catch(ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }

    /// <summary>
    /// Get a list of players in a given game
    /// Each player object is only visible in it's entirety to administrators 
    /// </summary>
    /// <param name="game_id"></param>
    /// <returns></returns>
    //[Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("{game_id}/[controller]")]
    public async Task<ActionResult<IEnumerable<PlayerReadAdminDTO>>> GetPlayers(int game_id)
    {
        List<PlayerReadAdminDTO> playersDTO = new ();

        try
        {
            playersDTO = _mapper.Map<List<PlayerReadAdminDTO>>(await _repo.GetAll(game_id));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }catch(Exception ex)
        {
            Console.WriteLine($"error: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
        //TODO: Keycloak, if Not ADMIN Null out the IsPatientZeroField and add JSONresult
        return new JsonResult(playersDTO, new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
    }

    /// <summary>
    /// Gets a specific player in a given game
    /// The entire object is only visible to administrators 
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="player_id"></param>
    /// <returns></returns>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("{game_id}/[controller]/{player_id}")]
    public async Task<ActionResult<PlayerReadAdminDTO>> GetPlayer(int game_id, int player_id)
    {
        try { 
            Player player = await _repo.GetById(game_id,player_id);
            //TODO: Keycloak, IF Not ADMIN: playerDTO.IsPatientZero = null;
            PlayerReadAdminDTO playerDTO = _mapper.Map<Player, PlayerReadAdminDTO>(player);

            //Is a type of actionresult, remember this does not typecheck
            return new JsonResult(playerDTO, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"error: {ex.Message}");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }

    /// <summary>
    /// Updates the player object itself, not the associated user object.
    /// Admin only
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="player_id"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("{game_id}/[controller]/{player_id}")]
    public async Task<IActionResult> PutPlayer(int game_id, int player_id, PlayerUpdateDeleteDTO player)
    {
        if (player_id != player.Id)
        {
            return BadRequest("Id in body and url doesn't match");
        }

        try
        {
            bool succuess = await _repo.Update(game_id, _mapper.Map<PlayerUpdateDeleteDTO, Player>(player));
            if (!succuess) return NotFound(ErrorCategory.FAILURE);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
        return NoContent();
    }

    /// <summary>
    /// Deletes a player, Admin only
    /// </summary>
    /// <param name="game_id"></param>
    /// <param name="player_id"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{game_id}/[controller]/{player_id}")]
    public async Task<IActionResult> DeletePlayer(int game_id, int player_id)
    {
        try
        {
           bool succuess = await _repo.Delete(game_id, player_id);
            if (!succuess) return NotFound(ErrorCategory.FAILURE);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
        return NoContent();
    }
}
