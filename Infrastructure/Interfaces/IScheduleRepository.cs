using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infrastructure.Data.Entities;

namespace Infrastructure.Interfaces
{
    public interface IScheduleRepository
    {
        Task<bool> AddSchedule(Schedule schedule);
        Task<List<Schedule>> GetSchedules();
        Task<bool> DeleteSchedule(Schedule schedule);
        Task<Schedule> GetSchedule(Guid id);
    }
}
