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

namespace Core.Services.MedicalHitories.Create
{
    public class CreateMedicalHistoryHandler : IRequestHandler<CreateMedicalHistoryCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPatientsRepository _patientsRepository;
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;

        public CreateMedicalHistoryHandler(IMapper mapper, IPatientsRepository patientsRepository, IMedicalHistoryRepository medicalHistoryRepository)
        {
            _mapper = mapper;
            _patientsRepository = patientsRepository;
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        public async Task<bool> Handle(CreateMedicalHistoryCommand request, CancellationToken cancellationToken)
        {
            MedicalHistoryDto data = request.MedicalHistoryDto;
            _ = await _patientsRepository.GetPatient(data.Patient.Id) ??
                throw new ExceptionHandler(HttpStatusCode.NotFound,
                   new Error
                   {
                       Message = "The patient does not exist",
                       Title = "Error",
                       State = State.error,
                   });

            MedicalHistory medicalHistory = _mapper.Map<MedicalHistory>(data);

            return await _medicalHistoryRepository.AddMedicalHistory(medicalHistory);
        }
    }
}
