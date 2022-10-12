namespace HvZWebAPI.Models;

public class PlayerKill
{
    public bool IsVictim { get; set; }

    public Kill Kill { get; set; }
    public int KillId { get; set; }

    public Player Player { get; set; }
    public int PlayerId { get; set; }
}
