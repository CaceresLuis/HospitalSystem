using MediatR;
using System.Net;
using Core.Enums;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.ConsultingRoom.Update
{
    public class UpdateconsultingRoomHandler : IRequestHandler<UpdateconsultingRoomCommand, bool>
    {
        private readonly IConsultingRoomRepository _consultingRoomRepository;

        public UpdateconsultingRoomHandler(IConsultingRoomRepository consultingRoomRepository)
        {
            _consultingRoomRepository = consultingRoomRepository;
        }

        public async Task<bool> Handle(UpdateconsultingRoomCommand request, CancellationToken cancellationToken)
        {
            Dtos.ConsultingRoomDto data = request.consultingRoomDto;
            ConsultoringRoom consultoringRoom = await _consultingRoomRepository.GetConsultoringRoom(data.Id) ??
                throw new ExceptionHandler(HttpStatusCode.NotFound,
                    new Error
                    {
                        Message = "The Consultoring room does not exist",
                        Title = "Error",
                        State = State.error,
                    });

            if (consultoringRoom.Name != data.Name)
                if( await _consultingRoomRepository.GetConsultoringRoomByName(data.Name) != null)
                    throw new ExceptionHandler(HttpStatusCode.BadRequest,
                        new Error
                        {
                            Message = "The Consulting room al ready exist",
                            Title = "Error",
                            State = State.error,
                        });

            

            consultoringRoom.Name = data.Name ?? consultoringRoom.Name;
            consultoringRoom.IsAvailable = data.IsAvailable;

            return await _consultingRoomRepository.UpdateConsultoringRoom(consultoringRoom);
        }
    }
}
