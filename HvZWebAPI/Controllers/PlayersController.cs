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

namespace HvZWebAPI.Controllers
{
    [Route("game/")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly HvZDbContext _context;
        private readonly IPlayerRepository _repo;
        private readonly IMapper _mapper;

        public PlayersController(HvZDbContext context, IPlayerRepository repo, IMapper mapper)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/Players
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
            }
            //TODO: Keycloak, if Not ADMIN Null out the IsPatientZeroField and add JSONresult
            return new JsonResult(playersDTO, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        // GET: api/Players/5
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
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, internal error try again later");
            }
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{game_id}/[controller]/{player_id}")]
        public async Task<IActionResult> PutPlayer(int game_id, int player_id, PlayerUpdateDeleteDTO player)
        {
            if (player_id != player.Id)
            {
                return BadRequest("Id in body and url doesn't match");
            }

            try
            {
                await _repo.Update(game_id, _mapper.Map<PlayerUpdateDeleteDTO, Player>(player));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, internal error try again later");
            }
            return NoContent();
        }

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{game_id}/[controller]")]
        public async Task<ActionResult<Player>> PostPlayer(int game_id, PlayerCreateDTO playerDTO)
        {
            Player player = _mapper.Map<PlayerCreateDTO, Player>(playerDTO);

            player.GameId = game_id;
            try
            {

                Player? savedPlayer = await _repo.Add(game_id, player);

                if (savedPlayer == null)
                {
                    return BadRequest();
                }
                PlayerReadAdminDTO mapped = _mapper.Map<Player, PlayerReadAdminDTO>(savedPlayer);
                //mapped.UserDTO.FirstName = savedPlayer

                return CreatedAtAction("GetPlayer", new { game_id = game_id, player_id = savedPlayer.Id }, mapped);

            }catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, internal error try again later");
            }
        }

        // DELETE: api/Players/5
        [HttpDelete("{game_id}/[controller]/{player_id}")]
        public async Task<IActionResult> DeletePlayer(int game_id, int player_id)
        {
            try
            {
               await _repo.Delete(game_id, player_id);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, internal error try again later");
            }
            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}
