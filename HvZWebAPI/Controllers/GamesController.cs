using Microsoft.AspNetCore.Mvc;
using HvZWebAPI.Models;
using AutoMapper;
using HvZWebAPI.DTOs.Game;
using HvZWebAPI.Interfaces;

namespace HvZWebAPI.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _repo;
        private readonly IMapper _mapper;

        public GamesController(IGameRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<GameReadDTO[]>> GetGames()
        {
            IEnumerable<Game> games = await _repo.GetAll();
            GameReadDTO[] gamesAsDTOs = games.Select(game => _mapper.Map<GameReadDTO>(game)).ToArray();
            return gamesAsDTOs;
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameReadDTO>> GetGame(int id)
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, GameUpdateDeleteDTO gameAsDto)
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
        [HttpPost]
        public async Task<ActionResult<GameReadDTO>> PostGame(GameCreateDTO gameAsDTO)
        {
            Game? game = _mapper.Map<Game>(gameAsDTO);
            game.State = State.Registration;
            game = await _repo.Add(game);
            if(game == null)
                return BadRequest();


            return CreatedAtAction("GetGame", new { id = game.Id }, _mapper.Map<GameReadDTO>(game));
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
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
