using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Contexts;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;

namespace UserManagementAPI.Repository
{
    public class UserRepository : IUserRepository<int, User> // K = int, T = User
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(int key)
        {
            // Find user by Id (UId)
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UId == key);
        }

        public async Task<ICollection<User>> GetAll()
        {
            // Get all users
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AddUser(User entity)
        {
            // Add a new user to the database
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity; // Return the added user
        }
    }
}