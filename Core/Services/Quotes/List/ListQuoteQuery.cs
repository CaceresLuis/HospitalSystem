using MediatR;
using Core.Dtos;
using System.Collections.Generic;

namespace Core.Services.Quotes.List
{
    public class ListQuoteQuery : IRequest<List<QuoteDto>>
    {
    }
}
