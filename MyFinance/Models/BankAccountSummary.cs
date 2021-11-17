namespace MyFinance.Models
{
    public struct BankAccountSummary
    {
        public int AccountId { get; init; }
        public string AccountName { get; init; } 
        public decimal TotalTransactions { get; init; }
    }
}

