using MediatR;
using Core.Dtos;

namespace Core.Services.ConsultingRoom.Create
{
    public class CreateConsultingRoomCommand : IRequest<bool>
    {
        public ConsultingRoomDto ConsultingRoomDto { get; set; }
    }
}
