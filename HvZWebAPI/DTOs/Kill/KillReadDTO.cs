using HvZWebAPI.DTOs.PlayerKill;

namespace HvZWebAPI.DTOs.Kill;

public class KillReadDTO
{
        public int Id { get; set; }
        public DateTime TimeDeath { get; set; }
        public ICollection<PlayerKillReadDTO> PlayerKills { get; set; }
}