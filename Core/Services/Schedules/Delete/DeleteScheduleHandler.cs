using MediatR;
using System.Net;
using Core.Enums;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Schedules.Delete
{
    public class DeleteScheduleHandler : IRequestHandler<DeleteScheduleCommand, bool>
    {
        private readonly IScheduleRepository _scheduleRepository;

        public DeleteScheduleHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<bool> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            Schedule schedule = await _scheduleRepository.GetSchedule(request.Id) ??
                 throw new ExceptionHandler(HttpStatusCode.NotFound,
                     new Error
                     {
                         Message = "The nurse does not exist",
                         Title = "Error",
                         State = State.error,
                     });

            return await _scheduleRepository.DeleteSchedule(schedule);
        }
    }
}
