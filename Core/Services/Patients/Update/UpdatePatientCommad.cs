using MediatR;
using Core.Dtos;

namespace Core.Services.Patients.Update
{
    public class UpdatePatientCommad : IRequest<bool>
    {
        public PatientsDto  PatientsDto { get; set; }
    }
}
