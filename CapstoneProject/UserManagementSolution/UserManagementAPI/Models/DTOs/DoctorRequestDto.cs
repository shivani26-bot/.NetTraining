namespace UserManagementAPI.Models.DTOs
{
    public class DoctorRequestDto
    {
        public string Speciality { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; } 
        public int UId { get; set; } // This is the UserId, which links to the User
    }
}
