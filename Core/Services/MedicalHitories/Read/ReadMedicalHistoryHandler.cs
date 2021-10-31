using MediatR;
using Core.Dtos;
using Core.Enums;
using AutoMapper;
using System.Net;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.MedicalHitories.Read
{
    public class ReadMedicalHistoryHandler : IRequestHandler<ReadMedicalHistoryQuery, MedicalHistoryDto>
    {
        private readonly IMapper _mapper;
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;

        public ReadMedicalHistoryHandler(IMapper mapper, IMedicalHistoryRepository medicalHistoryRepository)
        {
            _mapper = mapper;
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        public async Task<MedicalHistoryDto> Handle(ReadMedicalHistoryQuery request, CancellationToken cancellationToken)
        {
            MedicalHistory medicalHistory = await _medicalHistoryRepository.GetMedicalHistory(request.Id) ??
                throw new ExceptionHandler(HttpStatusCode.NotFound,
                    new Error
                    {
                        Message = "The patient does not exist",
                        Title = "Error",
                        State = State.error,
                    });

            MedicalHistoryDto medicalHistoryDto = _mapper.Map<MedicalHistoryDto>(medicalHistory);

            return medicalHistoryDto;
        }
    }
}
