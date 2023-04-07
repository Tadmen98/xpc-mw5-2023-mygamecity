using Bogus.DataSets;
using System.Diagnostics.Metrics;

namespace MyGameCity.DataModel
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CountryOforigin { get; set; }
        public string ListOfCommodities { get; set; }
    }
}
