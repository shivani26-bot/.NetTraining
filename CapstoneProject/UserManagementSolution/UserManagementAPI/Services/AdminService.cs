using UserManagementAPI.Contexts;
using UserManagementAPI.Interfaces;
using UserManagementAPI.Models;
using UserManagementAPI.Models.DTOs;

namespace UserManagementAPI.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;

        public AdminService(AppDbContext context)
        {
            _context = context;
        }

      

        public async Task<bool> AddDoctor(DoctorRequestDto doctorDto)
        {
            // Find the user by UId
            var user = await _context.Users.FindAsync(doctorDto.UId);
            if (user == null || user.Role != UserRole.Doctor)
            {
                // If user is not found or is not a doctor, return false
                return false;
            }

            // Create a new DoctorProfile
            var doctorProfile = new DoctorProfile
            {
                Speciality = doctorDto.Speciality,
                LicenseNumber = doctorDto.LicenseNumber,
                YearsOfExperience = doctorDto.YearsOfExperience,
                UId = doctorDto.UId // Associate the user with the doctor profile
            };

            // Add the new doctor profile to the database
            await _context.DoctorProfiles.AddAsync(doctorProfile);
            await _context.SaveChangesAsync();

            return true;
        }
    }
    }
