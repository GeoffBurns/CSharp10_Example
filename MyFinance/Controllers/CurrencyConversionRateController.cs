using MyFinance.Models;
using MyFinance.Extensions;
using Microsoft.AspNetCore.Mvc;
using MyFinance.Services;

namespace MyFinance.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyConversionRateController : ControllerBase
{ 
    [HttpGet(Name = "CurrencyConversionRate")]
    public async Task<IActionResult> GetAsync(string source)
    {
        var rate = await CurrencyConversion.GetRate(source); 
        return rate != null ? new JsonResult(rate) : BadRequest();
    } 
}
 