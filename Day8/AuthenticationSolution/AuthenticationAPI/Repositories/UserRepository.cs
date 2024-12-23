using AuthenticationAPI.Contexts;
using AuthenticationAPI.Interfaces;
using AuthenticationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Repositories
{
    public class UserRepository : IRepository<string, User>
    {
        private readonly AuthenticationContext _context;

        public UserRepository(AuthenticationContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> Delete(string key)
        {
            var user = await Get(key);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Get(string key)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == key);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task<ICollection<User>> GetAll()
        {
            var users = _context.Users;
            if (users.Count() == 0)
                throw new Exception("No users found");
            return await users.ToListAsync();
        }

        public async Task<User> Update(User entity)
        {
            var user = await Get(entity.Username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
