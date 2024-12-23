namespace EmployeeAPI.Models.DTOs
{
    public class UpdateEmployeeDTO
    {
        public EmployeePhoneUpdateRequestDTO? PhoneNumberChange { get; set; }
        public EmployeeSalaryUpdateRequestDTO? SalaryChange { get; set; }
    }
}
