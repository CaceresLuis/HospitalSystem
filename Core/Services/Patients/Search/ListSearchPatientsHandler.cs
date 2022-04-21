using System;
using MediatR;
using Core.Dtos;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Patients.Search
{
    public class ListSearchPatientsHandler : IRequestHandler<ListSearchPatientsQuery, MedicalHistoryDto>
    {
        private readonly IMapper _mapper;
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;

        public ListSearchPatientsHandler(IMapper mapper, IMedicalHistoryRepository medicalHistoryRepository)
        {
            _mapper = mapper;
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        public async Task<MedicalHistoryDto> Handle(ListSearchPatientsQuery request, CancellationToken cancellationToken)
        {
            SearchPatientDto search = request.SearchPatientDto;
            if (request.SearchPatientDto.Parameter == 1)
            {
                Guid exp = Guid.Parse(search.DataSearch);
                MedicalHistory data = await _medicalHistoryRepository.SearchPatientByExpedient(exp);
                return _mapper.Map<MedicalHistoryDto>(data);
            }
            else
            {
                MedicalHistory medicalHistory = await _medicalHistoryRepository.SearchPatientByDocument(search.DataSearch);
                return _mapper.Map<MedicalHistoryDto>(medicalHistory);
            }
        }
    }
}
