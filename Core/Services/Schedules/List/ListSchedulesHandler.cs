using MediatR;
using Core.Dtos;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Infrastructure.Data.Entities;

namespace Core.Services.Schedules.List
{
    public class ListSchedulesHandler : IRequestHandler<ListSchedulesQuery, List<ScheduleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IScheduleRepository _scheduleRepository;

        public ListSchedulesHandler(IMapper mapper, IScheduleRepository scheduleRepository)
        {
            _mapper = mapper;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<ScheduleDto>> Handle(ListSchedulesQuery request, CancellationToken cancellationToken)
        {
            List<Schedule> schedules = await _scheduleRepository.GetSchedules();

            return _mapper.Map<List<ScheduleDto>>(schedules);
        }
    }
}
