namespace AuthenticationAPI.Models.DTOs
{
    public class UserResponseDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
