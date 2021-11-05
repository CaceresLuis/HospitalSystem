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

namespace Core.Services.Quotes.Read
{
    public class ReadQuoteByDoctorHandler : IRequestHandler<ReadQuoteByDoctorQuery, QuoteDto>
    {
        private readonly IMapper _mapper;
        private readonly IQuoteRepository _quoteRepository;

        public ReadQuoteByDoctorHandler(IMapper mapper, IQuoteRepository quoteRepository)
        {
            _mapper = mapper;
            _quoteRepository = quoteRepository;
        }

        public async Task<QuoteDto> Handle(ReadQuoteByDoctorQuery request, CancellationToken cancellationToken)
        {
            Quote quote = await _quoteRepository.GetQuoteByDoctor(request.DoctorId, request.Date);
            if(quote.QuoteTotal >= 40)
                throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });

            if(request.Hour == quote.Hour)
                if(quote.Quotehour > 5)
                    throw new ExceptionHandler(HttpStatusCode.BadRequest,
                   new Error
                   {
                       Message = "Something has gone wrong",
                       Title = "Error",
                       State = State.error,
                   });

            return _mapper.Map<QuoteDto>(quote);
        }
    }
}
