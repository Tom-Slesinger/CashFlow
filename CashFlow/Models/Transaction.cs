using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlow.Models
{
    [Table("TRANSACTION_T")]
    public class Transaction
    {
        public int ID { get; set; } = 0;
        public string? Description { get; set; } = string.Empty;
        public decimal? Amount { get; set; } = 0;
        public string? Type { get; set; } = string.Empty;
    }
}
