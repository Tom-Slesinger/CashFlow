using CashFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Pages
{
    public class TransactionModel : PageModel
    {
        private readonly ILogger<TransactionModel> _logger;

        public TransactionModel(ILogger<TransactionModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Initialize();
        }

        public static void Initialize(CashFlowContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
