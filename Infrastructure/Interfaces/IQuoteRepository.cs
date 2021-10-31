using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Infrastructure.Data.Entities;

namespace Infrastructure.Interfaces
{
    public interface IQuoteRepository
    {
        Task<bool> AddQuote(Quote quote);
        Task<bool> DeleteQuote(Quote quote);
        Task<Quote> GetQuote(Guid id);
        Task<List<Quote>> GetQuotes();
        Task<bool> UpdateQuote(Quote quote);
    }
}
