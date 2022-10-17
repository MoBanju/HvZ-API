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

    public int PlayerCount { get; set; }
    public double Ne_lat { get; set; }
    public double Ne_lng { get; set; }
    public double Sw_lat { get; set; }
    public double Sw_lng { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}