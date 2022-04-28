using MediatR;
using System.Net;
using AutoMapper;
using Core.Enums;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;
using System;

namespace Core.Services.Patients.Create
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPatientsRepository _patientsRepository;
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;

        public CreatePatientHandler(IPatientsRepository patientsRepository, IMapper mapper, IMedicalHistoryRepository medicalHistoryRepository)
        {
            _mapper = mapper;
            _patientsRepository = patientsRepository;
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        public async Task<bool> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = _mapper.Map<Patient>(request.Patient);
            //returns true if the registration was made or false if it was not 
            bool save = await _patientsRepository.AddPatient(patient); 
            if(!save)
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });

            var getP = await _patientsRepository.GetPatient(request.Patient.FullName);

            MedicalHistory medicalHistory = new() { Patient = getP, DateTime = DateTime.Now };

            return await _medicalHistoryRepository.AddMedicalHistory(medicalHistory);
        }
    }
}
