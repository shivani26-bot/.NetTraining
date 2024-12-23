using AuthenticationAPI.Interfaces;
using AuthenticationAPI.Models.DTOs;
using AuthenticationAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<string, User> _repository;
        private readonly ILogger<UserService> _logger;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<string, User> repository,
                            ILogger<UserService> logger,
                            ITokenService tokenService)
        {
            _repository = repository;
            _logger = logger;
            _tokenService = tokenService;
        }
        public async Task<UserResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            var user = await _repository.Get(loginRequest.Username);
            if (user == null)
            {
                _logger.LogCritical("User login attempt failed, Invalid username");
                throw new Exception("User not found");
            }
            HMACSHA256 hmac = new HMACSHA256(user.Key);
            var password = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginRequest.Password));
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] != user.Password[i])
                {
                    _logger.LogWarning("User login attempt failed, Invalid password");
                    throw new Exception("Invalid password");
                }
            }
            var userResponse = new UserResponseDTO
            {
                Username = user.Username,
                Role = user.Role,
                Status = user.Status,
            };
            userResponse.Token = await _tokenService.GenerateToken(userResponse);
            return userResponse;
        }

        public async Task<UserResponseDTO> Register(UserRegisterRequestDTO userRequest)
        {
            HMACSHA256 hmac = new HMACSHA256();
            User user = new User();
            user.Username = userRequest.Username;
            user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRequest.Password));
            user.Role = userRequest.Role;
            user.Status = "Active";
            user.Key = hmac.Key;
            var result = await _repository.Add(user);
            if (result == null)
            {
                _logger.LogWarning("User creation failed");
                throw new Exception("User not added");
            }
            var userResponse = new UserResponseDTO
            {
                Username = user.Username,
                Role = user.Role,
                Status = user.Status,
            };
            userResponse.Token = await _tokenService.GenerateToken(userResponse);
            return userResponse;
        }
    }

}
