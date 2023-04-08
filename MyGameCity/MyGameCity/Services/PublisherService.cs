using Bogus;
using MyGameCity.DataModel;

namespace MyGameCity.Services
{
    public class PublisherService
    {
        public static Publisher publisher { get; set; }
        public static List<Publisher> PublisherList = new List<Publisher>();
        public static Publisher CreatePublisher()
        {
            var arrayOfPublishers = new[] { "Epic Games", "Microsoft", "EA", "2K", "Square Enix", "Ubisoft", "Supergiant Games" };
            var publisherFaker = new Faker<Publisher>()
                .RuleFor(x => x.Title, f => f.PickRandom(arrayOfPublishers))
                .RuleFor(x => x.Description, f => f.Company.Bs())
                .RuleFor(x => x.CountryOfOrigin, f => f.Address.Country());
            publisher = publisherFaker.Generate();
            PublisherList.Add(publisher);
            return publisher;
        }
        public static Dictionary<Publisher, Games> PublisherGames()
        {
            var developerDictionary = new Dictionary<Publisher, Games>();
            var developerList = new List<Publisher>();
            FakeDatabaseService.ModelDatabase.ForEach(x => developerList.Add(x.Publisher));
            foreach (Publisher developer in developerList)
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
        public static Publisher Get(string title) => PublisherList.FirstOrDefault(x => x.Title == title);
    }
}
