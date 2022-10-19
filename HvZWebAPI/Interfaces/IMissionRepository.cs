using HvZWebAPI.Models;

namespace HvZWebAPI.Interfaces
{
    public interface IMissionRepository //: IRepository<Mission>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game_id"></param>
        /// <returns></returns>
        public Task<IEnumerable<Mission>> GetAll(int game_id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="mission_id"></param>
        /// <returns></returns>
        public Task<Mission> GetById(int game_id, int mission_id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="mission"></param>
        /// <returns></returns>
        public Task<Mission> Add(int game_id, Mission mission);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="mission"></param>
        /// <returns></returns>
        public Task Update(int game_id, Mission mission);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game_id"></param>
        /// <param name="mission_id"></param>
        /// <returns></returns>
        public Task Delete(int game_id, int mission_id);
    }
}
