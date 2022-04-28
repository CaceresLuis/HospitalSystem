using System;
using Infrastructure.Data;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DataContext _dataContext;

        public ScheduleRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Schedule>> GetSchedules()
        {
            return await _dataContext.Schedules.ToListAsync();
        }

        public async Task<Schedule> GetSchedule(Guid id)
        {
            return await _dataContext.Schedules.FindAsync(id);
        }

        public async Task<bool> AddSchedule(Schedule schedule)
        {
            _dataContext.Add(schedule);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSchedule(Schedule schedule)
        {
            _dataContext.Remove(schedule);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
