
using Microsoft.AspNetCore.Mvc;
using HvZWebAPI.Models;
using AutoMapper;
using HvZWebAPI.Interfaces;

namespace HvZWebAPI.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class KillController : ControllerBase
    {
        private readonly IKillRepository _repo;
        private readonly IMapper _mapper;

        public KillController(IMapper mapper, IGameRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{gameId}/kill")]
        public async Task<ActionResult<KillReadDTO[]>> GetKills(int gameId)
        {
            
            IEnumerable<Kill> kills = await _repo.GetAllByGameId(gameId);
            KillReadDTO[] killsAsDTOs = kills.Select(kill => _mapper.Map<KillReadDTO>(kill)).ToArray();
            return killsAsDTOs;
            /**/
        }

        // GET: api/Games/5
        [HttpGet("{gameId}/kill/{killId}")]
        public async Task<ActionResult<GameReadDTO>> GetKill(int gameId, int killId)
        {
            Game? game = await _repo.GetById(id);
            if (game is null)
            {
                return NotFound();
            }

            GameReadDTO gameAsDto = _mapper.Map<GameReadDTO>(game);

            return gameAsDto;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{gameId}/kill/{killId}")]
        public async Task<IActionResult> PutKill(int gameId, int killId, GameUpdateDeleteDTO gameAsDto)
        {
            if(id != gameAsDto.Id) {
                return BadRequest();
            }

            Game game = _mapper.Map<Game>(gameAsDto);
            Boolean success = await _repo.Update(game);

            if(!success) {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{gameId}/kill")]
        public async Task<ActionResult<GameReadDTO>> PostKill(int gameId, GameCreateDTO gameAsDTO)
        {
            Game? game = _mapper.Map<Game>(gameAsDTO);
            game.State = State.Registration;
            game = await _repo.Add(game);
            if(game == null)
                return BadRequest();


            return CreatedAtAction("GetGame", new { id = game.Id }, _mapper.Map<GameReadDTO>(game));
        }

        // DELETE: api/Games/5
        [HttpDelete("{gameId}/kill/{killId}")]
        public async Task<IActionResult> DeleteKill(int gameId, int killId)
        {
            Game? game = await _repo.GetById(id);

            if(game is null)
                return NotFound();

            Boolean success = await _repo.Delete(game);

            if(!success)
                return NotFound();

            return NoContent();
        }
    }
}