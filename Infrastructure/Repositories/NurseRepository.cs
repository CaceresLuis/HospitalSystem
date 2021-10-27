using System;
using Infrastructure.Data;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class NurseRepository : INurseRepository
    {
        private readonly DataContext _dataContext;

        public NurseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Nurse> GetNurse(Guid id)
        {
            return await _dataContext.Nurses.FindAsync(id);
        }

        public async Task<List<Nurse>> GetNurses()
        {
            return await _dataContext.Nurses.ToListAsync();
        }

        public async Task<bool> AddNurse(Nurse nurse)
        {
            _dataContext.Nurses.Add(nurse);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateNurse(Nurse nurse)
        {
            _dataContext.Nurses.Update(nurse);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteNurse(Nurse nurse)
        {
            _dataContext.Nurses.Remove(nurse);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
