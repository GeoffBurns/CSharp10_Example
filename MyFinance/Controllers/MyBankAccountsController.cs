using Microsoft.AspNetCore.Mvc;
using MyFinance.Models;

namespace MyFinance.Controllers;

[ApiController]
[Route("[controller]")]
public class MyBankAccountsController : ControllerBase
{

    [HttpGet(Name = "MyBankAccounts")]
    public IEnumerable<BankAccount> Get()
    {
        var result = new[]
        {
               new BankAccount { AccountId = 1, AccountName = "Account 1", Balance = 100.00m },
               new BankAccount { AccountId = 2, AccountName = "Account 2", Balance = 200.00m },
           };
        return result;
    }
}

