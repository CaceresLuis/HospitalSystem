using System;
using MediatR;
using Core.Dtos;

namespace Core.Services.Doctors.Read
{
    public class ReadDoctorQuery : IRequest<DoctorDto>
    {
        public Guid Id { get; set; }
    }
}
