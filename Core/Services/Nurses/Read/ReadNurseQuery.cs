using System;
using MediatR;
using Core.Dtos;

namespace Core.Services.Nurses.Read
{
    public class ReadNurseQuery : IRequest<NurseDto>
    {
        public Guid Id { get; set; }
    }
}
