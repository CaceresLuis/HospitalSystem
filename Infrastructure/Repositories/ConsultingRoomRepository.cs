using System;
using Infrastructure.Data;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ConsultingRoomRepository : IConsultingRoomRepository
    {
        private readonly DataContext _dataContext;

        public ConsultingRoomRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddConsultoringRoom(ConsultoringRoom consultoringRoom)
        {
            _dataContext.Add(consultoringRoom);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<ConsultoringRoom> GetConsultoringRoom(Guid id)
        {
            return await _dataContext.ConsultoringRooms.FindAsync(id);
        }

        public async Task<ConsultoringRoom> GetConsultoringRoomByName(string name)
        {
            return await _dataContext.ConsultoringRooms.Where(c => c.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<ConsultoringRoom>> GetConsultoringRooms()
        {
            return await _dataContext.ConsultoringRooms.ToListAsync();
        }

        public async Task<bool> UpdateConsultoringRoom(ConsultoringRoom consultoringRoom)
        {
            _dataContext.ConsultoringRooms.Update(consultoringRoom);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteConsultoringRoom(ConsultoringRoom consultoringRoom)
        {
            _dataContext.ConsultoringRooms.Remove(consultoringRoom);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
