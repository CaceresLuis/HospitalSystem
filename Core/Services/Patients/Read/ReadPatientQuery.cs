using System;
using MediatR;
using Core.Dtos;

namespace Core.Services.Patients.Read
{
    public class ReadPatientQuery : IRequest<PatientsDto>
    {
        public Guid Id { get; set; }
    }
}
