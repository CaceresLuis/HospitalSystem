using MediatR;
using Core.Enums;
using System.Net;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Doctors.Delete
{
    public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorCommand, bool>
    {
        private readonly IDoctorRepository _doctorRepository;

        public DeleteDoctorHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            Doctor doctor = await _doctorRepository.GetDoctor(request.Id) ??
                    throw new ExceptionHandler(HttpStatusCode.NotFound,
                        new Error
                        {
                            Message = "The doctor does not exist",
                            Title = "Error",
                            State = State.error,
                        });

            return await _doctorRepository.DeleteDoctor(doctor);
        }
    }
}
