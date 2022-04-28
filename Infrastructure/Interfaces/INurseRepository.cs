using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infrastructure.Data.Entities;

namespace Infrastructure.Interfaces
{
    public interface INurseRepository
    {
        Task<bool> AddNurse(Nurse nurse);
        Task<bool> DeleteNurse(Nurse nurse);
        Task<Nurse> GetNurse(Guid id);
        Task<List<Nurse>> GetNurses();
        Task<bool> UpdateNurse(Nurse nurse);
    }
}
