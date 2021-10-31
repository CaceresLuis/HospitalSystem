using MediatR;
using Core.Dtos;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IQuoteRepository _quoteRepository;
        private readonly INurseRepository _nurseRepository;
        private readonly IDoctorRepository _doctorRepository;

        public CreateQuoteHandler(IMapper mapper, IQuoteRepository quoteRepository, INurseRepository nurseRepository, IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _quoteRepository = quoteRepository;
            _nurseRepository = nurseRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
        {
            QuoteDto data = request.QuoteDto;
            _ = await _nurseRepository.GetNurse(data.Nurse.Id) ??
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });

            _ = await _doctorRepository.GetDoctor(data.Doctor.Id) ??
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });

            Quote quote = _mapper.Map<Quote>(request.QuoteDto);
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
