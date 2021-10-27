using MediatR;
using Core.Enums;
using System.Net;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Nurses.Delete
{
    public class DeleteNurseHandler : IRequestHandler<DeleteNurseCommand, bool>
    {
        private readonly INurseRepository _nurseRepository;

        public DeleteNurseHandler(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        public async Task<bool> Handle(DeleteNurseCommand request, CancellationToken cancellationToken)
        {
            Nurse nurse = await _nurseRepository.GetNurse(request.Id) ??
                throw new ExceptionHandler(HttpStatusCode.NotFound,
                    new Error
                    {
                        Message = "The nurse does not exist",
                        Title = "Error",
                        State = State.error,
                    });

            return await _nurseRepository.DeleteNurse(nurse);
        }
    }
}
