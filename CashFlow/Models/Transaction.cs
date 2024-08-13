using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlow.Models
{
    [Table("TRANSACTION_T")]
    public class Transaction
    {
        public int ID { get; set; } = 0;

        [Required]
        [StringLength(100)]
        public string? Description { get; set; } = string.Empty;

        [Required]
        [Range(0, 10, ErrorMessage = "You must enter a number greater than 0.")]
        public decimal? Amount { get; set; } = 0M;

        [Required]
        public TransactionType? Type { get; set; } = null;
    }

    public enum TransactionType { Expense, Income };
}
