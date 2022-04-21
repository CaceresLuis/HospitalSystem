using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Schedules.Create
{
    public class CreateScheduleHandler : IRequestHandler<CreateScheduleCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IScheduleRepository _scheduleRepository;

        public CreateScheduleHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<bool> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            Schedule schedule = _mapper.Map<Schedule>(request.ScheduleDto);

            return await _scheduleRepository.AddSchedule(schedule);
        }
    }
}
