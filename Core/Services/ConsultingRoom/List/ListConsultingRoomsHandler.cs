using MediatR;
using Core.Dtos;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Infrastructure.Data.Entities;

namespace Core.Services.ConsultingRoom.List
{
    public class ListConsultingRoomsHandler : IRequestHandler<ListConsultingRoomsQuery, List<ConsultingRoomDto>>
    {
        private readonly IMapper _mapper;
        private readonly IConsultingRoomRepository _consultingRoomRepository;

        public ListConsultingRoomsHandler(IMapper mapper, IConsultingRoomRepository consultingRoomRepository)
        {
            _mapper = mapper;
            _consultingRoomRepository = consultingRoomRepository;
        }

        public async Task<List<ConsultingRoomDto>> Handle(ListConsultingRoomsQuery request, CancellationToken cancellationToken)
        {
            List<ConsultoringRoom> list = await _consultingRoomRepository.GetConsultoringRooms();
            return _mapper.Map<List<ConsultingRoomDto>>(list);
        }
    }
}
