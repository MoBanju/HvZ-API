using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HvZWebAPI.DTOs.Chat;
using HvZWebAPI.Models;
using HvZWebAPI.Interfaces;

namespace HvZWebAPI.Controllers
{
    [Route("api/game")]
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

        [HttpGet("{id}/chat")]
        public async Task<ActionResult<ChatReadDTO[]>> GetGameChat(int id)
        {
            var chat = await _repo.GetChat(id);
            var chatAsDTO = chat.Select(chat => _mapper.Map<ChatReadDTO>(chat));
            return Ok(chatAsDTO);
        }

        [HttpPost("{id}/chat")]
        public async Task<IActionResult> PostGameChat(int id, ChatCreateDTO chatAsDTO)
        {
            try
            {
                Chat chat = _mapper.Map<Chat>(chatAsDTO);
                var success = await _repo.PostChat(id, chat);

                if(!success)
                    return NotFound();

                return NoContent();
            }
            catch(ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}