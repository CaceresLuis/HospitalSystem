using System;
using MediatR;
using Core.Dtos;

namespace Core.Services.Quotes.Read
{
    public class ReadQuoteByDoctorQuery : IRequest<ReservationDto>
    {
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
    }
}
