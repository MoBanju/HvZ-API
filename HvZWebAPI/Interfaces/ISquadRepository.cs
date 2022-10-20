using HvZWebAPI.Models;
using System.Collections.Generic;

namespace HvZWebAPI.Interfaces;

public interface ISquadRepository
{
    public Task<Squad> Add (int game_id, Squad squad, int player_id);
    public Task<SquadMember> AddMember (int game_id, SquadMember squad, int squad_id);
    public Task<IEnumerable<Squad>> GetAll(int game_id);
    public Task<IEnumerable<SquadCheckin>> GetAllCheckins(int game_id, int squad_id);
    public Task<Squad?> GetById(int game_id, int squad_id);
    public Task<SquadMember?> GetMemberById(int game_id, int squad_id, int squadMember_id);
    public Task<SquadCheckin> GetCheckinById(int game_id, int squad_id, int squadCheckin_id);
    public Task<bool> Update(int game_id, Squad squad);
    public Task<bool> Delete(int game_id, int squad_id);
}
