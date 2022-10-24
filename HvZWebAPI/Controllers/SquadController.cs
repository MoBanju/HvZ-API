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
using Microsoft.AspNetCore.Authorization;

namespace HvZWebAPI.Controllers
{
    [Route("game/")]
    [Produces("application/json")]
    [Consumes("application/json")]
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

        /// <summary>
        /// Add a squad to a game
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="squadDTO"></param>
        /// <returns></returns>
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Add a squadmember to the specified squad
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="squad_id"></param>
        /// <param name="squadMemberDTO"></param>
        /// <returns></returns>
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
            mapped.SquadId = squadMember.Id;
            mapped.PlayerId = squadMember.PlayerId;

            return CreatedAtAction("GetSquadMember", new { game_id = game_id, squad_id = squad_id, squad_member_id = mapped.Id }, mapped);
        }

        /// <summary>
        /// Adds a squad-checkin to a squad 
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="squad_id"></param>
        /// <param name="squadChekinDTO"></param>
        /// <returns></returns>
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("{game_id}/[controller]/{squad_id}/check-in")]
        public async Task<ActionResult<SquadCheckinReadDTO>> PostSquadCheckin(int game_id, int squad_id, SquadCheckinCreateDTO squadChekinDTO)
        {
            //Validate it starts before it ends
            bool IsBefore = squadChekinDTO.Start_time.CompareTo(squadChekinDTO.End_time) < 0;
            if (!IsBefore) return BadRequest(ErrorCategory.START_TIME_MUST_BE_BEFORE_ENDTIME());

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

        /// <summary>
        /// Retrieves a specific squad member by it's id
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="squad_id"></param>
        /// <param name="squad_member_id"></param>
        /// <returns></returns>
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

                var mapped = _mapper.Map<SquadMember, SquadMemberReadDTO>(sm);
                mapped.SquadId = squad_id;
                mapped.PlayerId = sm.PlayerId;

                return mapped;
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
        /// Retrieves all squads associated with a game, the number of zombies and all it's members
        /// </summary>
        /// <param name="game_id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Displays every squad-checkin a squad has made
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="squad_id"></param>
        /// <returns></returns>
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Retrieves one squad, the number of zombies and all it's members
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="squad_id"></param>
        /// <returns></returns>
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// (Admin Only) Updates the squad object, replacing it with a new one
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="squad_id"></param>
        /// <param name="squad"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin-client-role")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// (Admin-Only) Deletes a specific squad
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="squad_id"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin-client-role")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Deletes a squadmember in a squad with it's player_id
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="squad_id"></param>
        /// <param name="player_id"></param>
        /// <returns></returns>
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{game_id}/[controller]/{squad_id}/{player_id}")]
        public async Task<IActionResult> DeleteSquadMember(int game_id, int squad_id, int player_id)
        {
            try
            {
                var succueed = await _repo.DeleteMember(game_id, squad_id, player_id);
                if (!succueed)
                {
                    return NotFound(ErrorCategory.SQUADMEMBER_NOT_FOUND(squad_id, player_id));
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
