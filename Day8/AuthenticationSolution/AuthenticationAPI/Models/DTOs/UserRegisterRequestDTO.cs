using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Models.DTOs
{
    public class UserRegisterRequestDTO
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is manditory")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
