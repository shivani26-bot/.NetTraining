using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> RegisterUserAsync(RegisterDto registerDto);
        Task<string> AuthenticateUserAsync(LoginDto loginDto);
        Task<UserResponseDto> GetUserByIdAsync(int id);
    }
}
