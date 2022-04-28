using MediatR;
using Core.Dtos;
using System.Net;
using Core.Enums;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Nurses.Update
{
    public class UpdateNuseHandler : IRequestHandler<UpdateNuseCommand, bool>
    {
        private readonly INurseRepository _nurseRepository;

        public UpdateNuseHandler(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        public async Task<bool> Handle(UpdateNuseCommand request, CancellationToken cancellationToken)
        {
            NurseDto data = request.NurseDto;
            Nurse nurse = await _nurseRepository.GetNurse(data.Id) ??
                throw new ExceptionHandler(HttpStatusCode.NotFound,
                    new Error
                    {
                        Message = "The nurse does not exist",
                        Title = "Error",
                        State = State.error,
                    });

            nurse.FullName = data.FullName ?? nurse.FullName;
            nurse.Adresss = data.Adresss ?? nurse.Adresss;
            nurse.Document = data.Document ?? nurse.Document;
            nurse.Phone = data.Phone ?? nurse.Phone;

            return await _nurseRepository.UpdateNurse(nurse);
        }
    }
}
