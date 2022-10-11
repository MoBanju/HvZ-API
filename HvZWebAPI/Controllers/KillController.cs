
using Microsoft.AspNetCore.Mvc;
using HvZWebAPI.Models;
using AutoMapper;
using HvZWebAPI.Interfaces;
using HvZWebAPI.DTOs.Kill;

namespace HvZWebAPI.Controllers
{
    [Route("api/game")]
    [ApiController]
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
            /**/
        }

        // GET: api/Games/5
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("{gameId}/[controller]/{killId}")]
        public async Task<ActionResult<KillReadDTO>> GetKill(int gameId, int killId)
        {
            try
            {
                Kill? kill = await _repo.GetById(gameId, killId);
                KillReadDTO killAsDto = _mapper.Map<KillReadDTO>(kill);
                return killAsDto;

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

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{gameId}/[controller]/{killId}")]
        public async Task<IActionResult> PutKill(int gameId, int killId, KillUpdateDeleteDTO killAsDto)
        {
            if (killId != killAsDto.Id)
            {
                return BadRequest("Id in body and url doesn't match");
            }

            try
            {
                await _repo.Update(gameId, _mapper.Map<KillUpdateDeleteDTO, Kill>(killAsDto));
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


        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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


        // DELETE: api/Games/5
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