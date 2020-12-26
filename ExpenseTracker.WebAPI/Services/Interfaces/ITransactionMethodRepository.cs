using ExpenseTracker.WebAPI.DTOs;
using ExpenseTracker.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Services.Interfaces
{
    public interface ITransactionMethodRepository
    {
        public Task<int> AddTransationMethod(TransactionMethod transactionMenthod);
        public Task<int> EditTransactionMethod(TransactionMethod transactionMethod);
        public Task<IEnumerable<TransactionMethod>> GetAllTransactionMethods();
        public Task<TransactionMethod> GetTransactionMethodById(int id);
        public Task<TransactionMethod> GetTransactionMethodByTitle(string title);
        public Task<int> DeleteTransactionMethod(TransactionMethod transactionMethod);
    }
}
