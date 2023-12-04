using Assignment.Contract.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment.Contract.Utility
{
    public class CountryFlatRatePopulator
    {
        class RootObject
        {
            public List<CountryFlatRate> CountryFlatRates { get; set; }
        }
        public static async Task<Dictionary<string, double>> PopulateCountryFlatRateFromJSONFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\CountryFlatRate.json");
            string json = await System.IO.File.ReadAllTextAsync(path);
            RootObject data = JsonSerializer.Deserialize<RootObject>(json);

            Dictionary<string, double> dictionary = new Dictionary<string, double>();
            foreach (var cc in data.CountryFlatRates)
            {
                dictionary.Add(cc.CurrencyCode, cc.FlateRate);
            }
            return dictionary;
        }
    }
}
