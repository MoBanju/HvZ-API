
using Microsoft.AspNetCore.Mvc;
using HvZWebAPI.Models;
using AutoMapper;
using HvZWebAPI.Interfaces;
using HvZWebAPI.DTOs.Kill;
using HvZWebAPI.Utils;
using Microsoft.AspNetCore.Authorization;

namespace HvZWebAPI.Controllers
{
    [Route("game/")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]

    public class KillController : ControllerBase
    {
        private readonly IKillRepository _repo;
        private readonly IMapper _mapper;

        public KillController(IMapper mapper, IKillRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        /// <summary>
        /// Retreives a list of kills, each with it's two playerkill objects where one is victim the other killr
        /// </summary>
        /// <param name="game_id"></param>
        /// <returns></returns>
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{game_id}/[controller]")]
        public async Task<ActionResult<KillReadDTO[]>> GetKills(int game_id)
        {
            try
            {
                IEnumerable<Kill> kills = await _repo.GetAllByGameId(game_id);
                KillReadDTO[] killsAsDTOs = kills.Select(kill => _mapper.Map<KillReadDTO>(kill)).ToArray();
                return killsAsDTOs;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
            }
        }

        /// <summary>
        /// Retrieves a specific kill, including two playerkill objects one is victim and the other killer.
        /// </summary>
        /// <param name="game_id">Game Id</param>
        /// <param name="kill_id">Kill Id</param>
        /// <returns></returns>
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{game_id}/[controller]/{kill_id}")]
        public async Task<ActionResult<KillReadDTO>> GetKill(int game_id, int kill_id)
        {
            try
            {
                Kill? kill = await _repo.GetById(game_id, kill_id);
                if (kill is null)
                {
                    return NotFound(ErrorCategory.FAILURE);
                }
                KillReadDTO killAsDTO = _mapper.Map<KillReadDTO>(kill);
                return killAsDTO;

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
        /// (Admin Only) Updates the kill object itself.
        /// </summary>
        /// <param name="game_id">Specified Game</param>
        /// <param name="kill_id">Specified Kill</param>
        /// <param name="killAsDTO">Kill Data Transfer Object</param>
        /// <returns></returns>
        [Authorize(Roles = "admin-client-role")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{game_id}/[controller]/{kill_id}")]
        public async Task<IActionResult> PutKill(int game_id, int kill_id, KillUpdateDTO killAsDTO)
        {
            if (kill_id != killAsDTO.Id)
            {
                return BadRequest("Id in body and url doesn't match");
            }

            try
            {
                await _repo.Update(game_id, _mapper.Map<KillUpdateDTO, Kill>(killAsDTO), killAsDTO.Bitecode);
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
        /// Adds the kill object itself.
        /// </summary>
        /// <param name="game_id">Specified Game</param>
        /// <param name="killAsDTO">Kill Data Transfer Object</param>
        /// <returns></returns>
        [Authorize]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost("{game_id}/[controller]")]
        public async Task<ActionResult<KillReadDTO>> PostKill(int game_id, KillCreateDTO killAsDTO)
        {
            Kill kill = _mapper.Map<KillCreateDTO, Kill>(killAsDTO);

            kill.GameId = game_id;
            try
            {
                Kill? savedKill = await _repo.Add(game_id, kill, killAsDTO.BiteCode, killAsDTO.KillerId ?? 0);

                if (savedKill == null)
                {
                    return BadRequest(ErrorCategory.FAILED_TO_CREATE("Kill"));
                }

                KillReadDTO mapped = _mapper.Map<Kill, KillReadDTO>(savedKill);

                return CreatedAtAction("GetKill", new { game_id = game_id, kill_id = savedKill.Id }, mapped);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorCategory.INTERNAL);
            }
        }


        /// <summary>
        /// (Admin Only) Deletes the kill object itself.
        /// </summary>
        /// <param name="game_id">Specified Game</param>
        /// <param name="kill_id">Specified Kill</param>
        /// <returns></returns>
        [Authorize(Roles = "admin-client-role")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{game_id}/[controller]/{kill_id}")]
        public async Task<IActionResult> DeleteKill(int game_id, int kill_id)
        {
            try
            {
                await _repo.Delete(game_id, kill_id);
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