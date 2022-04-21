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
    public class MedicalHistoryRepository : IMedicalHistoryRepository
    {
        private readonly DataContext _dataContext;

        public MedicalHistoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<MedicalHistory> GetMedicalHistory(Guid id)
        {
            return await _dataContext.MedicalHistories
                .Include(h => h.Patient)
                .Include(h => h.Doctor)
                .Include(h => h.Quotes)
                .FirstOrDefaultAsync(h => h.Expedient == id);
        }

        public async Task<MedicalHistory> SearchPatientByExpedient(Guid expedient)
        {
            return await _dataContext.MedicalHistories
                .Include(h => h.Patient)
                .Include(h => h.Quotes)
                .ThenInclude(q => q.Reservation)
                .ThenInclude(r => r.Schedule)
                .Include(h => h.Quotes)
                .ThenInclude(q => q.Reservation)
                .ThenInclude(r => r.Doctor)
                .Where(p => p.Expedient == expedient)
                .FirstOrDefaultAsync();
        }

        public async Task<MedicalHistory> SearchPatientByDocument(string document)
        {
            return await _dataContext.MedicalHistories
                .Include(h => h.Patient)
                .Include(h => h.Quotes)
                .ThenInclude(q => q.Reservation)
                .ThenInclude(r => r.Schedule)
                .Include(h => h.Quotes)
                .ThenInclude(q => q.Reservation)
                .ThenInclude(r => r.Doctor)
                .Where(h => h.Patient.Document == document)
                .FirstOrDefaultAsync();
        }


        public async Task<List<MedicalHistory>> SearchPatientByName(string name)
        {
            return await _dataContext.MedicalHistories
                .Include(h => h.Patient)
                .Where(h => h.Patient.FullName.Contains(name))
                .ToListAsync();
        }

        public async Task<MedicalHistory> GetSimpleMedicalHistory(Guid id)
        {
            return await _dataContext.MedicalHistories
                .Include(h => h.Patient)
                .FirstOrDefaultAsync(h => h.Patient.Id == id);
        }

        public async Task<List<MedicalHistory>> GetMedicalHistories()
        {
            return await _dataContext.MedicalHistories
                .Include(h => h.Patient)
                .ToListAsync();
        }

        public async Task<bool> AddMedicalHistory(MedicalHistory medicalHistory)
        {
            _dataContext.MedicalHistories.Add(medicalHistory);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateMedicalHistory(MedicalHistory medicalHistory)
        {
            _dataContext.MedicalHistories.Update(medicalHistory);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteMedicalHistory(MedicalHistory medicalHistory)
        {
            _dataContext.MedicalHistories.Remove(medicalHistory);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
