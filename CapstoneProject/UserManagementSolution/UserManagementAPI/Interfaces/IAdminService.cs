using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Interfaces
{
    public interface IAdminService
    {
        public Task<bool> AddDoctor(DoctorRequestDto user);
    }
}
