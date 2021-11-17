using System.Linq;
using System.Threading.Tasks;
using MyFinance.Extensions;
using MyFinance.Models;

namespace MyFinance.Services
{
    public class CurrencyConversion
    {
        private const string key = "f38cbf473cc5160070071d676cdcaed4";
         
        public static async Task<double?> GetRate(string source)
        {
            string requestUri = $"http://api.currencylayer.com/live?access_key={key}&currencies=AUD,{source},&format=1";
      
            var response = await requestUri.Fetch<ConversionRateResponse>();
            if (!response.Success) return null;

            var usdToSource = response.Quotes.FirstOrDefault(kv => kv.Key != "USDAUD");
            var usdToAud = response.Quotes.FirstOrDefault(kv => kv.Key == "USDAUD");

            if (usdToSource.Key == null && usdToAud.Key == null) return null;

            return usdToAud.Value / usdToSource.Value;
        }

        /* 
         * Functionality not available at free tier
         * 
        public static async Task<double?> GetRate2(string source)
        {
            string requestUri2 = $"http://api.currencylayer.com/live?access_key={key}&currencies=AUD&source={source}&format=1";
            string requestUri3 = $"http://api.currencylayer.com/convert?access_key={key}&from={source}&to=AUD&amount=1";
       
            var response = await requestUri2.Fetch<ConversionRateResponse>();
            if (!response.Success) return null;

            var conversionFactor = response.Quotes.FirstOrDefault(kv => kv.Key != "AUDAUD");


            return conversionFactor.Value;
        }
        */

    }
}

