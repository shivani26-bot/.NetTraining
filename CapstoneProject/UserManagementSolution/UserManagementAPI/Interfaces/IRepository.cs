using UserManagementAPI.Models;

namespace UserManagementAPI.Interfaces
{
    public interface IRepository
    {
        Task<User> RegisterUserAsync(User user);
        Task<User> AuthenticateUserAsync(string email, string password);
        Task<User> GetUserByIdAsync(int id);
    }
}
