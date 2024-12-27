using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models.DTOs
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        public string UserName { get; set; } = string.Empty;

        public string Email {  get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is manditory")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; } =  string.Empty ;

        [Required]
        public UserRole Role { get; set; }


       
    }

  
    }
