using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infrastructure.Data.Entities;

namespace Infrastructure.Interfaces
{
    public interface IConsultingRoomRepository
    {
        Task<bool> AddConsultoringRoom(ConsultoringRoom consultoringRoom);
        Task<bool> DeleteConsultoringRoom(ConsultoringRoom consultoringRoom);
        Task<ConsultoringRoom> GetConsultoringRoom(Guid id);
        Task<ConsultoringRoom> GetConsultoringRoomByName(string name);
        Task<List<ConsultoringRoom>> GetConsultoringRooms();
        Task<bool> UpdateConsultoringRoom(ConsultoringRoom consultoringRoom);
    }
}
