using Bogus;
using Bogus.DataSets;
using Bogus.Extensions;
using System;
using System.Collections.Generic;
using MyGameCity.DataModel;

namespace MyGameCity.Services
{
    public class FakeDatabaseService
    {
        Faker ModelDatabase;
        public void CreateDatabase()
        {
            Randomizer.Seed = new Random(7539743);
            var manufacturerFaker = new Faker<Manufacturer>()
            .StrictMode(true)
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .RuleFor(x => x.Description, f => f.Company.Bs())
            .RuleFor(x => x.CountryOforigin, f => f.Company.Locale)
            .RuleFor(x => x.ListOfCommodities, f => f.Commerce.Product());
        }
    }
}
