using System;
using MediatR;
using Core.Dtos;

namespace Core.Services.ConsultingRoom.Read
{
    public class ReadConsultingRoomQuery : IRequest<ConsultingRoomDto>
    {
        public Guid Id { get; set; }
    }
}
