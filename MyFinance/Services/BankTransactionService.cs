using System;
using MyFinance.Models;
using MyFinance.Extensions;

namespace MyFinance.Services;

public class BankTransactions
{
    private const string requestUrl = $"https://s3.ap-southeast-2.amazonaws.com/myprosperity.com.au/Test/Transactions.json";

    public static async Task<IEnumerable<BankTransaction>> Get()
    {
        return await requestUrl.Fetch<IEnumerable<BankTransaction>>() ?? Enumerable.Empty<BankTransaction>();
    }
    public static IEnumerable<BankAccountSummary> Summarize(DateTime start, DateTime end, IEnumerable<BankTransaction> transactions)
    {
        return from tr in transactions
               where IsBetween(tr, start, end)
               group tr by tr.AccountId into g
               select new BankAccountSummary
               {
                   AccountId = g.Key,
                   AccountName = g.FirstOrDefault().AccountName ?? "Account Name Not Found",
                   TotalTransactions = (g as IEnumerable<BankTransaction>).Aggregate(
                       0,
                       (total, i) => total + i.Amount,
                         (Func<decimal, decimal>)(netTotal => netTotal)
                       )

               };
    }

    private static bool IsBetween(BankTransaction tr, DateTime from, DateTime to)
    {
        return tr.TransactionDate.Date >= from.Date && tr.TransactionDate.Date <= to.Date;
    }
}

