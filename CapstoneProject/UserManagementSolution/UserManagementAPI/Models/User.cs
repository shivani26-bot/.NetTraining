using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models
{

    public enum UserRole
    {
        Admin=1,
        Doctor=2,
        Patient=3
    }
    public class User : IEquatable<User>
    {
        [Key]
     public int UId { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        //[Required]
        //public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserRole Role { get; set; }



        public bool Equals(User? other)
        {
            if (other == null) return false;
            return UId == other.UId;
        }
        public DoctorProfile? DoctorProfile { get; set; }
        public PatientProfile? PatientProfile { get; set; }

    }
}
