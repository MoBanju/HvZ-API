using Microsoft.AspNetCore.Mvc;
using HvZWebAPI.Models;
using AutoMapper;
using HvZWebAPI.DTOs.Game;
using HvZWebAPI.Interfaces;

namespace HvZWebAPI.Controllers
{
    [Route("/game")]
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

        /// <summary>
        /// Returns a list of all games
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<GameReadDTO[]>> GetGames()
        {
            IEnumerable<Game> games = await _repo.GetAll();
            GameReadDTO[] gamesAsDTOs = games.Select(game => _mapper.Map<GameReadDTO>(game)).ToArray();
            return gamesAsDTOs;
        }

        /// <summary>
        /// Returns a specific game object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gameAsDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Updates a game, Admin only
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gameAsDto"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Creates a new game, Admin only
        /// </summary>
        /// <param name="gameAsDTO"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Deletes a game, Admin only
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
