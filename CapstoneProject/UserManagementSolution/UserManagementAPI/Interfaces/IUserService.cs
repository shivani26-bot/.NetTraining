using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface IUserService
    {
        public Task<UserResponseDto> Login(LoginRequestDto loginRequest);
        public Task<UserResponseDto> Register(RegisterRequestDto userRequest);
        Task<UserResponseDto> GetUserById(int id);
    }
}
