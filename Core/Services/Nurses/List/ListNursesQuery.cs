using MediatR;
using Core.Dtos;
using System.Collections.Generic;

namespace Core.Services.Nurses.List
{
    public class ListNursesQuery : IRequest<List<NurseDto>>
    {
    }
}
