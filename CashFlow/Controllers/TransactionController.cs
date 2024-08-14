using CashFlow.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

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
        public IActionResult SaveTransaction([FromBody] Transaction transactionToSave)
        {
            if (transactionToSave.Amount == null)
            {
                return BadRequest("Amount is a required field.");
            }

            if (transactionToSave.Description == null)
            {
                return BadRequest("Descrption is a required field.");
            }

            if (transactionToSave.ID == 0)
            {
                _context.Transactions.Add(transactionToSave);
            }
            else
            {
                Transaction? existingTransaction = _context.Transactions.FirstOrDefault(x => x.ID == transactionToSave.ID);
                if (existingTransaction == null)
                {
                    return BadRequest("Cannot find Transaction with that ID in the Database. Please contact your System Administrator.");
                }

                existingTransaction.Amount = transactionToSave.Amount;
                existingTransaction.Description = transactionToSave.Description;
                existingTransaction.TransactionType = transactionToSave.TransactionType;
            }
            _context.SaveChanges();
            return Ok();
        }
        public class DeleteTransactionModel
        {
            public int? ID { get; set; }
        }
        [HttpPost]
        [Route("Transaction/DeleteTransaction")]
        public IActionResult DeleteTransaction([FromBody] DeleteTransactionModel? obj)
        {
            if (obj == null || obj.ID == null || obj.ID == 0)
            {
                return BadRequest("ID Cannot be Null or 0.");
            }
            Transaction? transactionToDelete = _context.Transactions.FirstOrDefault(x => x.ID == obj.ID);
            if (transactionToDelete == null)
            {
                return BadRequest("Could not find a record to Delete.");
            }

            _context.Remove(transactionToDelete);
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
