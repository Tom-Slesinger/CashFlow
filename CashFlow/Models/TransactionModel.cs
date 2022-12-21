using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CashFlow.Models
{
    public class TransactionModel
    {
        public string PageTitle = string.Empty;
        public List<Transaction> Transactions = new List<Transaction>();
    }
}
