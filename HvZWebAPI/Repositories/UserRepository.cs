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

        public async Task<bool> Delete(int id)
        {

            User? user = await _context.Users.FindAsync(id);

            if (user is null)
                return false;

            _context.Remove(user);
            return await _context.SaveChangesAsync() > 0;
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

            await _context.Users.AddAsync(entity);
            int rowsAffected = await _context.SaveChangesAsync();

            if (rowsAffected == 0) return null;

            return entity;
        }
    }
}
