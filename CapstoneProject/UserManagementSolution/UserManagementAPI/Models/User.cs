using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace UserManagementAPI.Models
{

    public enum UserRole
    {
        Admin,
        Doctor,
        Patient
    }
    public class User : IEquatable<User>
    {
        [Key]
     public int UId { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
   
        [Required]
        public string Email { get; set; } = string.Empty;
     
        public byte[] Password { get; set; }
        public byte[] Key { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [Required]
        public UserRole Role { get; set; }
        public bool Equals(User? other)
        {
            if (other == null) return false;
            return UId == other.UId;
        }

        //navigation properties - establish relationships between the User entity and the DoctorProfile and PatientProfile entities
        public DoctorProfile? DoctorProfile { get; set; }
        public PatientProfile? PatientProfile { get; set; }

    }
}
