using MediatR;
using Core.Dtos;

namespace Core.Services.MedicalHitories.Create
{
    public class CreateMedicalHistoryCommand : IRequest<bool>
    {
        public MedicalHistoryDto MedicalHistoryDto { get; set; }
    }
}
