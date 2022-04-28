using MediatR;
using Core.Enums;
using System.Net;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Reservations.Create
{
    public class CreateDoctorReservationHandler : IRequestHandler<CreateDoctorReservationCommand, bool>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IReservationRepository _reservationRepository;

        public CreateDoctorReservationHandler(IReservationRepository reservationRepository, IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task<bool> Handle(CreateDoctorReservationCommand request, CancellationToken cancellationToken)
        {
            Dtos.CreateReservationDto data = request.CreateReservationDto;
            Reservation reservationBd = await _reservationRepository.GetReservationsByDoctor(data.Doctor, data.Date);
            if (reservationBd != null && reservationBd.QuoteTotal >= 40)
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });

            Doctor doctor = await _doctorRepository.GetDoctor(data.Doctor);
            Schedule schedule = new();

            Reservation reservation = new()
            {
                Doctor = doctor,
                Schedule = schedule,
                //QuoteByhour = reservationBd.QuoteByhour + 1,
                QuoteTotal = reservationBd.QuoteTotal + 1,
            };

            return await _reservationRepository.AddReservation(reservation);
        }
    }
}
