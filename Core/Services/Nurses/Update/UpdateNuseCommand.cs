using MediatR;
using Core.Dtos;

namespace Core.Services.Nurses.Update
{
    public class UpdateNuseCommand : IRequest<bool>
    {
        public NurseDto NurseDto{ get; set; }
    }
}
