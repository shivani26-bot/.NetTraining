using AuthenticationAPI.Models.DTOs;

namespace AuthenticationAPI.Interfaces
{
    public interface IUserService
    {
        public Task<UserResponseDTO> Login(LoginRequestDTO loginRequest);
        public Task<UserResponseDTO> Register(UserRegisterRequestDTO userRequest);
    }
}
