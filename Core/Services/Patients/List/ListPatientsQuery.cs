using MediatR;
using Core.Dtos;
using System.Collections.Generic;

namespace Core.Services.Patients.List
{
    public class ListPatientsQuery : IRequest<List<MedicalHistoryDto>>
    {
    }
}
