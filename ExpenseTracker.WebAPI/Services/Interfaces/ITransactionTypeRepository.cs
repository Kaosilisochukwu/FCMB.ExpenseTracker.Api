using ExpenseTracker.WebAPI.DTOs;
using ExpenseTracker.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Services.Interfaces
{
    public interface ITransactionTypeRepository
    {
        public Task<int> AddTransationMethod(TransactionTypeToAddDTO transactionMenthod);
        public Task<int> EditTransactionMethod(TransactionType transactionMethod);
        public Task<IEnumerable<TransactionType>> GetAllTransactions();
        public Task<TransactionType> GetTransactionMethodById(int id);
        public Task<int> DeleteTransactionMethod(TransactionType transactionMethod);
    }
}
