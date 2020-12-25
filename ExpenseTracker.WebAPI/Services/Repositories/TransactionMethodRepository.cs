using ExpenseTracker.WebAPI.DTOs;
using ExpenseTracker.WebAPI.Models;
using ExpenseTracker.WebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Services.Repositories
{
    public class TransactionMethodRepository : ITransactionMethodRepository
    {
        public Task<int> AddTransationMethod(TransactionMethodToAddDTO transactionMenthod)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteTransactionMethod(TransactionMethod transactionMethod)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditTransactionMethod(TransactionMethod transactionMethod)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionMethod>> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public Task<TransactionMethod> GetTransactionMethodById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
