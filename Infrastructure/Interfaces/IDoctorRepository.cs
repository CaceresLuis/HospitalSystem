using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infrastructure.Data.Entities;

namespace Infrastructure.Interfaces
{
    public interface IDoctorRepository
    {
        Task<bool> AddDoctor(Doctor doctor);
        Task<bool> DeleteDoctor(Doctor doctor);
        Task<Doctor> GetDoctor(Guid id);
        Task<List<Doctor>> GetDoctors();
        Task<bool> UpdateDoctor(Doctor doctor);
    }
}
