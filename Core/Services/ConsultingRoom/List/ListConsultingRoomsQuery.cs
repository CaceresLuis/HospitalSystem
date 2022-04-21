using MediatR;
using Core.Dtos;
using System.Collections.Generic;

namespace Core.Services.ConsultingRoom.List
{
    public class ListConsultingRoomsQuery : IRequest<List<ConsultingRoomDto>>
    {
    }
}
