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

        public DeletePatientHandler(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
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

            return await _patientsRepository.DeletePatient(patient);
        }
    }
}
