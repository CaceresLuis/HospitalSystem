using System;
using MediatR;

namespace Core.Services.Doctors.Delete
{
    public class DeleteDoctorCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
