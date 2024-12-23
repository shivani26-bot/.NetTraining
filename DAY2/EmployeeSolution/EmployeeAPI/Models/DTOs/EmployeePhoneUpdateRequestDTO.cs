namespace EmployeeAPI.Models.DTOs
{
    public class EmployeePhoneUpdateRequestDTO
    {

        public int Id { get; set; }
        public string UpdatedPhone { get; set; } = string.Empty;
    }
}
