using Bogus;
using Bogus.DataSets;
using Bogus.Extensions;
using System;
using System.Collections.Generic;
using MyGameCity.DataModel;
using System.Xml;
using MyGameCity.Controllers;

namespace MyGameCity.Services
{
    public class FakeDatabaseService
    {
        public static List<Games> ModelDatabase;
        public static void CreateDatabase()
        {
            if(ModelDatabase!=null)
                ModelDatabase.Clear();
            Randomizer.Seed = new Random(7539743);

            var Categories = new[] { "Action", "Adventure", "RPG", "Casual", "Competetive" };

            var publisherFaker = new Faker<Publisher>()
                .RuleFor(x => x.Title, f => f.Company.CompanyName())
                .RuleFor(x => x.Description, f => f.Company.Bs())
                .RuleFor(x => x.CountryOfOrigin, f => f.Address.Country());

            var developerFaker = new Faker<Developer>()
                .RuleFor(x => x.Title, f => f.Company.CompanyName())
                .RuleFor(x => x.Description, f => f.Company.Bs())
                .RuleFor(x => x.CountryOfOrigin, f => f.Address.Country());

            var reviewFaker = new Faker<Review>()
                .RuleFor(x => x.Stars, f => f.Random.Number(0, 5))
                .RuleFor(x => x.Description, f => f.Random.Word())
                .RuleFor(x => x.Title, f => f.Random.Word());

            var gamesFaker = new Faker<Games>()
                .RuleFor(x => x.Title, f => f.Commerce.ProductName())
                .RuleFor(x => x.Ammount, f => f.Random.Number())
                .RuleFor(x => x.Category, f => f.PickRandom(Categories))
                .RuleFor(x => x.Ammount, f => f.Random.Number(0, 500))
                //.RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Price, f => f.Random.Number(5, 100))
                .RuleFor(x => x.Publisher, f => publisherFaker.Generate())
                .RuleFor(x => x.Developer, f => developerFaker.Generate())
                .RuleFor(x => x.Review, f => reviewFaker.Generate())
                .RuleFor(x => x.Id, f => Guid.NewGuid());
            ModelDatabase = gamesFaker.Generate(5);
            publisherFaker.RuleFor(x => x.ListOfGames, f => f.PickRandomParam(ModelDatabase));
            developerFaker.RuleFor(x => x.ListOfGames, f => f.PickRandomParam(ModelDatabase));
            FakeDatabaseService.ModelDatabase.ForEach(Console.WriteLine);
        }
        
    }
}
