using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models.DTOs
{
    public class LoginRequestDto
    {
      

        [Required(ErrorMessage = "Username cannot be empty")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is manditory")]
        public string Password { get; set; } = string.Empty;
    }
}
