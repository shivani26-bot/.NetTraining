using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(UserResponseDto user);
    }
}
