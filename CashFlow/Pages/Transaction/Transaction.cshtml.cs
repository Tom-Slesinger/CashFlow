using CashFlow.Models;
using Microsoft.AspNetCore.Mvc;
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
            var transactions = _context.Transactions.ToList();
        }
    }
}
