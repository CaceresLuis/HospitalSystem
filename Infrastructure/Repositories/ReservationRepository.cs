using System;
using Infrastructure.Data;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext _dataContext;

        public ReservationRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Reservation> GetReservationsByDoctor(Guid id, DateTime date)
        {
            return await _dataContext.Reservations
                .Include(r => r.Quotes)
                .ThenInclude(q => q.MedicalHistory)
                .ThenInclude(m => m.Patient)
                .Include(r => r.Doctor)
                .Include(r => r.Schedule)
                .FirstOrDefaultAsync(q => q.Doctor.Id == id && q.Schedule.Date == date);
        }

        public async Task<bool> AddReservation(Reservation reservation)
        {
            _dataContext.Reservations.Add(reservation);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateQuote(Quote quote)
        {
            _dataContext.Quotes.Update(quote);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteQuote(Quote quote)
        {
            _dataContext.Quotes.Remove(quote);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
