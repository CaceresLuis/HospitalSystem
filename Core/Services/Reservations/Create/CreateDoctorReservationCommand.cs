using MediatR;
using Core.Dtos;

namespace Core.Services.Reservations.Create
{
    public class CreateDoctorReservationCommand : IRequest<bool>
    {
        public CreateReservationDto CreateReservationDto { get; set; }
    }
}
