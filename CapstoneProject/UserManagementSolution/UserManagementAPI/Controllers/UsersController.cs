using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;
using UserManagementAPI.Services;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
      
        public UsersController(IUserService userService)
        {
            _userService = userService;
         
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserResponseDto>> Login(LoginRequestDto loginRequest)
        {
            var user = await _userService.Login(loginRequest);
            if (user == null)
            {
                //return BadRequest("Invalid user data.");
                return Unauthorized();
            }
            return Ok(user);
        }

        // POST: api/users/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequest)
        {
            if (registerRequest == null)
            {
                //return BadRequest("Invalid user data.");
                return Unauthorized();
            }

            var userResponse = await _userService.Register(registerRequest);

            if (userResponse == null)
            {
                return Conflict("User with this email already exists.");
            }
            return Ok(userResponse);
            //return CreatedAtAction(nameof(GetUserDetails), new { id = userResponse.Id }, userResponse);
        }

        // GET: api/users/{id}
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            var userResponse = await _userService.GetUserById(id);

            if (userResponse == null)
            {
                return NotFound("User not found.");
            }

            return Ok(userResponse);
        }
    }
}
