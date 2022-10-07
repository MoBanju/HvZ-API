using HvZWebAPI.Models;

namespace HvZWebAPI.DTOs.Game;

public class GameUpdateDeleteDTO
{
        public int Id { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
}