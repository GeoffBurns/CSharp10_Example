using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Services;

namespace MyFinance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountSummaryController : ControllerBase
    {
        [HttpGet(Name = "BankAccountSummary")]
        public async Task<IActionResult> GetAsync(DateTime from, DateTime to)
        {
            return from <= to
                ? new JsonResult(
                        BankTransactions.Summarize(
                        from,
                        to,
                        await BankTransactions.Get()))
                : BadRequest("The end date is before the start");
        }
    }

}