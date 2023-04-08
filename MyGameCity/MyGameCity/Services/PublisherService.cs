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
            publisher.ListOfGames = new List<string>();
            //publisher.ListOfGames.Add(fake)
            return publisher;
        }
        public static void PublisherGames()
        {
            //var publisherDictionary = new Dictionary<Publisher, List<Games>>();
            //foreach (var publisher in PublisherList)
            //{
            //    Random random = new Random();
            //    var number = Convert.ToInt32(random.Next(0, FakeDatabaseService.ModelDatabase.Count));
            //    //developerDictionary.inse
            //    publisherDictionary.Add(publisher,new List<Games>());
            //    for (int i = 0; i < number; i++)
            //    {
            //        Random randomInFor = new Random();
            //        var numberInFor = Convert.ToInt32(randomInFor.Next(0, FakeDatabaseService.ModelDatabase.Count));
            //        publisherDictionary[publisher].Add(FakeDatabaseService.ModelDatabase[numberInFor]);
            //        //developerDictionary.TryAdd(developer, FakeDatabaseService.ModelDatabase[numberInFor]);
            //    }
            //}
            //return publisherDictionary;
            Random random = new Random();
            var numberinFor = Convert.ToInt32(random.Next(1, FakeDatabaseService.ModelDatabase.Count()));
            for (int i = 0; i < numberinFor; i++)
            {
                Random rnd = new Random();
                var number = Convert.ToInt32(rnd.Next(0, FakeDatabaseService.ModelDatabase.Count()));
                PublisherList.ForEach(x => x.ListOfGames.Add(FakeDatabaseService.ModelDatabase[number].Title));
            }
            //foreach(var publisher in PublisherList) 
            //{
            //    publisher.ListOfGames.Add(FakeDatabaseService.ModelDatabase[3]);
            //}
        }
        public static Publisher Get(string title) => PublisherList.FirstOrDefault(x => x.Title == title);
    }
}
