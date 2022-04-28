using MediatR;
using Core.Dtos;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Infrastructure.Data.Entities;

namespace Core.Services.Doctors.List
{
    public class ListDoctorHandler : IRequestHandler<ListDoctorQuery, List<DoctorDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDoctorRepository _doctorRepository;

        public ListDoctorHandler(IMapper mapper, IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        public async Task<List<DoctorDto>> Handle(ListDoctorQuery request, CancellationToken cancellationToken)
        {
            List<Doctor> doctors = await _doctorRepository.GetDoctors();
            return _mapper.Map<List<DoctorDto>>(doctors);
        }
    }
}
