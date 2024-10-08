﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CashFlow.Models
{
    [Table("TRANSACTION_T")]
    public class Transaction
    {
        public int ID { get; set; } = 0;
        public string? Description { get; set; } = string.Empty;
        public decimal? Amount { get; set; } = 0M;
        public TransactionTypes? TransactionType { get; set; } = null;
    }
    public enum TransactionTypes 
    {
        Expense = 0,
        Income = 1 }
    ;
}
