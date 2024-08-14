using CashFlow.Models;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Controllers
{
    public class TransactionController : Controller
    {
        private readonly CashFlowContext _context;
        public TransactionController(CashFlowContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var transactions = GetTransactions();
            var model = new TransactionModel
            {
                PageTitle = "Transactions Overview",
                Transactions = transactions
            };

            return View(model);
        }

        [HttpPost]
        [Route("Transaction/SaveTransaction")]
        public IActionResult SaveTransaction([FromBody] Transaction transaction)
        {
            if (transaction.Amount == null)
            {
                return BadRequest("Amount is a required field.");
            }

            if (transaction.Description == null)
            {
                return BadRequest("Descrption is a required field.");
            }

            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            return Ok();
        }

        public List<Transaction> GetTransactions()
        {
            var transactions = _context.Transactions.ToList();

            return transactions != null ? transactions : new List<Transaction>();
        }
    }
}
