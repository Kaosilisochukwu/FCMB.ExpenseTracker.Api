using AutoMapper;
using ExpenseTracker.WebAPI.Data;
using ExpenseTracker.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Services.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TransactionRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddTransaction(Transaction transaction)
        {
            await _context.AddAsync(transaction);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> EditTransaction(Transaction transaction)
        {
            _context.Update(transaction);
            return await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Transaction>> FilterTransactionsByDateRange(DateTime startDate, DateTime endDate, string userId)
        {

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transaction>> FilterTransactionsByTitle(string title, string userId)
        {
            return await _context.Transactions.Where(transaction => transaction.Title == title && transaction.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> FilterTransactionsByTransactionsByDate(DateTime date, string userId)
        {
            return await _context.Transactions.Where(transaction => transaction.TransactionDate == date && transaction.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> FilterTransactionsByTransactionsMethod(int transactionMethodId, string userId)
        {
            return await _context.Transactions.Where(transaction => transaction.TransactionMethodId == transactionMethodId && transaction.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactions(string userId)
        {
            return await _context.Transactions.Where(transaction => transaction.UserId == userId).ToListAsync();
        }

        public async Task<Transaction> GetTransactionById(int transactionId, string userId)
        {
            return await _context.Transactions.FirstOrDefaultAsync(transaction => transaction.Id == transactionId && transaction.UserId == userId);
        }
    }
}
