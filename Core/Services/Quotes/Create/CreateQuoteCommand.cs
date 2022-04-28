using MediatR;
using Core.Dtos;

namespace Core.Services.Quotes.Create
{
    public class CreateQuoteCommand : IRequest<bool>
    {
        public CreateQuoteDto CreateQuoteDto { get; set; }
    }
}
