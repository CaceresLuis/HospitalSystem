using MediatR;
using AutoMapper;
using Core.Enums;
using System.Net;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Doctors.Create
{
    public class CreateDoctorHandler : IRequestHandler<CreateDoctorCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;

        public CreateDoctorHandler(IMapper mapper, IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            Doctor doctor = _mapper.Map<Doctor>(request.DoctorDto);
            return await _doctorRepository.AddDoctor(doctor) ? true
                :
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });
        }
    }
}
