using HvZWebAPI.Data;
using HvZWebAPI.Interfaces;
using HvZWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HvZWebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        public HvZDbContext _context;

        public UserRepository(HvZDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(User entity)
        {
            int rowsChanged = 0;
            _context.Users.Remove(entity);
            try
            {
                rowsChanged = await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
            Console.WriteLine("rows changed in Delete " + rowsChanged);


            return rowsChanged > 0;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public Task<bool> Update(User entity)
        {
            throw new NotImplementedException();
        }

        async Task<User?> IRepository<User>.Add(User entity)
        {

            _context.Users.Add(entity);
            int rowsAffected = await _context.SaveChangesAsync();

            if (rowsAffected == 0) return null;

            return entity;
        }
    }
}
