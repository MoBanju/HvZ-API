using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HvZWebAPI.Data;
using HvZWebAPI.Models;
using HvZWebAPI.Interfaces;
using HvZWebAPI.DTOs.Squad;
using AutoMapper;
using HvZWebAPI.DTOs.Player;
using HvZWebAPI.Utils;

namespace HvZWebAPI.Controllers
{
    [Route("game/")]
    [ApiController]
    public class SquadController : ControllerBase
    {
        private readonly HvZDbContext _context;
        private readonly ISquadRepository _repo;
        private readonly IMapper _mapper;


        public SquadController(HvZDbContext context, ISquadRepository repo, IMapper mapper)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
        }

        // POST: api/Squad
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{game_id}/[controller]")]
        public async Task<ActionResult<SquadReadDTO>> PostSquad(int game_id, SquadCreateDTO squadDTO)
        {
            Squad squad = _mapper.Map<SquadCreateDTO, Squad>(squadDTO);
            try
            {
                await _repo.Add(game_id, squad, squadDTO.SquadMember.PlayerId);
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
            SquadReadDTO readDTO = _mapper.Map<Squad, SquadReadDTO>(squad);

            return CreatedAtAction("GetSquad", new { game_id = game_id, squad_id = squad.Id }, readDTO);
        }
        // GET: api/Squad
        [HttpGet("{game_id}/[controller]")]
        public async Task<ActionResult<IEnumerable<SquadReadDTO>>> GetSquads(int game_id)
        {

            try
            {
                var squads = await _repo.GetAll(game_id);
                var squadsDTO = _mapper.Map<List<SquadReadDTO>>(squads);

                return squadsDTO;
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

        // GET: api/Squad/5
        [HttpGet("{game_id}/[controller]/{squad_id}")]
        public async Task<ActionResult<SquadReadDTO>> GetSquad(int game_id, int squad_id)
        {
            try
            {
                var squad = await _repo.GetById(game_id, squad_id);
                if (squad == null)
                {
                    return NotFound();
                }
                return _mapper.Map<Squad, SquadReadDTO>(squad);
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

        // PUT: api/Squad/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{game_id}/[controller]/{squad_id}")]
        public async Task<IActionResult> PutSquad(int game_id, int squad_id, Squad squad)
        {
            if (squad_id != squad.Id)
            {
                return BadRequest();
            }
            try
            {
                var succueed = await _repo.Update(game_id, squad);
                if (!succueed)
                {
                    return NotFound(ErrorCategory.SQUAD_NOT_FOUND(game_id, squad_id));
                }
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


        // DELETE: api/Squad/5
        [HttpDelete("{game_id}/[controller]/{squad_id}")]
        public async Task<IActionResult> DeleteSquad(int game_id, int squad_id)
        {
            var succueed = await _repo.Delete(game_id, squad_id);
            if (!succueed)
            {
                return NotFound(ErrorCategory.SQUAD_NOT_FOUND(game_id, squad_id));
            }

            return NoContent();
        }

        private bool SquadExists(int id)
        {
            return _context.Squads.Any(e => e.Id == id);
        }
    }
}
