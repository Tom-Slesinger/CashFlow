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

        public IActionResult Create()
        {
            return PartialView("_TransactionCreate");
        }

        public List<Transaction> GetTransactions()
        {
            var transactions = _context.Transactions.ToList();

            return transactions != null ? transactions : new List<Transaction>();
        }
    }
}
