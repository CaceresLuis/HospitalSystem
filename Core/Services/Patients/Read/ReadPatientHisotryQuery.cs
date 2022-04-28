using System;
using MediatR;
using Core.Dtos;

namespace Core.Services.Patients.Read
{
    public class ReadPatientHisotryQuery : IRequest<MedicalHistoryDto>
    {
        public Guid Id { get; set; }
    }
}
