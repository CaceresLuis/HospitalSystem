using System;
using MediatR;

namespace Core.Services.Nurses.Delete
{
    public class DeleteNurseCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
