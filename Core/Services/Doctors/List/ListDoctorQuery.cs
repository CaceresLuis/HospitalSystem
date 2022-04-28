using MediatR;
using Core.Dtos;
using System.Collections.Generic;

namespace Core.Services.Doctors.List
{
    public class ListDoctorQuery : IRequest<List<DoctorDto>>
    {
    }
}
