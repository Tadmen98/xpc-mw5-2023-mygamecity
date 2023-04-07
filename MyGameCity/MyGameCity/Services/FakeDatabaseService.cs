using Bogus;
namespace MyGameCity.Services
{
    public class FakeDatabaseService
    {
        Faker ModelDatabase;
        public void CreateDatabase()
        {
            Randomizer.Seed = new Random(3897234);
        }
    }
}
