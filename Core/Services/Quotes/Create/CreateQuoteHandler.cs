using MediatR;
using Core.Dtos;
using Core.Enums;
using System.Net;
using Core.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data.Entities;

namespace Core.Services.Quotes.Create
{
    public class CreateQuoteHandler : IRequestHandler<CreateQuoteCommand, bool>
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly INurseRepository _nurseRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;

        public CreateQuoteHandler(IQuoteRepository quoteRepository, INurseRepository nurseRepository, IDoctorRepository doctorRepository, IMedicalHistoryRepository medicalHistoryRepository)
        {
            _quoteRepository = quoteRepository;
            _nurseRepository = nurseRepository;
            _doctorRepository = doctorRepository;
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        public async Task<bool> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
        {
            CreateQuoteDto data = request.CreateQuoteDto;
            Nurse nurse = await _nurseRepository.GetNurse(data.NurseId) ??
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });

            _ = await _doctorRepository.GetDoctor(data.DoctorId) ??
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });

            MedicalHistory medicalHistory = await _medicalHistoryRepository.GetMedicalHistory(data.MedicalHistory) ??
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });
            Quote quoteBd = await _quoteRepository.GetQuoteByDoctor(data.DoctorId, data.DateTime);

            Quote quote = new()
            {
                Nurse = nurse,
                MedicalHistory = medicalHistory,
                Reservation = quoteBd.Reservation
            };

            
            return await _quoteRepository.AddQuote(quote) ? true
                :
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });
        }
    }
}
