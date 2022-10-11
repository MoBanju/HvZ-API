using Microsoft.AspNetCore.Mvc;
using HvZWebAPI.Models;
using AutoMapper;
using HvZWebAPI.DTOs.Game;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Utils;
using Microsoft.AspNetCore.Authorization;

namespace HvZWebAPI.Controllers;

[Route("/game")]
[Produces("application/json")]
[Consumes("application/json")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly IGameRepository _repo;
    private readonly IMapper _mapper;

    public GamesController(IGameRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new game, Admin only
    /// </summary>
    /// <param name="gameAsDTO"></param>
    /// <returns></returns>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<GameReadDTO>> PostGame(GameCreateDTO gameAsDTO)
    {


        Game? game = _mapper.Map<Game>(gameAsDTO);
        game.State = State.Registration;
        try
        {
            game = await _repo.Add(game);
            if (game == null)
                return BadRequest(ErrorCategory.FAILED_TO_CREATE("Game"));


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
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult<GameReadDTO[]>> GetGames()
    {
        try
        {
            IEnumerable<Game> games = await _repo.GetAll();
            GameReadDTO[] gamesAsDTOs = games.Select(game => _mapper.Map<GameReadDTO>(game)).ToArray();
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
    /// <returns></returns>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public async Task<ActionResult<GameReadDTO>> GetGame(int id)
    {
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
    /// Updates a game, Admin only
    /// </summary>
    /// <param name="id"></param>
    /// <param name="gameAsDto"></param>
    /// <returns></returns>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGame(int id, GameUpdateDeleteDTO gameAsDto)
    {
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
                return BadRequest(ErrorCategory.FAILED_TO_UPDATE("Game"));
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
    /// Deletes a game, Admin only
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
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
