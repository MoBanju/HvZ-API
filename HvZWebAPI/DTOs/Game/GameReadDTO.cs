using HvZWebAPI.DTOs.Chat;
using HvZWebAPI.Models;

namespace HvZWebAPI.DTOs.Game;

public class GameReadDTO
{
        public int Id { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
}