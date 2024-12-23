using AuthenticationAPI.Interfaces;
using AuthenticationAPI.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly byte[] _key;

        public TokenService(IConfiguration configuration)
        {
            _key = Encoding.UTF8.GetBytes(configuration["Keys:TokenKey"] ?? "");
        }
        public async Task<string> GenerateToken(UserResponseDTO user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var symmetricSecurityKey = new SymmetricSecurityKey(_key);
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
