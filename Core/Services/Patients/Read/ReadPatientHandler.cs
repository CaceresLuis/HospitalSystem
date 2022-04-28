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

namespace Core.Services.Patients.Read
{
    public class ReadPatientHandler : IRequestHandler<ReadPatientQuery, PatientsDto>
    {
        private readonly IMapper _mapper;
        private readonly IPatientsRepository _patientsRepository;

        public ReadPatientHandler(IMapper mapper, IPatientsRepository patientsRepository)
        {
            _mapper = mapper;
            _patientsRepository = patientsRepository;
        }

        public async Task<PatientsDto> Handle(ReadPatientQuery request, CancellationToken cancellationToken)
        {
            //if null, it returns the exception
            Patient patient = await _patientsRepository.GetPatient(request.Id) ??
                throw new ExceptionHandler(HttpStatusCode.NotFound,
                    new Error
                    {
                        Message = "The patient does not exist",
                        Title = "Error",
                        State = State.error,
                    });

            PatientsDto patientDto = _mapper.Map<PatientsDto>(patient);

            return patientDto;
        }
    }
}
