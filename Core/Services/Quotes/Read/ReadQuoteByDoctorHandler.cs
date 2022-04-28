using MediatR;
using Core.Dtos;
using AutoMapper;
using Core.Enums;
using System.Net;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Quotes.Read
{
    public class ReadQuoteByDoctorHandler : IRequestHandler<ReadQuoteByDoctorQuery, ReservationDto>
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;

        public ReadQuoteByDoctorHandler(IMapper mapper, IReservationRepository reservationRepository)
        {
            _mapper = mapper;
            _reservationRepository = reservationRepository;
        }

        public async Task<ReservationDto> Handle(ReadQuoteByDoctorQuery request, CancellationToken cancellationToken)
        {
            Reservation reservation = await _reservationRepository.GetReservationsByDoctor(request.DoctorId, request.Date);
            if(reservation.QuoteTotal >= 40)
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });

            //if(request.Hour == reservation.Hour)
            //    if(reservation.QuoteByhour > 5)
            //        throw new ExceptionHandler(HttpStatusCode.BadRequest,
            //       new Error
            //       {
            //           Message = "Something has gone wrong",
            //           Title = "Error",
            //           State = State.error,
            //       });

            return _mapper.Map<ReservationDto>(reservation);
        }
    }
}
