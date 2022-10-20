using HvZWebAPI.Models;

namespace HvZWebAPI.Interfaces;

public interface ISquadMemberRepository
{

    public Task<SquadMember> Add(int game_id, SquadMember squad);




}
