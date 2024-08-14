using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Models
{
    public class TransactionModel : PageModel
    {
        public string PageTitle = string.Empty;
        public List<Transaction> Transactions = [];
    }
}
