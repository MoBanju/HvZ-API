using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HvZWebAPI.Data;
using HvZWebAPI.Models;
using HvZWebAPI.Repositories;
using AutoMapper;
using System.Xml.Linq;
using Newtonsoft.Json;
using HvZWebAPI.DTOs.Player;

namespace HvZWebAPI.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerReadAdminDTO>>> GetPlayers()
        {

            List<PlayerReadAdminDTO> playersDTO = _mapper.Map<List<PlayerReadAdminDTO>>(await _repo.GetAll());

            //TODO: Keycloak, if Not ADMIN Null out the IsPatientZeroField and add JSONresult


            return new JsonResult(playersDTO, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerReadAdminDTO>> GetPlayer(int id)
        {
            var player = await _repo.GetById(id);
            if (player == null)
            {
                return NotFound();
            }


            //TODO: Keycloak, IF Not ADMIN: playerDTO.IsPatientZero = null;
            PlayerReadAdminDTO playerDTO = _mapper.Map<Player, PlayerReadAdminDTO>(player);


            //Is a type of actionresult, remember this does not typecheck
            return new JsonResult(playerDTO, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, PlayerUpdateDeleteDTO player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            bool succuess = false;

            try
            {
                succuess = await _repo.Update(_mapper.Map<PlayerUpdateDeleteDTO, Player>(player));
                if (!succuess)
                    return BadRequest();
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, internal error try again later");
            }
        }

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("game/{game_id}/player")]
        public async Task<ActionResult<Player>> PostPlayer(int game_id, PlayerCreateDTO playerDTO)
        {


            Player player = _mapper.Map<PlayerCreateDTO, Player>(playerDTO);

            player.GameId = game_id;
            try
            {

                

                Player? savedPlayer = await _repo.Add(player);




                if (savedPlayer == null)
                {
                    return BadRequest();
                }
                PlayerReadAdminDTO mapped = _mapper.Map<Player, PlayerReadAdminDTO>(savedPlayer);
                //mapped.UserDTO.FirstName = savedPlayer

                return CreatedAtAction("GetPlayer", new { id = savedPlayer.Id }, mapped);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, internal error try again later");
            }
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _repo.GetById(id);
            if (player == null)
            {
                return BadRequest();
            }

            try
            {
                bool succues = await _repo.Delete(player);
                if (succues) return NoContent();
                else return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Oops, internal error try again later");
            }
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}
