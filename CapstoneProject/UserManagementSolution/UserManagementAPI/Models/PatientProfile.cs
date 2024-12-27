using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementAPI.Models
{
    public class PatientProfile
    {
        [Key]
        public int PId { get; set; }
     

        public string  MedicalHistory { get; set; }=string.Empty;
        public string InsuranceDetails { get; set; } = string.Empty;
        public int? UId { get; set; }

        [ForeignKey("UId")]
        public User? User { get; set; }//Navigation property
    }
}
