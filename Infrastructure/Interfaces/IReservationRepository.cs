using Infrastructure.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IReservationRepository
    {
        Task<bool> AddReservation(Reservation reservation);
        Task<Reservation> GetReservationsByDoctor(Guid id, DateTime date);
    }
}
