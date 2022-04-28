using MediatR;
using Core.Dtos;
using System.Collections.Generic;

namespace Core.Services.Patients.Search
{
    public class ListSearchPatientsQuery : IRequest<MedicalHistoryDto>
    {
        public SearchPatientDto SearchPatientDto { get; set; }
    }
}
