using Assignment.Contract.BusinessContract.MoneyTransfer;
using Assignment.Contract.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace Assignment.Api.Controllers.MoneyTransfer
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyTransferController : ControllerBase
    {
        private readonly IExchangeRateHandler _exchangeRateHandler;
        public MoneyTransferController(IExchangeRateHandler exchangeRateHandler)
        {
            _exchangeRateHandler = exchangeRateHandler;
        }

        
        [HttpGet("exchange-rates")]
        public async Task<IActionResult> GetExchangeRate(string country)
        {
            if (string.IsNullOrWhiteSpace(country) || country.Length != Common.CountryCodeLength ||
                !country.All(char.IsLetter))
            {
                return BadRequest("Invalid country code. Please provide a valid " + Common.CountryCodeLength + "-letter country code.");
            }

            var partnerRates = await _exchangeRateHandler.GetExchangeRate(country);

            return partnerRates != null ? Ok(partnerRates) : (IActionResult)NotFound("Exchange rates not found for the specified country.");
        }
    }
}
