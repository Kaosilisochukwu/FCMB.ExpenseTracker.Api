using AutoMapper;
using ExpenseTracker.WebAPI.DTOs;
using ExpenseTracker.WebAPI.Models;
using ExpenseTracker.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    public class TransactionMethodController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITransactionMethodRepository _transactionRepo;

        public TransactionMethodController(IMapper mapper, IHttpContextAccessor httpContextAccessor, ITransactionMethodRepository transactionRepo)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _transactionRepo = transactionRepo;
        }
        [HttpPost]
        [Route("", Name = "add")]
        public async Task<IActionResult> AddTransationMethod([FromBody] TransactionMethodToAddDTO model)
        {
            var transactionMethod = _mapper.Map<TransactionMethod>(model);
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            transactionMethod.AddedBy = userId;
            var response = await _transactionRepo.AddTransationMethod(transactionMethod);
            if (response > 0)
            {
                return Created("add", new ResponseModel(201, "Success", transactionMethod));
            }
            return BadRequest(new ResponseModel(400, "Failed", transactionMethod));
        }
         [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> DeleteTransactionMethod(int id)
        {
            var transactionMethod = await _transactionRepo.GetTransactionMethodById(id);
            if (transactionMethod == null)
            {
                return NotFound(new ResponseModel(404, "Transaction method does not exist", transactionMethod));
            }
            var deleteResult = await _transactionRepo.DeleteTransactionMethod(transactionMethod);
            if (deleteResult > 0)
            {
                return Ok(new ResponseModel(200, "Success", transactionMethod));
            }
            return BadRequest(new ResponseModel(400, "Failed", transactionMethod));
        }

        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> EditTransactionMethod([FromBody] TransactionMethodToUpdate model)
        {
            var transactionMethod = _mapper.Map<TransactionMethod>(model);
            var editResult = await _transactionRepo.EditTransactionMethod(transactionMethod);
            if (editResult > 0)
            {
                return Ok(new ResponseModel(200, "Success", transactionMethod));
            }
            return BadRequest(new ResponseModel(400, "Failed", transactionMethod));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionMethods()
        {
            var transactionMethods = await _transactionRepo.GetAllTransactionMethods();
            return Ok(new ResponseModel(200, "Success", transactionMethods));
        }

        [Route("search/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetTransactionMethodById(int id)
        {
            var transactionMethod = await _transactionRepo.GetTransactionMethodById(id);
            return Ok(new ResponseModel(200, "Success", transactionMethod));
        }
        [HttpGet]
        [Route("search/{title}")]
        public async Task<IActionResult> GetTransactionMethodByTitle(string title)
        {
            var transactionMethod = await _transactionRepo.GetTransactionMethodByTitle(title);
            return Ok(new ResponseModel(200, "Success", transactionMethod));
        }
    }
}
