using Assignment.Contract.BusinessContract.MoneyTransfer;
using Assignment.Contract.DataModels.MoneyTransfer;
using Assignment.Contract.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Business.MoneyTransfer
{
    public class ExchangeRateHandler : IExchangeRateHandler
    {

        public async Task<List<PartnerRateDto>> GetExchangeRate(string country)
        {
            var partnerRates = await PartnerRatePopulator.PopulatePartnerRateFromJSONFile();
            var countryCurrencies = await CountryCurrencyPopulator.PopulateCountryCurrencyFromJSONFile();
            var countryFlatRates = await CountryFlatRatePopulator.PopulateCountryFlatRateFromJSONFile();

            //filter rate based on county,
            //group by based on currency, payment metho, delivery method,
            //get the most recent rate
            var filteredRates = partnerRates
                .Where(rate => (countryCurrencies[rate.Currency.ToUpper()] ?? "") == country.ToUpper())
                .GroupBy(rate => new { rate.Currency, rate.PaymentMethod, rate.DeliveryMethod })
                .Select(group => group.OrderByDescending(rate => rate.AcquiredDate).First())
                .ToList();


            if (filteredRates.Any())
            {

                // fianl rate = partner rate + country-specific flat rate
                // and round to 2 decimal places
                var finalRates = filteredRates.Select(rate => new PartnerRateDto
                {
                    CurrencyCode = rate.Currency,
                    CountryCode = countryCurrencies[rate.Currency.ToUpper()] ?? "",
                    PangeaRate = Math.Round(rate.Rate + countryFlatRates[rate.Currency], 2),
                    PaymentMethod = rate.PaymentMethod,
                    DeliveryMethod = rate.DeliveryMethod
                });
                return finalRates.ToList();
            }

            return null;
        }
    }
}
