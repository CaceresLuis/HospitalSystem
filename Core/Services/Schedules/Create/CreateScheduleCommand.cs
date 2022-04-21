using MediatR;
using Core.Dtos;

namespace Core.Services.Schedules.Create
{
    public class CreateScheduleCommand : IRequest<bool>
    {
        public CreateScheduleDto ScheduleDto { get; set; }
    }
}
