using MediatR;
using Core.Dtos;
using AutoMapper;
using Core.Enums;
using System.Net;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Doctors.Read
{
    public class ReadDoctorHandler : IRequestHandler<ReadDoctorQuery, DoctorDto>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;

        public ReadDoctorHandler(IMapper mapper, IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        public async Task<DoctorDto> Handle(ReadDoctorQuery request, CancellationToken cancellationToken)
        {
            Doctor doctor = await _doctorRepository.GetDoctor(request.Id) ??
                throw new ExceptionHandler(HttpStatusCode.NotFound,
                    new Error
                    {
                        Message = "The nurse does not exist",
                        Title = "Error",
                        State = State.error,
                    });

            return _mapper.Map<DoctorDto>(doctor);
        }
    }
}
