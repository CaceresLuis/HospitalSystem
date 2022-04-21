using MediatR;
using Core.Dtos;

namespace Core.Services.ConsultingRoom.Update
{
    public class UpdateconsultingRoomCommand : IRequest<bool>
    {
        public ConsultingRoomDto consultingRoomDto { get; set; }
    }
}
