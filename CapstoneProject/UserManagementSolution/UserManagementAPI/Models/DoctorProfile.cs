using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementAPI.Models
{
    public class DoctorProfile
    {
        [Key]
        public int DId { get; set; }
    
        public string Speciality { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public int YearsOfExperience {  get; set; }
        public DateTime LicenseExpiry { get; set; }
        public int? UId { get; set; }

        [ForeignKey("UId")]
        public User? User { get; set; }//Navigation property
    }
}
