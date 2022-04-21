using MediatR;
using System.Net;
using Core.Enums;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.ConsultingRoom.Delete
{
    public class DeleteConsultingRoomHandler : IRequestHandler<DeleteConsultingRoomCommand, bool>
    {
        private readonly IConsultingRoomRepository _consultingRoomRepository;

        public DeleteConsultingRoomHandler(IConsultingRoomRepository consultingRoomRepository)
        {
            _consultingRoomRepository = consultingRoomRepository;
        }

        public async Task<bool> Handle(DeleteConsultingRoomCommand request, CancellationToken cancellationToken)
        {
            ConsultoringRoom consultoringRoom = await _consultingRoomRepository.GetConsultoringRoom(request.Id) ??
                    throw new ExceptionHandler(HttpStatusCode.NotFound,
                        new Error
                        {
                            Message = "The Consulting Room does not exist",
                            Title = "Error",
                            State = State.error,
                        });

            return await _consultingRoomRepository.DeleteConsultoringRoom(consultoringRoom);
        }
    }
}
