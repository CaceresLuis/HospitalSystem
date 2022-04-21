using MediatR;
using AutoMapper;
using Core.Enums;
using System.Net;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.ConsultingRoom.Create
{
    public class CreateConsultingRoomHandler : IRequestHandler<CreateConsultingRoomCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IConsultingRoomRepository _consultingRoomRepository;

        public CreateConsultingRoomHandler(IMapper mapper, IConsultingRoomRepository consultingRoomRepository)
        {
            _mapper = mapper;
            _consultingRoomRepository = consultingRoomRepository;
        }

        public async Task<bool> Handle(CreateConsultingRoomCommand request, CancellationToken cancellationToken)
        {
            ConsultoringRoom consultingRoom = _mapper.Map<ConsultoringRoom>(request.ConsultingRoomDto);

            return await _consultingRoomRepository.AddConsultoringRoom(consultingRoom) ? true : throw new ExceptionHandler(HttpStatusCode.BadRequest,
                new Error
                {
                    Message = "Something has gone wrong",
                    Title = "Error",
                    State = State.error,
                });
        }
    }
}
