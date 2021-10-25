using MediatR;
using System.Net;
using Core.Enums;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Patients.Update
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatientCommad, bool>
    {
        private readonly IPatientsRepository _patientsRepository;

        public UpdatePatientHandler(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task<bool> Handle(UpdatePatientCommad request, CancellationToken cancellationToken)
        {
            Dtos.PatientsDto data = request.PatientsDto;
            Patient patient = await _patientsRepository.GetPatient(data.Id) ??
                throw new ExceptionHandler(HttpStatusCode.NotFound,
                    new Error
                    {
                        Message = "The patient does not exist",
                        Title = "Error",
                        State = State.error,
                    });

            patient.FullName = data.FullName ?? patient.FullName;
            patient.Adresss = data.Adresss ?? patient.Adresss;
            patient.Document = data.Document ?? patient.Document;
            patient.Phone = data.Phone ?? patient.Phone;

            return await _patientsRepository.UpdatePatient(patient);
        }
    }
}
