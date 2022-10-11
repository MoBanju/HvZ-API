
using Microsoft.AspNetCore.Mvc;
using HvZWebAPI.Models;
using AutoMapper;
using HvZWebAPI.Interfaces;
using HvZWebAPI.DTOs.Kill;
using HvZWebAPI.Utils;

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

        [HttpGet("{gameId}/[controller]")]
        public async Task<ActionResult<KillReadDTO[]>> GetKills(int gameId)
        {
            
            IEnumerable<Kill> kills = await _repo.GetAllByGameId(gameId);
            KillReadDTO[] killsAsDTOs = kills.Select(kill => _mapper.Map<KillReadDTO>(kill)).ToArray();
            return killsAsDTOs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameId">Game Id</param>
        /// <param name="killId">Kill Id</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("{gameId}/[controller]/{killId}")]
        public async Task<ActionResult<KillReadDTO>> GetKill(int gameId, int killId)
        {
            try
            {
                Kill? kill = await _repo.GetById(gameId, killId);
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
        /// Updates the kill object itself.
        /// Admin only
        /// </summary>
        /// <param name="gameId">Specified Game</param>
        /// <param name="killId">Specified Kill</param>
        /// <param name="killAsDTO">Kill Data Transfer Object</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{gameId}/[controller]/{killId}")]
        public async Task<IActionResult> PutKill(int gameId, int killId, KillUpdateDeleteDTO killAsDTO)
        {
            if (killId != killAsDTO.Id)
            {
                return BadRequest("Id in body and url doesn't match");
            }

            try
            {
                await _repo.Update(gameId, _mapper.Map<KillUpdateDeleteDTO, Kill>(killAsDTO));
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
        /// Admin only.
        /// Also it throws error if the specified bitecode is invlid
        /// </summary>
        /// <param name="gameId">Specified Game</param>
        /// <param name="killAsDTO">Kill Data Transfer Object</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPost("{gameId}/[controller]")]
        public async Task<ActionResult<KillReadDTO>> PostKill(int gameId, KillCreateDTO killAsDTO)
        {
            Kill kill = _mapper.Map<KillCreateDTO, Kill>(killAsDTO);

            kill.GameId = gameId;
            try
            {

                Kill? savedKill = await _repo.Add(gameId, kill);

                if (savedKill == null)
                {
                    return BadRequest();
                }
                KillReadDTO mapped = _mapper.Map<Kill, KillReadDTO>(savedKill);
                //mapped.UserDTO.FirstName = savedKill

                return CreatedAtAction("GetKill", new { gameId = gameId, kill_id = savedKill.Id }, mapped);

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
        /// Deletes the kill object itself.
        /// Admin only.
        /// </summary>
        /// <param name="gameId">Specified Game</param>
        /// <param name="killId">Specified Kill</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{gameId}/[controller]/{killId}")]
        public async Task<IActionResult> DeleteKill(int gameId, int killId)
        {
            try
            {
                await _repo.Delete(gameId, killId);
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