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
using System.Security.Claims;
using System.Numerics;

namespace HvZWebAPI.Controllers;

[Route("game/")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerRepository _repo;
    private readonly IMapper _mapper;

    public PlayerController(IPlayerRepository repo, IMapper mapper)
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
    [Authorize]
    [HttpPost("{game_id}/[controller]")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Player>> PostPlayer(int game_id, PlayerCreateDTO playerDTO)
    {
        Player player = _mapper.Map<PlayerCreateDTO, Player>(playerDTO);
        var nameClaims = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).ToList();

        try
        {
            player.User.KeyCloakId = CheckForKeycloakId(playerDTO.user.KeyCloakId);
            player.GameId = game_id;

            Player? savedPlayer = await _repo.Add(game_id, player);

            if (savedPlayer == null)
                return BadRequest(ErrorCategory.FAILED_TO_CREATE("Player"));

            PlayerReadAdminDTO mapped = _mapper.Map<Player, PlayerReadAdminDTO>(savedPlayer);

            return CreatedAtAction("GetPlayer", new { game_id = game_id, player_id = savedPlayer.Id }, mapped);

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
    }

    /// <summary>
    /// Validates for keycloakid and returns the appropriate one
    /// </summary>
    /// <param name="player"></param>
    /// <param name="KeyCloakId"></param>
    /// <exception cref="ArgumentException"></exception>
    private string CheckForKeycloakId(string KeyCloakId)
    {
        //If you are admin you can set whatever user you want, users simply send their own identity
        if (!User.IsInRole(ClaimsTransformer.ADMIN_ROLE))
        {
            var nameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (nameClaim != null)
                return nameClaim.Value;
            else throw new ArgumentException(ErrorCategory.NO_KEYCLOAK_ID);
        }
        else
        {
            if (KeyCloakId != null)
            {
                return KeyCloakId;
            }
            else
            {
                throw new ArgumentException(ErrorCategory.NO_KEYCLOAK_ID_ADMIN);
            }
        }
    }

    /// <summary>
    /// Get a list of players in a given game
    /// Each player object is only visible in it's entirety to administrators 
    /// </summary>
    /// <param name="game_id"></param>
    /// <returns></returns>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("{game_id}/[controller]")]
    public async Task<ActionResult<IEnumerable<PlayerReadAdminDTO>>> GetPlayers(int game_id)
    {
        List<PlayerReadAdminDTO> playersDTO = new();

        try
        {
            playersDTO = _mapper.Map<List<PlayerReadAdminDTO>>(await _repo.GetAll(game_id));
            if (!User.IsInRole(ClaimsTransformer.ADMIN_ROLE))
            {
                playersDTO.ForEach(pdto => pdto.IsPatientZero = null);
            }
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
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
        try
        {
            Player player = await _repo.GetById(game_id, player_id);
            PlayerReadAdminDTO playerDTO = _mapper.Map<Player, PlayerReadAdminDTO>(player);
            if (!User.IsInRole(ClaimsTransformer.ADMIN_ROLE))
            {
                playerDTO.IsPatientZero = null;
            }

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
    [Authorize(Roles = "admin-client-role")]
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
    [Authorize(Roles = "admin-client-role")]
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
