using MediatR;
using Core.Dtos;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infrastructure.Repositories;
using Infrastructure.Data.Entities;

namespace Core.Services.ConsultingRoom.List
{
    public class ListConsultingRoomsHandler : IRequestHandler<ListConsultingRoomsQuery, List<ConsultingRoomDto>>
    {
        private readonly IMapper _mapper;
        private readonly ConsultingRoomRepository _consultingRoomRepository;

        public ListConsultingRoomsHandler(IMapper mapper, ConsultingRoomRepository consultingRoomRepository)
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
