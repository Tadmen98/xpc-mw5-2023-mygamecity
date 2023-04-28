using Bogus;
using MyGameCity.DataModel;

namespace MyGameCity.Services
{
    public class DeveloperService
    {
        //todo-cleancode if could be used later, delete it/keep it in work branch/stash....
        //public static Developer developer { get; set; }   Might be used later
        public static List<Developer> DeveloperList = new List<Developer>();
        // public static List<Developer> DeveloperList {get;set; } = new List<Developer>();
        
        // todo-maintability
        // todo-cleancode naming => 
        // CreateDeveloperList(int count/countOfDevelopersToGenerate)
        // GenerateDeveloperList(int count)
        public static List<Developer> CreateDeveloper(int numberOfTimeToGenerate)
        {
            
            var arrayOfDevelopers = new[] { "Coffee Stain Studio", "Square Enix", "RELOGIC", "343 studio", "Mojang" };
            var developerFaker = new Faker<Developer>()
                .RuleFor(x => x.Title, f => f.PickRandom(arrayOfDevelopers))
                .RuleFor(x => x.Description, f => f.Company.Bs())
                .RuleFor(x => x.CountryOfOrigin, f => f.Address.Country());
            DeveloperList = developerFaker.Generate(numberOfTimeToGenerate);
            
            DeveloperList.ForEach(x => x.ListOfGames = new List<string>());
            //DeveloperList.Add(developer);                     (!WIP!) Different implementation of creating developers for games (!WIP!)
            //developer.ListOfGames = new List<string>();
            return DeveloperList;
        }

        // todo-maintability what is the purpose of this method? 
        // not used
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

        //todo-cleancode method is not used
        public static void AddGameToDeveloper(Developer developerfromlist, Games game)
        {
            // todo-maintability if you try to add existing Game, it is good idea to throw exception
            if (developerfromlist.ListOfGames.Contains(game.Title))
            {
                return;
            }
            developerfromlist.ListOfGames.Add(game.Title);
        }
        public static Developer Get(string title) => DeveloperList.FirstOrDefault(x => x.Title == title);

    }
}
