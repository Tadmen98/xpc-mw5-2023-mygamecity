using Bogus.DataSets;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace MyGameCity.DataModel
{
    public class Manufacturer
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string?  CountryOforigin { get; set; }
        public List<string> ListOfCommodities { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
