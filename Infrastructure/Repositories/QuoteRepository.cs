using System;
using Infrastructure.Data;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly DataContext _dataContext;

        public QuoteRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Quote> GetQuote(Guid id)
        {
            return await _dataContext.Quotes.FindAsync(id);
        }

        public async Task<List<Quote>> GetQuotes()
        {
            return await _dataContext.Quotes.ToListAsync();
        }

        public async Task<bool> AddQuote(Quote quote)
        {
            _dataContext.Quotes.Add(quote);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateQuote(Quote quote)
        {
            _dataContext.Quotes.Update(quote);
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteQuote(Quote quote)
        {
            _dataContext.Quotes.Remove(quote);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
