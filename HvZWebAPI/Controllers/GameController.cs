using Microsoft.AspNetCore.Mvc;
using HvZWebAPI.Models;
using AutoMapper;
using HvZWebAPI.DTOs.Game;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using NuGet.Versioning;
using System.Security.Claims;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace HvZWebAPI.Controllers;

[Route("/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameRepository _repo;
    private readonly IMapper _mapper;

    public GameController(IGameRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    /// <summary>
    /// (Admin Only) Creates a new game
    /// </summary>
    /// <param name="gameAsDTO"></param>
    /// <returns>The newly created game</returns>
    /// <response code="201">Game is created</response>
    /// <response code="400">Validation of input data failed, it validates start and entime, if coordinates are within the game </response>
    /// <response code="500"> Catches all other internal errors</response>
    [Authorize(Roles = "admin-client-role")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<GameReadDTO>> PostGame(GameCreateDTO gameAsDTO)
    {
        bool IsBefore = gameAsDTO.StartTime.CompareTo(gameAsDTO.EndTime) < 0;
        if (!IsBefore) return BadRequest(ErrorCategory.START_TIME_MUST_BE_BEFORE_ENDTIME());


        Game? game = _mapper.Map<Game>(gameAsDTO);
        game.State = State.Registration;
        try
        {
            game = await _repo.Add(game);
            if (game == null)
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.FAILED_TO_CREATE("Game"));


            return CreatedAtAction("GetGame", new { id = game.Id }, _mapper.Map<GameReadDTO>(game));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }

    /// <summary>
    /// Returns a list of all games
    /// </summary>
    /// <returns>A list of games</returns>    
    /// <response code="200"> Succuess, returns a list of games</response>
    /// <response code="500"> Catches all other internal errors</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult<GameReadDTO[]>> GetGames()
    {
        try
        {
            IEnumerable<Game> games = await _repo.GetAll();
            GameReadDTO[] gamesAsDTOs = games.Select(game => _mapper.Map<GameReadDTO>(game)).ToArray();
            addPlayerCounts(gamesAsDTOs, games);
            return gamesAsDTOs;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }

    /// <summary>
    /// Returns a specific game object
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A specific game</returns>
    /// <response code="200">Returns the specified game</response>
    /// <response code="404"> The game was not found in the database</response>
    /// <response code="500"> Catches all other internal errors</response>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public async Task<ActionResult<GameReadDTO>> GetGame(int id)
    {
        User.HasClaim((c) => {
            if (c.Type == ClaimTypes.Role)
                Debug.WriteLine("Roleclaim " + c);
            return c.Value == ClaimTypes.Role;
        });

        var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
        var roles3 = User.IsInRole(ClaimsTransformer.ADMIN_ROLE);

        try
        {
            Game? game = await _repo.GetById(id);
            if (game is null)
            {
                return NotFound(ErrorCategory.FAILURE);
            }
            GameReadDTO gameAsDto = _mapper.Map<GameReadDTO>(game);
            return gameAsDto;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }

    }


    /// <summary>
    /// List of all games that are in registration
    /// </summary>
    /// <returns></returns>
    /// <response code="200"> Returns games in the registration state</response>
    /// <response code="500"> Catches all other internal errors</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("State/Registration")]
    public async Task<ActionResult<GameReadDTO[]>> GetGamesRegistration()
    {
        try
        {
            IEnumerable<Game> games = await _repo.GetByState(State.Registration);
            GameReadDTO[] gamesAsDTOs = games.Select(game => _mapper.Map<GameReadDTO>(game)).ToArray();
            addPlayerCounts(gamesAsDTOs, games);
            return gamesAsDTOs;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }

    /// <summary>
    /// List of all games that are in progress
    /// </summary>
    /// <returns>List of all games that are in progress</returns>
    /// <response code="200"> Returns games in the progress state</response>
    /// <response code="500"> Catches all other internal errors</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("State/Progress")]
    public async Task<ActionResult<GameReadDTO[]>> GetGamesInProgress()
    {
        try
        {
            IEnumerable<Game> games = await _repo.GetByState(State.Progress);
            GameReadDTO[] gamesAsDTOs = games.Select(game => _mapper.Map<GameReadDTO>(game)).ToArray();
            addPlayerCounts(gamesAsDTOs, games);
            return gamesAsDTOs;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }



    /// <summary>
    /// List of all games that are completed
    /// </summary>
    /// <returns>List of all games that are completed</returns>
    /// <response code="200"> List of all games that are completed</response>
    /// <response code="500"> Catches all other internal errors</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("State/Completed")]
    public async Task<ActionResult<GameReadDTO[]>> GetGamesCompleted()
    {
        try
        {
            IEnumerable<Game> games = await _repo.GetByState(State.Complete);
            GameReadDTO[] gamesAsDTOs = games.Select(game => _mapper.Map<GameReadDTO>(game)).ToArray();
            addPlayerCounts(gamesAsDTOs, games);
            return gamesAsDTOs;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }

    private void addPlayerCounts(GameReadDTO[] gamesAsDTOs, IEnumerable<Game> games)
    {
        int count = 0;
        foreach (var g in games)
        {
            if (g.Players != null)
                gamesAsDTOs[count].PlayerCount = g.Players.Count();
            count++;
        }
    }

    /// <summary>
    /// (Admin Only) Updates a game
    /// </summary>
    /// <param name="id"></param>
    /// <param name="gameAsDto"></param>
    /// <returns></returns>
    /// <response code="204"> Sucuess, game is updated</response>
    /// <response code="400">Validation error</response>
    /// <response code="404"> Failed to update the game</response>
    /// <response code="500"> Catches all other internal errors</response>
    [Authorize(Roles = "admin-client-role")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGame(int id, GameUpdateDeleteDTO gameAsDto)
    {
        bool IsBefore = gameAsDto.StartTime.CompareTo(gameAsDto.EndTime) < 0;
        if (!IsBefore) return BadRequest(ErrorCategory.START_TIME_MUST_BE_BEFORE_ENDTIME());

        if (id != gameAsDto.Id)
        {
            return BadRequest();
        }

        try
        {
            Game game = _mapper.Map<Game>(gameAsDto);
            Boolean success = await _repo.Update(game);


            if (!success)
            {
                return NotFound(ErrorCategory.FAILED_TO_UPDATE("Game"));
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }


    /// <summary>
    /// (Admin Only) Deletes a game
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <response code="204"> Sucuess, game is deleted</response>
    /// <response code="404"> Validation error, failed to update the game</response>
    /// <response code="500"> Catches all other internal errors</response>
    [Authorize(Roles = "admin-client-role")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        try
        {
            //Unhandeled error
            Boolean success = await _repo.Delete(id);

            if (!success)
                return NotFound(ErrorCategory.FAILURE);

            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
        }
    }
}
