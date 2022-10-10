using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HvZWebAPI.DTOs.Chat;
using HvZWebAPI.Models;
using HvZWebAPI.Interfaces;
using HvZWebAPI.DTOs.Player;

namespace HvZWebAPI.Controllers
{
    [Route("game")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _repo;
        private readonly IMapper _mapper;

        public ChatController(IChatRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{game_id}/chat")]
        public async Task<ActionResult<ChatReadDTO[]>> GetGameChats(int game_id)
        {
            var chat = await _repo.GetChats(game_id);
            var chatAsDTO = chat.Select(chat => _mapper.Map<ChatReadDTO>(chat));
            return Ok(chatAsDTO);
        }



        [HttpGet("{game_id}/chat/{chat_id}")]
        public async Task<ActionResult<ChatReadDTO[]>> GetGameChat(int game_id, int chat_id)
        {
            var chat = await _repo.GetChat(game_id, chat_id);
            var chatAsDTO = _mapper.Map<ChatReadDTO>(chat);
            return Ok(chatAsDTO);
        }

        [HttpPost("{game_id}/chat")]
        public async Task<ActionResult<ChatReadDTO>> PostGameChat(int game_id, ChatCreateDTO chatAsDTO)
        {
            try
            {
                Chat chat = _mapper.Map<Chat>(chatAsDTO);
                var chatDTO = _mapper.Map<Chat, ChatReadDTO>(await _repo.PostChat(game_id, chat));


                if (chatDTO == null)
                    return NotFound();

                return CreatedAtAction("GetGameChat", new { game_id = game_id, chat_id = chat.Id }, chatDTO);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}