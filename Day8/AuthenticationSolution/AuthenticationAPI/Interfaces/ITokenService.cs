using AuthenticationAPI.Models.DTOs;

namespace AuthenticationAPI.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(UserResponseDTO user);
    }
}
