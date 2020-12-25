using ExpenseTracker.WebAPI.DTOs;
using ExpenseTracker.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Services.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task<int> AddTransaction(TransactionToAddDTO transaction)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> FilterTransactionsByDateRange(string startDate, string endDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> FilterTransactionsByName(string transactionName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> FilterTransactionsByTransactionsByDate(string date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> FilterTransactionsByTransactionsMethod(int transactionMethodId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> FilterTransactionsByTransactionsType(int transactionTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetTransactionById(int transactionId)
        {
            throw new NotImplementedException();
        }
    }
}
