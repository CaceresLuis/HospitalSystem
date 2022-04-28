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
    public class ListPatientsHandler : IRequestHandler<ListPatientsQuery, List<MedicalHistoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPatientsRepository _patientsRepository;
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;

        public ListPatientsHandler(IMapper mapper, IPatientsRepository patientsRepository, IMedicalHistoryRepository medicalHistoryRepository)
        {
            _mapper = mapper;
            _patientsRepository = patientsRepository;
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        public async Task<List<MedicalHistoryDto>> Handle(ListPatientsQuery request, CancellationToken cancellationToken)
        {
            //List<Patient> patients = await _patientsRepository.GetPatients();
            //return _mapper.Map<List<PatientsDto>>(patients);

            List<MedicalHistory> medicalHistories = await _medicalHistoryRepository.GetMedicalHistories();
            return _mapper.Map<List<MedicalHistoryDto>>(medicalHistories);
        }
    }
}
