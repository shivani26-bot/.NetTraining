using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models.DTOs;
using UserManagementAPI.Models;
using UserManagementAPI.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using UserManagementAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace UserManagementAPI.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository<int, User> _userRepository;
        private readonly IAdminService _adminService;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly ITokenService _tokenService;

        public UserService(
            IUserRepository<int, User> userRepository,
            IAdminService adminService,
            AppDbContext context,
            IMapper mapper,
            ILogger<UserService> logger,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _adminService = adminService;
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _tokenService = tokenService;
        }

        // Login method
        public async Task<UserResponseDto> Login(LoginRequestDto loginRequest)
        {
            _logger.LogInformation("Attempting login for username: {Username}", loginRequest.Username);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginRequest.Username);

            if (user == null || !VerifyPasswordHash(loginRequest.Password, user.Password, user.Key))
            {
                _logger.LogWarning("Login failed for username: {Username}. Invalid username or password.", loginRequest.Username);
                return null;
            }

            _logger.LogInformation("User logged in successfully: {Username}", loginRequest.Username);

            var userResponseDto = _mapper.Map<UserResponseDto>(user);
            // Generate the token and add it to the response DTO
            userResponseDto.Token = await _tokenService.GenerateToken(userResponseDto);

            return userResponseDto;
        }

        // Register method
        public async Task<UserResponseDto> Register(RegisterRequestDto userRequest)
        {
            _logger.LogInformation("Attempting to register a new user with email: {Email}", userRequest.Email);

            // Check if the user already exists by email
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == userRequest.Email);
            if (existingUser != null)
            {
                _logger.LogWarning("Registration failed: User with email {Email} already exists.", userRequest.Email);
                return null;
            }

            // Map RegisterRequestDto to User
            var user = _mapper.Map<User>(userRequest);

            // Generate password hash
            var passwordHash = HashPassword(userRequest.Password);
            user.Password = passwordHash.PasswordHash;
            user.Key = passwordHash.Salt;

            // Add user to the database
            var addedUser = await _userRepository.AddUser(user);
            _logger.LogInformation("New user added to the database: {Username}", user.Username);

            // If the role is Doctor, admin should add doctor profile
            if (user.Role == UserRole.Doctor)
            {
                // Admin adds doctor profile, you can call the method from IAdminService
                await _adminService.AddDoctor(new DoctorRequestDto
                {
                    Speciality = userRequest.Speciality,
                    LicenseNumber = userRequest.LicenseNumber,
                    YearsOfExperience = userRequest.YearsOfExperience,
                    UId = addedUser.UId
                });

                _logger.LogInformation("Doctor profile added for user: {Username}", user.Username);
            }

            // Map the added User to UserResponseDto
            var userResponseDto = _mapper.Map<UserResponseDto>(addedUser);
            // Generate the token and add it to the response DTO
            userResponseDto.Token = await _tokenService.GenerateToken(userResponseDto);

            return userResponseDto;
        }


        public async Task<UserResponseDto> GetUserById(int id)
        {
            // Get the user from the repository
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return null; // or handle it according to your needs
            }

            // Map User entity to UserResponseDto
            return _mapper.Map<UserResponseDto>(user);
        }
        // Password Hashing
        private (byte[] PasswordHash, byte[] Salt) HashPassword(string password)
        {
            _logger.LogInformation("Hashing password");

            var salt = new byte[128 / 8];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            var hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            );

            _logger.LogInformation("Password hashed successfully");

            return (hash, salt);
        }

        // Password verification
        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            _logger.LogInformation("Verifying password");

            var hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: storedSalt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            );

            bool isValid = hash.SequenceEqual(storedHash);

            if (isValid)
            {
                _logger.LogInformation("Password verification succeeded.");
            }
            else
            {
                _logger.LogWarning("Password verification failed.");
            }

            return isValid;
        }
    }
}
