using MediatR;
using Core.Dtos;

namespace Core.Services.Doctors.Update
{
    public class UpdateDoctorCommad : IRequest<bool>
    {
        public DoctorDto DoctorDto { get; set; }
    }
}
