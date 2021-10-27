using MediatR;
using AutoMapper;
using Core.Enums;
using System.Net;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Nurses.Create
{
    public class CreateNurseHandler : IRequestHandler<CreateNurseCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly INurseRepository _nurseRepository;

        public CreateNurseHandler(IMapper mapper, INurseRepository nurseRepository)
        {
            _mapper = mapper;
            _nurseRepository = nurseRepository;
        }

        public async Task<bool> Handle(CreateNurseCommand request, CancellationToken cancellationToken)
        {
            Nurse nurse = _mapper.Map<Nurse>(request.NurseDto);
            return await _nurseRepository.AddNurse(nurse) ? true
                :
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });
        }
    }
}
