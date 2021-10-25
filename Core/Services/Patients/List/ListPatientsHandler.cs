using MediatR;
using Core.Dtos;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Infrastructure.Data.Entities;

namespace Core.Services.Patients.List
{
    public class ListPatientsHandler : IRequestHandler<ListPatientsQuery, List<PatientsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPatientsRepository _patientsRepository;

        public ListPatientsHandler(IMapper mapper, IPatientsRepository patientsRepository)
        {
            _mapper = mapper;
            _patientsRepository = patientsRepository;
        }

        public async Task<List<PatientsDto>> Handle(ListPatientsQuery request, CancellationToken cancellationToken)
        {
            List<Patient> patients = await _patientsRepository.GetPatients();

            return _mapper.Map<List<PatientsDto>>(patients);
        }
    }
}
