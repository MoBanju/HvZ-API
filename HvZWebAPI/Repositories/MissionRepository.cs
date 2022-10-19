﻿using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
using HvZWebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace HvZWebAPI.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private readonly HvZDbContext _context;

        public MissionRepository(HvZDbContext context)
        {
            _context = context;
        }

        public async Task<Mission> Add(int game_id, Mission mission)
        {
            if (!GameExists(game_id)) throw new ArgumentException("Game by that id does not exist");

            mission.GameId = game_id;
            await _context.Missions.AddAsync(mission);
            
            int rowsAfected = await _context.SaveChangesAsync();
            if (rowsAfected == 0)
                return null;
            return mission;
        }

        public async Task Delete(int game_id, int mission_id)
        {
            int rowsChanged = 0;
            try
            {
                Mission mission = await FindMissionInGame(game_id, mission_id);

                _context.Missions.Remove(mission);

                rowsChanged = await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Mission>> GetAll(int game_id)
        {

            if (!GameExists(game_id)) throw new ArgumentException("Game by that id does not exsist");
            return await _context.Missions.Where(m => m.GameId == game_id).Include(m => m.Game).ToListAsync();
        }

        public async Task<Mission> GetById(int game_id, int mission_id)
        {
            Mission mission = await FindMissionInGame(game_id,mission_id);
            return mission;
        }

        public async Task Update(int game_id, Mission mission)
        {
            try
            {
                if(!MissionExists(mission.Id)) throw new ArgumentException(ErrorCategory.MISSION_NOT_FOUND(mission.Id));
                var existingMission = await FindMissionInGame(game_id,mission.Id);
                if(existingMission != null)
                {
                    _context.Entry(existingMission).State = EntityState.Detached;
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception e)
            {
                throw;
            }

        }

        private async Task<Mission> FindMissionInGame(int game_id, int mission_id)
        {
            if (!GameExists(game_id)) throw new ArgumentException("There is no game with that id");

            Mission mission = await _context.Missions.Include(m => m.Game).FirstOrDefaultAsync(m => m.Id == mission_id);
            if (mission == null) throw new ArgumentException(ErrorCategory.MISSION_NOT_FOUND(mission_id));
            if(mission.GameId != game_id) throw new ArgumentException("The kill-id you sent in is not in the game you sent in");

            return mission;
        }

        /// <summary>
        /// Checks if the game is tracked in the context
        /// </summary>
        /// <param name="game_id">Specific Game</param>
        /// <returns>Existent game</returns>
        private bool GameExists(int game_id)
        {
            return _context.Games.Any(e => e.Id == game_id);
        }

        private bool MissionExists(int mission_id)
        {
            return _context.Missions.Any(e => e.Id == mission_id);
        }
    }
}
