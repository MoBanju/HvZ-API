namespace HvZWebAPI.DTOs.Kill;

public class KillReadDTO
{
        public int Id { get; set; }
        public DateTime TimeDeath { get; set; }
        public int KillerId { get; set; }
        public int VictimId { get; set; }
}