﻿namespace MyFinance.Models
{
    public record struct BankAccount
    {
        public int AccountId { get; init; }
        public string AccountName { get; init; }
        public decimal Balance { get; init; }
    }
}


 