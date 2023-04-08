using Bogus;
using MyGameCity.DataModel;

namespace MyGameCity.Services
{
    public class DeveloperService
    {
        public static Developer developer;
        
        public static Developer CreateDeveloepr()
        {
            var arrayOfDevelopers = new[] { "Coffee Stain Studio", "Square Enix", "RELOGIC", "343 studio", "Mojang" };
            var developerFaker = new Faker<Developer>()
                .RuleFor(x => x.Title, f => f.PickRandom(arrayOfDevelopers))
                .RuleFor(x => x.Description, f => f.Company.Bs())
                .RuleFor(x => x.CountryOfOrigin, f => f.Address.Country());
            return developer = developerFaker.Generate();
        }
        public static Dictionary<Developer,Games> DeveloperGames()
        {
            var developerDictionary = new Dictionary<Developer,Games>();
            var developerList = new List<Developer>();
            FakeDatabaseService.ModelDatabase.ForEach(x=> developerList.Add(x.Developer));
            foreach(Developer developer in developerList)
            {
                Random random = new Random();
                var number = Convert.ToInt32(random.Next(0, FakeDatabaseService.ModelDatabase.Count));
                for (int i = 0; i < number; i++)
                {
                    Random randomInFor = new Random();
                    var numberInFor = Convert.ToInt32(randomInFor.Next(0, FakeDatabaseService.ModelDatabase.Count));
                    developerDictionary.Add(developer, FakeDatabaseService.ModelDatabase[numberInFor]);
                }
            }
            return developerDictionary;
        }
    }
}
