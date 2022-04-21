using MediatR;
using Core.Dtos;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Infrastructure.Data.Entities;

namespace Core.Services.Quotes.List
{
    public class ListQuoteHandler : IRequestHandler<ListQuoteQuery, List<QuoteDto>>
    {
        private readonly IMapper _mapper;
        private readonly IQuoteRepository _quoteRepository;

        public ListQuoteHandler(IMapper mapper, IQuoteRepository quoteRepository)
        {
            _mapper = mapper;
            _quoteRepository = quoteRepository;
        }

        public async Task<List<QuoteDto>> Handle(ListQuoteQuery request, CancellationToken cancellationToken)
        {
            List<Quote> quotes = await _quoteRepository.GetQuotes();
            //foreach (var item in quotes)
            //{
            //    if (item.Reservation.QuoteByhour >= 5 || item.Reservation.QuoteTotal >= 40)
            //        quotes.Remove(item);
            //}

            List<QuoteDto> dtos = _mapper.Map<List<QuoteDto>>(quotes);

            return dtos;
        }
    }
}
