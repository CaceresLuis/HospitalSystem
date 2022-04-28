using MediatR;
using Core.Enums;
using System.Net;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Patients.Delete
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientCommand, bool>
    {
        private readonly IPatientsRepository _patientsRepository;
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;

        public DeletePatientHandler(IPatientsRepository patientsRepository, IMedicalHistoryRepository medicalHistoryRepository)
        {
            _patientsRepository = patientsRepository;
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        public async Task<bool> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = await _patientsRepository.GetPatient(request.Id) ??
                throw new ExceptionHandler(HttpStatusCode.NotFound,
                    new Error
                    {
                        Message = "The patient does not exist",
                        Title = "Error",
                        State = State.error,
                    });

            MedicalHistory history = await _medicalHistoryRepository.GetSimpleMedicalHistory(patient.Id);
            await _medicalHistoryRepository.DeleteMedicalHistory(history);
            await _patientsRepository.DeletePatient(patient);

            return true;
        }
    }
}
