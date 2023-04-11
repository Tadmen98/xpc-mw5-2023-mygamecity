using Bogus;
using MyGameCity.DataModel;

namespace MyGameCity.Services
{
    public class PublisherService
    {
        public static Publisher publisher { get; set; }
        public static List<Publisher> PublisherList = new List<Publisher>();
        public static List<Publisher> CreatePublisher(int numberOfTimeToGenerate)
        {
            var arrayOfPublishers = new[] { "Epic Games", "Microsoft", "EA", "2K", "Square Enix", "Ubisoft", "Supergiant Games" };
            var publisherFaker = new Faker<Publisher>()
                .RuleFor(x => x.Title, f => f.PickRandom(arrayOfPublishers))
                .RuleFor(x => x.Description, f => f.Company.Bs())
                .RuleFor(x => x.CountryOfOrigin, f => f.Address.Country());
            PublisherList = publisherFaker.Generate(numberOfTimeToGenerate);
            PublisherList.ForEach(x => x.ListOfGames = new List<string>());
            //PublisherList.Add(publisher);
            //publisher.ListOfGames = new List<string>();
            return PublisherList;
        }
        public static void PublisherGames()
        {
            Random random = new Random();
            var numberinFor = Convert.ToInt32(random.Next(1, FakeDatabaseService.ModelDatabase.Count()));
            for (int i = 0; i < numberinFor; i++)
            {
                Random rnd = new Random();
                var number = Convert.ToInt32(rnd.Next(0, FakeDatabaseService.ModelDatabase.Count()));
                foreach (var item in PublisherList)
                {
                    if (!item.ListOfGames.Contains(FakeDatabaseService.ModelDatabase[number].Title))
                    {
                        item.ListOfGames.Add(FakeDatabaseService.ModelDatabase[number].Title);
                    }
                }       
            }
        }
        public static void AddGameToPublisher(Publisher publisherFromList, Games game)
        {
            if (publisherFromList.ListOfGames.Contains(game.Title))
            {
                return;
            }
            publisherFromList.ListOfGames.Add(game.Title);
        }
        public static Publisher Get(string title) => PublisherList.FirstOrDefault(x => x.Title == title);
    }
}
