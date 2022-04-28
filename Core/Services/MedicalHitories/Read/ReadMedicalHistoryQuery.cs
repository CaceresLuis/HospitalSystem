using System;
using MediatR;
using Core.Dtos;

namespace Core.Services.MedicalHitories.Read
{
    public class ReadMedicalHistoryQuery : IRequest<MedicalHistoryDto>
    {
        public Guid Id { get; set; }
    }
}
