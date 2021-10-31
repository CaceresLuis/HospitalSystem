using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infrastructure.Data.Entities;

namespace Infrastructure.Interfaces
{
    public interface IMedicalHistoryRepository
    {
        Task<MedicalHistory> GetMedicalHistory(Guid id);
        Task<List<MedicalHistory>> GetMedicalHistories();
        Task<bool> AddMedicalHistory(MedicalHistory medicalHistory);
        Task<bool> DeleteMedicalHistory(MedicalHistory medicalHistory);
        Task<bool> UpdateMedicalHistory(MedicalHistory medicalHistory);
    }
}
