using MediatR;
using Core.Dtos;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.ConsultingRoom.Read
{
    public class ReadConsultingRoomHandler : IRequestHandler<ReadConsultingRoomQuery, ConsultingRoomDto>
    {
        private readonly IMapper _mapper;
        private readonly IConsultingRoomRepository _consultingRoomRepository;

        public ReadConsultingRoomHandler(IMapper mapper, IConsultingRoomRepository consultingRoomRepository)
        {
            _mapper = mapper;
            _consultingRoomRepository = consultingRoomRepository;
        }

        public async Task<ConsultingRoomDto> Handle(ReadConsultingRoomQuery request, CancellationToken cancellationToken)
        {
            ConsultoringRoom consultoringRoom = await _consultingRoomRepository.GetConsultoringRoom(request.Id);
            return _mapper.Map<ConsultingRoomDto>(consultoringRoom);
        }
    }
}
