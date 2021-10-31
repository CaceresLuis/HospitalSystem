using MediatR;
using Core.Dtos;

namespace Core.Services.Doctors.Create
{
    public class CreateDoctorCommand : IRequest<bool>
    {
        public DoctorDto DoctorDto { get; set; }
    }
}
