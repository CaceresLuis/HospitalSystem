using MediatR;
using Core.Dtos;

namespace Core.Services.Patients.Create
{
    public class CreatePatientCommand : IRequest<bool>
    {
        public PatientsDto Patient { get; set; }
    }
}
