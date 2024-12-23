using AuthenticationAPI.Interfaces;
using AuthenticationAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserResponseDTO>> Login(LoginRequestDTO loginRequest)
        {
            var user = await _userService.Login(loginRequest);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserResponseDTO>> Register(UserRegisterRequestDTO registerRequest)
        {
            var user = await _userService.Register(registerRequest);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
    }
}
