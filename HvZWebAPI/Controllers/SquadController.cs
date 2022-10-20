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
using HvZWebAPI.DTOs.SquadMember;
using HvZWebAPI.Migrations;
using HvZWebAPI.DTOs.SquadCheckin;

namespace HvZWebAPI.Controllers
{
    [Route("game/")]
    [ApiController]
    public class SquadController : ControllerBase
    {
        private readonly ISquadRepository _repo;
        private readonly IMapper _mapper;


        public SquadController(ISquadRepository repo, IMapper mapper)
        {
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

        [HttpPost("{game_id}/[controller]/{squad_id}/join")]
        public async Task<ActionResult<SquadMemberReadDTO>> PostSquadMember(int game_id, int squad_id, SquadMemberCreateDTO squadMemberDTO)
        {
            SquadMember squadMember = _mapper.Map<SquadMemberCreateDTO, SquadMember>(squadMemberDTO);

            try
            {
                var squadMemberSaved = await _repo.AddMember(game_id, squadMember, squad_id);
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

            SquadMemberReadDTO mapped = _mapper.Map<SquadMember, SquadMemberReadDTO>(squadMember);


            return CreatedAtAction("GetSquadMember", new { game_id = game_id, squad_id = squad_id, squad_member_id = mapped.Id }, mapped);
        }

        [HttpPost("{game_id}/[controller]/{squad_id}/check-in")]
        public async Task<ActionResult<SquadCheckinReadDTO>> PostSquadCheckin(int game_id, int squad_id, SquadCheckinCreateDTO squadChekinDTO)
        {
            SquadCheckin squadCheckin = _mapper.Map<SquadCheckinCreateDTO, SquadCheckin>(squadChekinDTO);

            try
            {
                var squadCheckinSaved = await _repo.AddCheckin(game_id, squadCheckin, squad_id);
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

            SquadCheckinReadDTO mapped = _mapper.Map<SquadCheckin, SquadCheckinReadDTO>(squadCheckin);


            return CreatedAtAction("GetSquadMember", new { game_id = game_id, squad_id = squad_id, squad_member_id = mapped.Id }, mapped);
        }

        [HttpGet("{game_id}/[controller]/{squad_id}/{squad_member_id}")]
        public async Task<ActionResult<SquadMemberReadDTO>> GetSquadMember(int game_id, int squad_id, int squad_member_id)
        {
            try
            {

                SquadMember? sm = await _repo.GetMemberById(game_id, squad_id, squad_member_id);
                if (sm == null)
                {
                    return NotFound();
                }
                return _mapper.Map<SquadMember, SquadMemberReadDTO>(sm);
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

        [HttpGet("{game_id}/[controller]")]
        public async Task<ActionResult<IEnumerable<SquadReadDTO>>> GetSquads(int game_id)
        {
            try
            {
                var squads = await _repo.GetAll(game_id);

                //Count the squads with squadmembers that are deseased
                List<SquadReadDTO> squadsDTO = new List<SquadReadDTO>();
                foreach(Squad sq in squads)
                {
                    var squadDTO = _mapper.Map<SquadReadDTO>(sq);
                    squadDTO.DeseasedPlayers = sq.Squad_Members.Count(sm => !sm.Player.IsHuman);
                    squadsDTO.Add(squadDTO);
                }

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

        [HttpGet("{game_id}/[controller]/{squad_id}/check-in")]
        public async Task<ActionResult<IEnumerable<SquadCheckinReadDTO>>> GetSquadCheckins(int game_id, int squad_id)
        {
            try
            {
                var checkins = await _repo.GetAllCheckins(game_id, squad_id);
                var checkinDTO = _mapper.Map<List<SquadCheckinReadDTO>>(checkins);

                return checkinDTO;
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
        public async Task<IActionResult> PutSquad(int game_id, int squad_id, SquadUpdateDTO squad)
        {
            if (squad_id != squad.Id)
            {
                return BadRequest();
            }

            try
            {
                var succueed = await _repo.Update(game_id, _mapper.Map<SquadUpdateDTO, Squad>(squad));
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

            try
            {
                var succueed = await _repo.Delete(game_id, squad_id);
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
    }
}
