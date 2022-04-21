﻿using MediatR;
using Core.Dtos;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Repositories;
using Infrastructure.Data.Entities;

namespace Core.Services.ConsultingRoom.Read
{
    public class ReadConsultingRoomHandler : IRequestHandler<ReadConsultingRoomQuery, ConsultingRoomDto>
    {
        private readonly IMapper _mapper;
        private readonly ConsultingRoomRepository _consultingRoomRepository;

        public ReadConsultingRoomHandler(IMapper mapper, ConsultingRoomRepository consultingRoomRepository)
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
