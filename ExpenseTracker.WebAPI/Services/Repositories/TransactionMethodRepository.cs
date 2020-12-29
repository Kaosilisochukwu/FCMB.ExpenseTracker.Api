using AutoMapper;
using ExpenseTracker.WebAPI.Data;
using ExpenseTracker.WebAPI.DTOs;
using ExpenseTracker.WebAPI.Models;
using ExpenseTracker.WebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Services.Repositories
{
    public class TransactionMethodRepository : ITransactionMethodRepository
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public TransactionMethodRepository(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<int> AddTransationMethod(TransactionMethod transactionMethod)
        {
            await _context.TransactionMethods.AddAsync(transactionMethod);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult;
        }

        public async Task<int> DeleteTransactionMethod(TransactionMethod transactionMethod)
        {
            _context.TransactionMethods.Remove(transactionMethod);
            var updateResult = await _context.SaveChangesAsync();
            return updateResult;
        }

        public async Task<int> EditTransactionMethod(TransactionMethod transactionMethod)
        {
            _context.TransactionMethods.Update(transactionMethod);
            var updateResult = await _context.SaveChangesAsync();
            return updateResult;
        }

        public async Task<IEnumerable<TransactionMethod>> GetAllTransactionMethods()
        {
            return await _context.TransactionMethods.ToListAsync();
        }

        public async Task<TransactionMethod> GetTransactionMethodById(int id)
        {
            return await _context.TransactionMethods.FirstOrDefaultAsync(transactionMethod => transactionMethod.Id == id);
        }

        public async Task<TransactionMethod> GetTransactionMethodByTitle(string title)
        {
            return await _context.TransactionMethods.FirstOrDefaultAsync(transactionMethod => transactionMethod.Title.ToLower().Contains(title.ToLower()));
        }
    }
}
