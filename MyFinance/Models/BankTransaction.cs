using System;

namespace MyFinance.Models
{
    public struct BankTransaction
    {
        public int TransactionId { get; init; }
        public DateTime TransactionDate { get; init; }
        public int AccountId { get; init; }
        public string AccountName { get; init; }
        public decimal Amount { get; init; }
        public string Description { get; init; }
    }
}


