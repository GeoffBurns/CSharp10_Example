namespace MyFinance.Models;

public record struct BankAccountSummary
{
    public int AccountId { get; init; }
    public string AccountName { get; init; } 
    public decimal TotalTransactions { get; init; }
}


