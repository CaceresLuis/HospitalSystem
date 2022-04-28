using MediatR;
using Core.Dtos;

namespace Core.Services.Nurses.Create
{
    public class CreateNurseCommand : IRequest<bool>
    {
        public NurseDto NurseDto { get; set; }
    }
}
