using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IPatientsRepository
    {
        Task<bool> AddPatient(Patient patient);
        Task<bool> DeletePatient(Patient patient);
        Task<Patient> GetPatient(Guid id);
        Task<List<Patient>> GetPatients();
        Task<bool> UpdatePatient(Patient patient);
    }
}
