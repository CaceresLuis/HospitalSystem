using Core.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Core.Services.Schedules.List
{
    public class ListSchedulesQuery : IRequest<List<ScheduleDto>>
    {
    }
}
