using MediatR;
using Core.Dtos;
using Core.Enums;
using System.Net;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Doctors.Update
{
    public class UpdateDoctorHandler : IRequestHandler<UpdateDoctorCommad, bool>
    {
        private readonly IDoctorRepository _doctorRepository;

        public UpdateDoctorHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> Handle(UpdateDoctorCommad request, CancellationToken cancellationToken)
        {
            DoctorDto data = request.DoctorDto;
            Doctor doctor = await _doctorRepository.GetDoctor(data.Id) ??
                throw new ExceptionHandler(HttpStatusCode.NotFound,
                    new Error
                    {
                        Message = "The nurse does not exist",
                        Title = "Error",
                        State = State.error,
                    });

            doctor.FullName = data.FullName ?? doctor.FullName;
            doctor.Adresss = data.Adresss ?? doctor.Adresss;
            doctor.Document = data.Document ?? doctor.Document;
            doctor.Phone = data.Phone ?? doctor.Phone;

            return await _doctorRepository.UpdateDoctor(doctor);
        }
    }
}
