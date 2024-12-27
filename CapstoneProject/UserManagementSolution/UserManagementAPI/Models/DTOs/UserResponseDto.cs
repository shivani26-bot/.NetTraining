﻿namespace UserManagementAPI.Models.DTOs
{
    public class UserResponseDto
    {
        public int Id   { get; set; }
        public string Username { get; set; } = string.Empty;
        //public string LastName { get; set; }= string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public UserRole Role { get; set; }

    }
}
