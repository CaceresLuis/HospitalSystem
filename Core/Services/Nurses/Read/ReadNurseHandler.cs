using MediatR;
using Core.Dtos;
using AutoMapper;
using System.Net;
using Core.Enums;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Nurses.Read
{
    public class ReadNurseHandler : IRequestHandler<ReadNurseQuery, NurseDto>
    {
        private readonly IMapper _mapper;
        private readonly INurseRepository _nurseRepository;

        public ReadNurseHandler(IMapper mapper, INurseRepository nurseRepository)
        {
            _mapper = mapper;
            _nurseRepository = nurseRepository;
        }

        public async Task<NurseDto> Handle(ReadNurseQuery request, CancellationToken cancellationToken)
        {
            Nurse nurse = await _nurseRepository.GetNurse(request.Id) ??
                throw new ExceptionHandler(HttpStatusCode.NotFound,
                    new Error
                    {
                        Message = "The nurse does not exist",
                        Title = "Error",
                        State = State.error,
                    });

            return _mapper.Map<NurseDto>(nurse);
        }
    }
}
