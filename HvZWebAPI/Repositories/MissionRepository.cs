using HvZWebAPI.Data;
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
            if (!GameExists(game_id)) throw new ArgumentException(ErrorCategory.GAME_NOT_FOUND(game_id));
            if (await InAreaGame(mission.Latitude, mission.Longitude, game_id) is false)
                throw new ArgumentException(ErrorCategory.MISSION_OUT_GAME_AREA());

            mission.GameId = game_id;
            await _context.Missions.AddAsync(mission);

            int rowsAfected = await _context.SaveChangesAsync();
            if (rowsAfected == 0)
                throw new Exception(ErrorCategory.FAILED_TO_CREATE("Mission"));

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
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Mission>> GetAll(int game_id, string key_id, bool isAdmin)
        {
            if (!GameExists(game_id)) throw new ArgumentException("Game by that id does not exsist");

            if (!isAdmin)
            {
                User? user = await _context.Users.Include(u => u.Players).FirstOrDefaultAsync(u => u.KeyCloakId == key_id);
                if (user == null) throw new ArgumentException(ErrorCategory.USER_NOT_FOUND());
                if (user.Players == null) throw new ArgumentException(ErrorCategory.USER_HAS_NO_PLAYERS());

                var player = user.Players.FirstOrDefault(p => p.GameId == game_id);
                if (player == null) throw new ArgumentException(ErrorCategory.USER_HAS_NO_PLAYERS());

                bool seeHuman;
                seeHuman = player.IsHuman;

                return await _context.Missions.Where(m => m.GameId == game_id && m.Is_human_visible == seeHuman).ToListAsync();
            }

            return await _context.Missions.Where(m => m.GameId == game_id).Include(m => m.Game).ToListAsync();
        }

        public async Task<Mission> GetById(int game_id, int mission_id, string key_id, bool isAdmin)
        {
            User? user = await _context.Users.Include(u => u.Players).FirstOrDefaultAsync(u => u.KeyCloakId == key_id);
            if (user == null) throw new ArgumentException(ErrorCategory.USER_NOT_FOUND());
            if (user.Players == null) throw new ArgumentException(ErrorCategory.USER_HAS_NO_PLAYERS());

            var player = user.Players.FirstOrDefault(p => p.GameId == game_id);
            if (player == null) throw new ArgumentException(ErrorCategory.USER_HAS_NO_PLAYERS());

            Mission mission = await FindMissionInGame(game_id, mission_id);
            if (mission.Is_human_visible)
            {  
                if (!player.IsHuman) throw new AccessViolationException(ErrorCategory.CANT_LOOK_AT_OTHER_FACTIONS_MISSIONS()); 
            }
            else if (mission.Is_zombie_visible)
                    if (player.IsHuman) throw new AccessViolationException(ErrorCategory.CANT_LOOK_AT_OTHER_FACTIONS_MISSIONS());

            return mission;
        }

        public async Task Update(int game_id, Mission mission)
        {
            try
            {
                if (!GameExists(game_id)) throw new ArgumentException(ErrorCategory.GAME_NOT_FOUND(game_id));
                if (!MissionExists(game_id, mission.Id)) throw new ArgumentException(ErrorCategory.MISSION_NOT_FOUND(mission.Id));
                if (await InAreaGame(mission.Latitude, mission.Longitude, game_id) is false)
                    throw new ArgumentException(ErrorCategory.MISSION_OUT_GAME_AREA());

                var existingMission = await _context.Missions.FindAsync(mission.Id);
                if (existingMission != null)
                    _context.Entry(existingMission).State = EntityState.Detached;
                else throw new ArgumentException(ErrorCategory.MISSION_NOT_FOUND(mission.Id));

                mission.GameId = game_id;
                _context.Update(mission);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }



        private async Task<Mission> FindMissionInGame(int game_id, int mission_id)
        {
            if (!GameExists(game_id)) throw new ArgumentException("There is no game with that id");


            Mission mission = await _context.Missions.Include(m => m.Game).FirstOrDefaultAsync(m => m.Id == mission_id);
            if (mission == null) throw new ArgumentException(ErrorCategory.MISSION_NOT_FOUND(mission_id));
            if (mission.GameId != game_id) throw new ArgumentException("The kill-id you sent in is not in the game you sent in");

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

        /// <summary>
        /// Checks both if mission exsists and if it has the gameid supplied
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="mission_id"></param>
        /// <returns>true if mission exists with the game id supplied</returns>
        private bool MissionExists(int game_id, int mission_id)
        {
            var mission = _context.Missions.FirstOrDefault(e => e.Id == mission_id);

            if (mission == null)
            {
                return false;
            }
            if (mission.GameId != game_id)
            {
                return false;
            }

            return true;
        }

        private async Task<bool> InAreaGame(double? mission_lat, double? mission_long, int game_id)
        {
            Game? game = await _context.Games.FindAsync(game_id);
            if (mission_lat < game.Sw_lat || mission_lat > game.Ne_lat || mission_long < game.Sw_lng || mission_long > game.Ne_lng)
                return false;
            return true;
        }
    }
}
