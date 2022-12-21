using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Models
{
    public class TransactionModel : PageModel
    {
        List<Transaction> Transactions = new List<Transaction>();
    }
}
