using MediatR;
using Core.Dtos;
using System;

namespace Core.Services.Schedules.Delete
{
    public class DeleteScheduleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
