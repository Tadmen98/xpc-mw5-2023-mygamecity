using Bogus;
using MyGameCity.DataModel;

namespace MyGameCity.Services
{
    public class DeveloperService
    {
        public static List<Developer> DeveloperList = new List<Developer>();
        public static List<Developer> CreateDeveloper(int numberOfTimeToGenerate)
        {
            var arrayOfDevelopers = new[] { "Coffee Stain Studio", "Square Enix", "RELOGIC", "343 studio", "Mojang" };
            var developerFaker = new Faker<Developer>()
                .RuleFor(x => x.Title, f => f.PickRandom(arrayOfDevelopers))
                .RuleFor(x => x.Description, f => f.Company.Bs())
                .RuleFor(x => x.CountryOfOrigin, f => f.Address.Country());
            DeveloperList = developerFaker.Generate(numberOfTimeToGenerate);
            DeveloperList.ForEach(x => x.ListOfGames = new List<string>());
            return DeveloperList;
        }
        public static void DeveloperGames()
        {
            Random random = new Random();
            var numberinFor = Convert.ToInt32(random.Next(1, FakeDatabaseService.ModelDatabase.Count()));
            for (int i = 0; i < numberinFor; i++)
            {
                Random rnd = new Random();
                var number = Convert.ToInt32(rnd.Next(0, FakeDatabaseService.ModelDatabase.Count()));
                foreach (var item in DeveloperList)
                {
                    if (!item.ListOfGames.Contains(FakeDatabaseService.ModelDatabase[number].Title))
                    {
                        item.ListOfGames.Add(FakeDatabaseService.ModelDatabase[number].Title);
                    }
                }
            }
        }
        public static void AddGameToDeveloper(Developer developerfromlist, Games game)
        {
            if (developerfromlist.ListOfGames.Contains(game.Title))
            {
                return;
            }
            developerfromlist.ListOfGames.Add(game.Title);
        }
        public static Developer Get(string title) => DeveloperList.FirstOrDefault(x => x.Title == title);

    }
}
