using System;
using MediatR;

namespace Core.Services.ConsultingRoom.Delete
{
    public class DeleteConsultingRoomCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
