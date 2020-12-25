using ExpenseTracker.WebAPI.DTOs;
using ExpenseTracker.WebAPI.Models;
using ExpenseTracker.WebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Services.Repositories
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        public Task<int> AddTransationMethod(TransactionTypeToAddDTO transactionMenthod)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteTransactionMethod(TransactionType transactionMethod)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditTransactionMethod(TransactionType transactionMethod)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionType>> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<TransactionType> GetTransactionMethodById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
