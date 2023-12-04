using Assignment.Contract.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment.Contract.Utility
{
    public class PartnerRatePopulator
    {
        class RootObject
        {
            public List<PartnerRate> PartnerRates { get; set; }
        }
        public static async Task<List<PartnerRate>> PopulatePartnerRateFromJSONFile()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\PartnerRate.json");
            string json =  await System.IO.File.ReadAllTextAsync(path);            
            RootObject data = JsonSerializer.Deserialize<RootObject>(json);           
            return data.PartnerRates;
        }
    }
}
