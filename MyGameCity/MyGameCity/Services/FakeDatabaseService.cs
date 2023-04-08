using Bogus;
using Bogus.DataSets;
using Bogus.Extensions;
using System;
using System.Collections.Generic;
using MyGameCity.DataModel;
using System.Xml;
using MyGameCity.Controllers;

//Temporery Fake Database Solution

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
            //var Developers = new[] { "Coffee Stain Studio", "Square Enix", "RELOGIC", "343 studio", "Mojang"};
            //var publisherFaker = new Faker<Publisher>()
            //    .RuleFor(x => x.Title, f => f.Company.CompanyName())
            //    .RuleFor(x => x.Description, f => f.Company.Bs())
            //    .RuleFor(x => x.CountryOfOrigin, f => f.Address.Country());

            //var developerFaker = new Faker<Developer>()
            //    .RuleFor(x => x.Title, f => f.Company.CompanyName())
            //    .RuleFor(x => x.Description, f => f.Company.Bs())
            //    .RuleFor(x => x.CountryOfOrigin, f => f.Address.Country());

            //var reviewFaker = new Faker<Review>()
            //    .RuleFor(x => x.Stars, f => f.Random.Number(0, 5))
            //    .RuleFor(x => x.Description, f => f.Random.Word())
            //    .RuleFor(x => x.Title, f => f.Random.Word());

            var gamesFaker = new Faker<Games>()
                .RuleFor(x => x.Title, f => f.Commerce.ProductName())
                .RuleFor(x => x.Ammount, f => f.Random.Number())
                .RuleFor(x => x.Category, f => f.PickRandom(Categories))
                .RuleFor(x => x.Ammount, f => f.Random.Number(0, 500))
                //.RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Price, f => f.Random.Number(5, 100))
                .RuleFor(x => x.Publisher, f => PublisherService.CreatePublisher())
                .RuleFor(x => x.Developer, f => DeveloperService.CreateDeveloper())
                .RuleFor(x => x.Review, f => ReviewService.CreateReview())
                .RuleFor(x => x.Id, f => Guid.NewGuid());
            ModelDatabase = gamesFaker.Generate(5);
            ModelDatabase.ForEach(x =>x.Publisher.ListOfGames.Add(x.Title));
            ModelDatabase.ForEach(x => x.Developer.ListOfGames.Add(x.Title));
            PublisherService.PublisherGames();
            DeveloperService.DeveloperGames();
            ModelDatabase.ForEach(Console.WriteLine);
        }
        public static Games Get(Guid id) => ModelDatabase.FirstOrDefault(x => x.Id == id);
        public static void Add(Games game) => ModelDatabase.Add(game);
        public static void Delete(Guid id)
        {
            var game = Get(id);
            if (game == null)
                return;
            ModelDatabase.Remove(game);
        }
        public static void Update(Games game)
        {
            var index = ModelDatabase.FindIndex(x=>x.Id == game.Id);
            if (index == -1)
                return;
            ModelDatabase[index] = game;
        }
    }
}
