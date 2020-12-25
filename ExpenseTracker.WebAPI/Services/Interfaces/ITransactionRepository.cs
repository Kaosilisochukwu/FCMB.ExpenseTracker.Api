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
        public Task<int> AddTransaction(TransactionToAddDTO transaction);
        public Task<int> EditTransaction(Transaction transaction);
        public Task<Transaction> GetTransactionById(int transactionId);
        public Task<IEnumerable<Transaction>> GetAllTransactions();
        public Task<IEnumerable<Transaction>> FilterTransactionsByName(string transactionName);
        public Task<IEnumerable<Transaction>> FilterTransactionsByTransactionsType(int transactionTypeId);
        public Task<IEnumerable<Transaction>> FilterTransactionsByTransactionsMethod(int transactionMethodId);
        public Task<IEnumerable<Transaction>> FilterTransactionsByTransactionsByDate(string date);
        public Task<IEnumerable<Transaction>> FilterTransactionsByDateRange(string startDate, string endDate);
    }
}
