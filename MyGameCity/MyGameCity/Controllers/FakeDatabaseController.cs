using MyGameCity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using MyGameCity.DataModel;
using System.Runtime.CompilerServices;
using Bogus;

namespace MyGameCity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeDatabaseController : ControllerBase
    {
        public static List<Games> ModelDatabase;
        [HttpGet]
        public void CreatDatabase()
        {
            Randomizer.Seed = new Random(7539743);

            var Categories = new[] { "Action", "Adventure", "RPG", "Casual", "Competetive" };

            var manufacturerFaker = new Faker<Manufacturer>()
            .StrictMode(true)
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .RuleFor(x => x.Description, f => f.Company.Bs())
            .RuleFor(x => x.CountryOforigin, f => f.Address.Country());
            //.RuleFor(x => x.ListOfCommodities, f => f.Commerce.Product());

            var reviewFaker = new Faker<Review>()
                .RuleFor(x => x.Stars, f => f.Random.Number(0, 5))
                .RuleFor(x => x.Description, f => f.Random.Word())
                .RuleFor(x => x.Title, f => f.Random.Word());

            var gamesFaker = new Faker<Games>()
                .RuleFor(x => x.Title, f => f.Commerce.ProductName())
                .RuleFor(x => x.Ammount, f => f.Random.Number())
                .RuleFor(x => x.Category, f => f.PickRandom(Categories))
                .RuleFor(x => x.Ammount, f => f.Random.Number(0, 500))
                .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Price, f => f.Random.Number())
                .RuleFor(x => x.Manufacturer, f => manufacturerFaker.Generate())
                .RuleFor(x => x.Review, f => reviewFaker.Generate())
                .RuleFor(x => x.Id, f => Guid.NewGuid());
            //.FinishWith((f, x) =>
            //{
            //    Console.WriteLine("Game created! Title={0}", x.Title);
            //});
            ModelDatabase = gamesFaker.Generate(5);
            FakeDatabaseController.ModelDatabase.ForEach(Console.WriteLine);
        }
        [HttpGet("GetDatabase")]
        public ActionResult<List<Games>> GetAll()
        {
            return ModelDatabase;
        }

        
    }
}
