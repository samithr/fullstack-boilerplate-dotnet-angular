using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService){
            this.transactionService = transactionService;
        }

        [HttpGet]
        public async Task<List<TransactionModel>> Get()
        {
            var response = await transactionService.AllTransactions();
            if(response != null){
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost]
        public async Task<TransactionModel> Post([FromBody]TransactionModel transactionModel)
        {
            var response = await transactionService.CreteTransaction(transactionModel);
             if(response != null){
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
