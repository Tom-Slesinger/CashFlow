using CashFlow.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Pages
{
    public class TransactionModel : PageModel
    {
        private readonly ILogger<TransactionModel> _logger;
        private readonly CashFlowContext _context;

        public TransactionModel(ILogger<TransactionModel> logger, CashFlowContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Models.Transaction transactionNew = new();
            transactionNew.Amount = 99;
            transactionNew.Description = "test from ASP NET";
            transactionNew.Type = "Expense";

            _context.Transactions.Add(transactionNew);
            _context.SaveChanges();
        }
    }
}
