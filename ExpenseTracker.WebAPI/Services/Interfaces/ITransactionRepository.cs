using ExpenseTracker.WebAPI.DTOs;
using ExpenseTracker.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Services
{
    public interface ITransactionRepository
    {
        public Task<int> AddTransaction(Transaction transaction);
        public Task<int> EditTransaction(Transaction transaction);
        public Task<Transaction> GetTransactionById(int transactionId, string userId);
        public Task<IEnumerable<Transaction>> GetAllTransactions(string userId);
        public Task<IEnumerable<Transaction>> FilterTransactionsByTransactionsMethod(int transactionMethodId, string userId);
        public Task<IEnumerable<Transaction>> FilterTransactionsByTitle(string title, string userId);
        public Task<IEnumerable<Transaction>> FilterTransactionsByTransactionsByDate(DateTime date, string userId);
        public Task<IEnumerable<Transaction>> FilterTransactionsByDateRange(DateTime startDate, DateTime endDate, string userId);
    }
}
