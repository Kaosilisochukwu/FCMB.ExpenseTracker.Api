using AutoMapper;
using ExpenseTracker.WebAPI.DTOs;
using ExpenseTracker.WebAPI.Models;
using ExpenseTracker.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class TransactionController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TransactionController(IMapper mapper, ITransactionRepository transactionRepo, IHttpContextAccessor httpContextAccessor)
        { 
            _mapper = mapper;
            _transactionRepo = transactionRepo;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("", Name = "addTransation")]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionToAddDTO transactionToAdd)
        {
            if (ModelState.IsValid)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var transaction = _mapper.Map<Transaction>(transactionToAdd);
                transaction.UserId = userId;
                var response = await _transactionRepo.AddTransaction(transaction);
                if(response > 0)
                {
                    return Created("addTransation", new ResponseModel(201, "Transaction successfully added", transaction));
                }
                return BadRequest(new ResponseModel(400, "Transaction not added", transaction));
            }

            var errors = ModelState.Values.Select(model => model.Errors).ToList();
            return BadRequest(new ResponseModel(400, "There are some validation Errors", errors));
        }
        [HttpPatch]
        public async Task<IActionResult> EditTransaction([FromBody] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if(transaction.UserId == userId)
                {
                    var editResult = await _transactionRepo.EditTransaction(transaction);
                    if(editResult > 0)
                    {
                        return Ok(new ResponseModel(200, "Transaction successfully updated", transaction));
                    }
                    return BadRequest(new ResponseModel(400, "Transaction not updated", transaction));
                }
                return Unauthorized(new ResponseModel(401, "You are not allowed to edit this Transaction details", transaction));
            }
            var errors = ModelState.Values.Select(model => model.Errors).ToList();
            return BadRequest(new ResponseModel(400, "There are some validation Errors", errors));
        }

        [HttpGet]
        [Route("search/{startDate:datetime}/{endDate:datetime}")]
        public async Task<IActionResult> FilterTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            if (ModelState.IsValid)
            {
                var baseStartDate = DateTime.Parse(startDate.ToShortDateString());
                var baseEndDate = DateTime.Parse(endDate.ToShortDateString());
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var transactions = await _transactionRepo.FilterTransactionsByDateRange(baseStartDate, baseEndDate, userId);
                return Ok(new ResponseModel(200, "Success", transactions));
            }
            var errors = ModelState.Values.Select(model => model.Errors).ToList();
            return BadRequest(new ResponseModel(400, "Query parameters are not valid", errors));
        }

        [HttpGet]
        [Route("search/{title}")]
        public async Task<IActionResult> FilterTransactionsByTitle(string title)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var transactions = await _transactionRepo.FilterTransactionsByTitle(title, userId);
            return Ok(new ResponseModel(200, "Success", transactions));
        }

        [HttpGet]
        [Route("search/{date:datetime}")]
        public async Task<IActionResult> FilterTransactionsByTransactionsByDate(DateTime date)
        {
            var SearchDate = DateTime.Parse(date.ToShortDateString());
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var transactions = await _transactionRepo.FilterTransactionsByTransactionsByDate(SearchDate, userId);
            return Ok(new ResponseModel(200, "Success", transactions));
        }

        [HttpGet]
        [Route("search/{transactionMethodId:int}")]
        public async Task<IActionResult> FilterTransactionsByTransactionsMethod(int transactionMethodId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var transactions = await _transactionRepo.FilterTransactionsByTransactionsMethod(transactionMethodId, userId);
            return Ok(new ResponseModel(200, "Success", transactions));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var transactions = await _transactionRepo.GetAllTransactions(userId);
            return Ok(new ResponseModel(200, "Success", transactions));
        }
        [HttpGet]
        [Route("{transactionId:int}")]
        public async Task<IActionResult> GetTransactionById(int transactionId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var transaction = await _transactionRepo.GetTransactionById(transactionId, userId); 
            return Ok(new ResponseModel(200, "Success", transaction));
        }
    }
}
