using HvZWebAPI.DTOs.Chat;
using HvZWebAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HvZWebAPI.DTOs.Game;

public class GameReadDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [JsonConverter(typeof(StringEnumConverter))]
    public State State { get; set; }
}