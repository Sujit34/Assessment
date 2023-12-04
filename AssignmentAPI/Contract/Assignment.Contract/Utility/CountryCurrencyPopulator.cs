using Assignment.Contract.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment.Contract.Utility
{
    public class CountryCurrencyPopulator
    {
        class RootObject
        {
            public List<CountryCurrency> CountryCurrencies { get; set; }
        }
        public static async Task<Dictionary<string,string>> PopulateCountryCurrencyFromJSONFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\CountryCurrency.json");
            string json = await System.IO.File.ReadAllTextAsync(path);
            RootObject data = JsonSerializer.Deserialize<RootObject>(json);

            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (var cc in data.CountryCurrencies)
            {
                dictionary.Add(cc.CurrencyCode, cc.CountryCode);
            }
            return dictionary;
        }
    }
}
