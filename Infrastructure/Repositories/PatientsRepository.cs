using System;
using System.Linq;
using Infrastructure.Data;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly DataContext _dataContext;

        public PatientsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Patient> GetPatient(Guid id)
        {
            return await _dataContext.Patients.FindAsync(id);
        }
        
        public async Task<Patient> GetPatient(string name)
        {
            return await _dataContext.Patients
                .Where(p => p.FullName == name)
                .FirstOrDefaultAsync();
        }
        
        public async Task<List<Patient>> GetPatients()
        {
            return await _dataContext.Patients.ToListAsync();
        }

        public async Task<bool> AddPatient(Patient patient)
        {
            _dataContext.Patients.Add(patient);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePatient(Patient patient)
        {
            _dataContext.Patients.Update(patient);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePatient(Patient patient)
        {
            _dataContext.Patients.Remove(patient);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
