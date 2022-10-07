namespace HvZWebAPI.DTOs.Kill;

public class KillUpdateDeleteDTO
{
        public int Id { get; set; }
        public DateTime TimeDeath { get; set; }
        public int KillerId { get; set; }
        public int VictimId { get; set; }
}