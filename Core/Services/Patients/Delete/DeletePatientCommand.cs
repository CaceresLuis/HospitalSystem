using System;
using MediatR;

namespace Core.Services.Patients.Delete
{
    public class DeletePatientCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
