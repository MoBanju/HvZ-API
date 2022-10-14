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


     


        /*     var roles2 = ((ClaimsIdentity)User.Identity);

             foreach(var claim in roles2.Claims)
             {
                 Console.WriteLine(claim.Type);
                 Console.WriteLine(claim.ValueType);
                 if(claim.Type == "realm_access")
                 {
                     var realmAccessAsDict = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(claim.Value);
                     if (realmAccessAsDict != null && realmAccessAsDict["roles"] != null)
                     {
                         foreach(var role in realmAccessAsDict["roles"])
                         {
                             roles2.AddClaim(new Claim(ClaimTypes.Role, role));        
                         }
                     }
                     Console.WriteLine("Actual role claim");

                 }

             }

             var isAdmin = roles2.HasClaim(c=> c.Type == "ADMIN");
     */


        //ClaimsTransformer


        User.HasClaim((c) => {

            if(c.Type == ClaimTypes.Role)
             Debug.WriteLine("Roleclaim " + c);
            return c.Value == ClaimTypes.Role;
        });


        var roles = User.Claims.Where(c=> c.Type == ClaimTypes.Role).Select(c=>c.Value);

        var roles3 = User.IsInRole("ADMIN");

        
        //{realm_access: {"roles":["offline_access","uma_authorization","default-roles-hvz"]}}

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
    //[Authorize]
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
