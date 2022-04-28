using System;
using Infrastructure.Data;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DataContext _dataContext;

        public DoctorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Doctor> GetDoctor(Guid id)
        {
            return await _dataContext.Doctors.FindAsync(id);
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _dataContext.Doctors.ToListAsync();
        }

        public async Task<bool> AddDoctor(Doctor doctor)
        {
            _dataContext.Doctors.Add(doctor);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateDoctor(Doctor doctor)
        {
            _dataContext.Doctors.Update(doctor);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteDoctor(Doctor doctor)
        {
            _dataContext.Doctors.Remove(doctor);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
