using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; } = string.Empty;
        public byte[] Password { get; set; }
        public byte[] Key { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
