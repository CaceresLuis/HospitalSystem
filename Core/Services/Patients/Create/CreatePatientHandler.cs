using MediatR;
using System.Net;
using AutoMapper;
using Core.Enums;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Patients.Create
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPatientsRepository _patientsRepository;

        public CreatePatientHandler(IPatientsRepository patientsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _patientsRepository = patientsRepository;
        }

        public async Task<bool> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = _mapper.Map<Patient>(request.Patient);
             if(!await _patientsRepository.AddPatient(patient))
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                    new Error
                    {
                        Message = "Something has gone wrong",
                        Title = "Error",
                        State = State.error,
                    });

            return true;
        }
    }
}
