using MediatR;
using Core.Dtos;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Infrastructure.Data.Entities;

namespace Core.Services.Nurses.List
{
    public class ListNursesHandler : IRequestHandler<ListNursesQuery, List<NurseDto>>
    {
        private readonly IMapper _mapper;
        private readonly INurseRepository _nurseRepository;

        public ListNursesHandler(IMapper mapper, INurseRepository nurseRepository)
        {
            _mapper = mapper;
            _nurseRepository = nurseRepository;
        }

        public async Task<List<NurseDto>> Handle(ListNursesQuery request, CancellationToken cancellationToken)
        {
            List<Nurse> nurses = await _nurseRepository.GetNurses();
            return _mapper.Map<List<NurseDto>>(nurses);
        }
    }
}
