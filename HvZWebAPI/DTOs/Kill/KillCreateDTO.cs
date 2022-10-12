namespace HvZWebAPI.DTOs.Kill;

public class KillCreateDTO
{
        public DateTime TimeDeath { get; set; }
        public int KillerId { get; set; }
        
        public string BiteCode { get; set; }
}